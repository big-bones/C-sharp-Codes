using System;

// Here the issue is if a new way of notification sending like sendtext is added
// And so on the system increases it becomes difficult to test 
// System should be modular hence SRP
class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public void RegisterUser()
    {

    }

    public void SendEmail()
    {

    }
}

// After SRP

class UserRegistration{ 
    public int Id { get; set; } 
    public string Name { get; set; }
    public void RegisterUser() { 
    
    }  
}

class SendEmailNotification
{
    public void SendEmail() { 

    }
}