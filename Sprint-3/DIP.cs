class LightBulb
{
    public void Off() { }
    public void On() { }
}

class Switch
{
    LightBulb _light;
    public Switch(LightBulb light)
    {
        _light = light;
    }   

    public void Operate(string condition)
    {
        // do operations
    }
}

// This is tightly coupled if I want to change the light bulb to led I have to change across
//the code that would result in complications and might introduce bugs


//After DIP
interface ILightFunction
{
    void On();
    void Off();
}

class LightBulbs : ILightFunction
{
    public void On()
    {

    }

    public void Off()
    {

    }
}

class LEDLight : ILightFunction
{
    public void Off()
    {
    
    }

    public void On()
    {
        
    }
}

class Switch
{
    private ILightFunction _lightFunction;
    public Switch(ILightFunction lightFunction) 
    {
        this._lightFunction = lightFunction;
    }

    public void Operate(string condition)
    {
        _lightFunction.On();
    }
}

class Driver
{
    static void Main()
    {
        Switch sc = new Switch(new LEDLight());
    }
}
