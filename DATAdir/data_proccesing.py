import mysql.connector

class Database:
    # Starter en forbindelse til mysql databasen
    def __init__(self):
        # Step 1: Establish the connection
        self.db = mysql.connector.connect(
        host="localhost",        # MySQL server host
        user="anton",            # Your MySQL username
        password="anton",        # Your MySQL password
        database="pets"         # Name of the database that you want to connect
)       self.mycurser = self.db.cursor(buffered=True)
    
    def execute(self, cmd: str, val: tuple = None):
        if val is None:
            self.mycurser.execute(cmd)
        else:
            self.mycurser.execute(cmd, val)


    def production_data(self):
        self.execute()

        
        pass
    
    def smartlab_data(self):
        self.execute("CREATE TABLE IF NOT EXISTS smartlab_data (Carrier_ID int, active_plc VARCHAR(100), module active VARCHAR(100)") 
        self.mycurser.commit()
        self.execute("Insert sensor data into the smartlab_data", (sensor_id, value))
        self.mysql.commit()
        pass
    
    def order_data(self):
        self.execute("CREATE TABLE IF NOT EXISTS order_data (nummer_of_containers int, company VARCHAR(100), medicin VARCHAR(100)")
        pass


    def insert_data(self, sensor, value):

    def callback(self):


    
         