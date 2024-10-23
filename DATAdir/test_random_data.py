import mysql.connector
import random
import time


class Database:
    #
    def __init__(self, db_host, db_user, db_password, db_name):
        """Initialize the database connection parameters."""
        self.db_host = db_host
        self.db_user = db_user
        self.db_password = db_password
        self.db_name = db_name
        self.mysql = None
        self.curs = None
        self.connect()  # Connect first
        self.create_table()  # Then create the table

    #connection to database setup
    def connect(self):
        """Establish a connection to the MySQL database."""
        self.mysql = mysql.connector.connect(
            host=self.db_host,
            user=self.db_user,
            password=self.db_password,
            database=self.db_name
        )
        self.curs = self.mysql.cursor()
        print("Connected to the database successfully.")

    #makes a new table in the database, if it does not allready exist
    def create_table(self):
        """Create a table to store sensor data if it doesn't already exist."""
        create_table_query = """
        CREATE TABLE IF NOT EXISTS sensor_data1 (
            id INT AUTO_INCREMENT PRIMARY KEY,
            timestamp DATETIME,
            sensor_id VARCHAR(255),
            value FLOAT
        );
        """
        self.curs.execute(create_table_query)
        self.mysql.commit()
        print("Table created successfully.")

    #insert data into Dbeaverdatabase
    def insert_data(self, sensor_id, value):
        """Insert sensor data into the database."""
        insert_query = """
        INSERT INTO sensor_data1 (timestamp, sensor_id, value)
        VALUES (NOW(), %s, %s);
        """
        self.curs.execute(insert_query, (sensor_id, value))
        self.mysql.commit()
        print(f"Data inserted successfully for {sensor_id}.")

    #closes the connection
    def close(self):
        """Close the database connection."""
        self.mysql.close()

#class for random data
class RandomDataGenerator:
    def __init__(self, db, sensor_id):
        """Initialize the random data generator with a database instance."""
        self.db = db
        self.sensor_id = sensor_id
        self.generate_data()

    def generate_data(self):
        """Generate random data and insert it into the database."""
        while True:
                # Generate a random value (e.g., between 0 and 100)
            random_value = random.uniform(0, 100)
            print(f"Generated random value for {self.sensor_id}: {random_value}")

            # Insert data into the database
            self.db.insert_data(self.sensor_id, random_value)

            time.sleep(5)  # Adjust the sleep time as needed
            
from test_random_data import Database
from test_random_data  import RandomDataGenerator

if __name__ == "__main__":
    # Database configuration
    db_host = "localhost"
    db_user = "anton"  # Your MySQL username
    db_password = "anton"  # Your MySQL password
    db_name = "pets"  # Your MySQL database name

    # Create a database instance
    db = Database(db_host, db_user, db_password, db_name)

    # Create a random data generator instance
    sensor_id = "random_sensor_1"  # Define a sensor ID for the random data
    RandomDataGenerator(db, sensor_id)

    # Start generating random data and storing it in the database
        # Ensure the database connection is closed when done
    db.close()
    
