using System;
using System.Collections.Generic;

public interface IChatRoomMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

public class ChatRoom : IChatRoomMediator
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            // Message should not be received by the user sending it
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

public abstract class User
{
    protected IChatRoomMediator _mediator;
    public string Name { get; private set; }

    public User(IChatRoomMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ChatUser : User
{
    public ChatUser(IChatRoomMediator mediator, string name) : base(mediator, name)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IChatRoomMediator chatRoom = new ChatRoom();

        User user1 = new ChatUser(chatRoom, "Alice");
        User user2 = new ChatUser(chatRoom, "Bob");
        User user3 = new ChatUser(chatRoom, "Charlie");

        chatRoom.AddUser(user1);
        chatRoom.AddUser(user2);
        chatRoom.AddUser(user3);

        user1.Send("Hello, everyone!");
        user2.Send("Hi, Alice!");
    }
}
