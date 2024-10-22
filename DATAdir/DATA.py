import mysql.connector
from opcua import Client
import time

class Database:
    def __init__(self, db_host, db_user, db_password, db_name):
        """Initialize the database connection parameters."""
        self.db_host = db_host
        self.db_user = db_user
        self.db_password = db_password
        self.db_name = db_name
        self.mysql = None
        self.curs = None
        self.connect()
        self.create_table()

    def connect(self):
        """Establish a connection to the MySQL database."""
        self.mysql = mysql.connector.connect(
            host=self.db_host,
            user=self.db_user,
            password=self.db_password,
            database=self.db_name
        )
        self.curs = self.mysql.cursor()

    def create_table(self):
        """Create a table to store sensor data if it doesn't already exist."""
        create_table_query = """
        CREATE TABLE IF NOT EXISTS sensor_data (
            id INT AUTO_INCREMENT PRIMARY KEY,
            timestamp DATETIME,
            sensor_id VARCHAR(255),
            value FLOAT
        );
        """
        self.curs.execute(create_table_query)
        self.mysql.commit()

    def insert_data(self, sensor_id, value):
        """Insert sensor data into the database."""
        insert_query = """
        INSERT INTO sensor_data (timestamp, sensor_id, value)
        VALUES (NOW(), %s, %s);
        """
        self.curs.execute(insert_query, (sensor_id, value))
        self.mysql.commit()

    def close(self):
        """Close the database connection."""
        self.curs.close()
        self.mysql.close()


class OPCUASensorReader:
    def __init__(self, opcua_url, db):
        """Initialize the OPC UA client and database instance."""
        self.client = Client(opcua_url)
        self.db = db

    def connect(self):
        """Connect to the OPC UA server."""
        try:
            self.client.connect()
            print("Connected to OPC UA server.")
        except Exception as e:
            print(f"Failed to connect to OPC UA server: {e}")

    def read_and_store_data(self, node_id):
        """Read data from the OPC UA node and store it in the database."""
        try:
            while True:
                sensor_value = self.client.get_node(node_id).get_value()
                sensor_id = node_id  # You can customize the sensor ID logic here
                print(f"Reading value from {sensor_id}: {sensor_value}")

                # Insert data into the database
                self.db.insert_data(sensor_id, sensor_value)

                time.sleep(5)  # Adjust the sleep time as needed
        except Exception as e:
            print(f"An error occurred while reading data: {e}")
        finally:
            self.client.disconnect()

    def callback(self, node_id):
        """Callback method for handling incoming sensor data."""
        self.read_and_store_data(node_id)


# Usage example
if __name__ == "__main__":
    # Database configuration
    db_host = "localhost"
    db_user = "anton"  # Your MySQL username
    db_password = "anton"  # Your MySQL password
    db_name = "pets"  # Your MySQL database name

    # OPC UA configuration
    opcua_url = "opc.tcp://localhost:4840"  # Change to your OPC UA server URL
    node_id = "ns=2;i=2"  # Change to your OPC UA node ID

    # Create a database instance
    db = Database(db_host, db_user, db_password, db_name)

    # Create an OPC UA sensor reader instance
    sensor_reader = OPCUASensorReader(opcua_url, db)

    # Connect to the OPC UA server and start reading data
    sensor_reader.connect()
    sensor_reader.callback(node_id)  # Call the callback to start reading and storing data

    # Close the database connection when done
    db.close()
