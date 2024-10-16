import mysql.connector

# Step 1: Establish the connection
db = mysql.connector.connect(
    host="localhost",        # Replace with your MySQL server host
    user="yourusername",      # Replace with your MySQL username
    password="yourpassword",  # Replace with your MySQL password
    database="testdb"         # Replace with your database name
)

# Step 2: Create a cursor object
cursor = db.cursor()

# Step 3: Prepare the SQL query to insert data
sql = "INSERT INTO users (name, email) VALUES (%s, %s)"
values = ("John Doe", "john@example.com")

# Step 4: Execute the SQL query
cursor.execute(sql, values)

# Step 5: Commit the transaction (saves the data in the database)
db.commit()

# Step 6: Print the number of records inserted
print(cursor.rowcount, "record inserted.")

# Step 7: Close the connection
db.close()
