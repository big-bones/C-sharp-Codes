using System;

interface IWorker {
    void Work();
    void Eat();
}


class HumanWorker : IWorker
{
    public void Work()
    {

    }

    public void Eat()
    {

    }
}

class RobotWorker : IWorker
{
    public void Work()
    {

    }

    public void Eat()
    {
        throw new NotImplementedException();
    }
}

interface Eat
{
    void Eat(); 
}

interface Work
{
    void Work();    
}

class HumanWorker : Work,Eat
{
    public void Work()
    {

    }

    public void Eat()
    {

    }
}

class RobotWorker : Work
{
    public void Work()
    {

    }
}w