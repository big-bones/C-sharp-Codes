using System;


namespace Factory
{

    public interface INotification
    {
        void CreateNotification();
    }

    public class SMSNotificationProduct : INotification
    {
        public void CreateNotification()
        {
            Console.WriteLine("This is SMS notification");
        }
    }

    public class EmailNotificationProduct : INotification
    {
        public void CreateNotification()
        {
            Console.WriteLine("This is Email Notification");
        }
    }

    public interface IProductFactory
    {
         INotification CreateProduct();
    }

    public class SMSFactory : IProductFactory
    {
        public INotification CreateProduct()
        {
            return new SMSNotificationProduct();    
        }
    }

    public class EmailFactory : IProductFactory
    {
        public INotification CreateProduct()
        {
            return new EmailNotificationProduct();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IProductFactory productFactory;
            INotification notification = (new SMSFactory()).CreateProduct();
            notification.CreateNotification();  
            notification = (new  EmailFactory()).CreateProduct();   
            notification.CreateNotification();  
        }
    }
}