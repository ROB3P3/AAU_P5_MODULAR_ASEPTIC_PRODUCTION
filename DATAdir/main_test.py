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
    data_generator = RandomDataGenerator(db, sensor_id)

    # Start generating random data and storing it in the database
    data_generator.generate_data()
        # Ensure the database connection is closed when done
    db.close()
