import mysql.connector

# Step 1: Establish the connection
db = mysql.connector.connect(
    host="localhost",        # MySQL server host
    user="anton",            # Your MySQL username
    password="anton",        # Your MySQL password
    database="pets"         # Name of the database that you want to connect
)

# Step 2: Create a cursor object
mycursor = db.cursor()
mycursor.execute("CREATE TABLE cat (name VARCHAR(255), owner VARCHAR(255), birth YEAR(4))")
# Step 3: Execute a query to show databases
mycursor.execute("INSERT INTO cat (name, owner, birth) VALUES (%s,%s,%s )",("retard","hey", 1))
db.commit()
#mycursor.execute("SELECT * FROM morten")
#for x in mycursor:
    #print(x)


# Step 4: Fetch and print the results


# Step 5: Close the cursor and connection



