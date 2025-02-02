from lab_chat import get_peer_node, join_group, get_channel

def get_username():
    username = input("Enter your desired username: ")
    return username.strip().upper()

def get_group():
    group = input("Enter the group name you'd like to join: ")
    return group.strip().upper()

def get_message():
    message = input("Enter your message: ")
    return message.strip()

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

def main():
    start_chat()

if __name__ == "__main__":
    main()
