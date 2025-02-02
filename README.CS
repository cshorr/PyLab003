# P2P Chat System

## Functions from lab_chat.py

### Function to Get Peer Node
```python
def get_peer_node(username):  # function name is get_peer_node
    """
    Creates a peer node with the specified username using Pyre.
    """
# Parameters:
# username: The desired username for the peer node. (String)
#
# This function returns the created peer node.
# I believe this function initializes a Pyre node with the specified username and starts it.
### Function to Join Group
```python
def join_group(node, group):  # function name is join_group
    """
    Joins the specified group using the given node.
    """
# Parameters:
# node: The peer node that will join the group. (Pyre node)
# group: The name of the group to join. (String)
#
# This function does not return anything.
# I believe this function makes the peer node join the specified group.
### Function for Chat Task
```python
def chat_task(ctx, pipe, n, group):  # function name is chat_task
    """
    Handles chat tasks, such as sending and receiving messages.
    """
# Parameters:
# ctx: This is a ZeroMQ Connection Context.
# pipe: This is a communications pipe polled by ZeroMQ for messages.
# n: This is the peer-to-peer node my chat app is connected as. (Pyre node)
# group: This is the peer chat group I wanted to join. (String)
#
# This function does not return anything.
# I believe this function manages sending and receiving messages within the chat group.
### Function to Get Communication Channel
```python
def get_channel(node, group):  # function name is get_channel
    """
    Returns the communication channel for the specified node and group.
    """
# Parameters:
# node: The peer node for which the communication channel is required. (Pyre node)
# group: The name of the group for communication. (String)
#
# This function returns a communication channel.
# I believe this function creates and returns a communication channel for message exchange.
from lab_chat import get_peer_node, join_group, chat_task, get_channel
def initialize_chat():
    username = get_username()
    group = get_group()

    node = get_peer_node(username)
    join_group(node, group)
    channel = get_channel(node, group)

    return channel
def start_chat():
    channel = initialize_chat()

    while True:
        try:
            msg = get_message()
            channel.send(msg.encode('utf-8'))
        except (KeyboardInterrupt, SystemExit):
            break
    channel.send("$$STOP".encode('utf-8'))
    print("FINISHED")
