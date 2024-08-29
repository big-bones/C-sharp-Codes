using System;

namespace DecoratorPatternExample
{
    // Component Interface
    public interface INotifier
    {
        void Send(string message);
    }

    // Concrete Component: Basic email notifier
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    // Decorator: Abstract class that wraps an INotifier
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier _notifier;

        public NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }

    // Concrete Decorator: Adds SMS notification
    public class SMSNotifier : NotifierDecorator
    {
        public SMSNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message); // Send the original notification
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // Concrete Decorator: Adds Push notification
    public class PushNotifier : NotifierDecorator
    {
        public PushNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message); // Send the original notification
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }

    // Test the Decorator Pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Create the base email notifier
            INotifier notifier = new EmailNotifier();

            // Send an email notification
            notifier.Send("Hello!");

            Console.WriteLine();

            // Add SMS notification functionality
            notifier = new SMSNotifier(notifier);
            notifier.Send("Hello with SMS!");

            Console.WriteLine();

            // Add Push notification functionality
            notifier = new PushNotifier(notifier);
            notifier.Send("Hello with SMS and Push!");
        }
    }
}
