import paho.mqtt.client as mqtt

# Define the callback for when the client receives a CONNACK response from the server.
def on_connect(client, userdata, flags, rc):
    print(f"Connected with result code {rc}")
    # Subscribing in on_connect() means that if we lose the connection and
    # reconnect then subscriptions will be renewed.
    client.subscribe("test/topic")
    client.subscribe("PLC/plc1")
    client.publish("PLC/plc1", "I am PLC1")

# Define the callback for when a PUBLISH message is received from the server.
def on_message(client, userdata, msg):
    print(f"{msg.topic} {msg.payload}")
    client.publish("PLC/plc1", "I am PLC1")

def on_disconnect(client, userdata, flags, rc):
    print(f"disconected with result code {rc}")


# Create an MQTT client instance
client = mqtt.Client()

# Assign the callback functions
client.on_connect = on_connect
client.on_message = on_message
client.on_disconnect = on_disconnect


# Connect to the MQTT broker
client.connect("127.0.0.1", 1883, 60)

# Start the loop to process network traffic and dispatch callbacks

PLCTopics = []
for i in range(4):
    PLCTopics.append("PLC/plc{}".format(i))

client.loop_forever()
