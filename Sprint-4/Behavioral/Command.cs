using System;
using System.IO;
using System.Windows.Input;

interface ICommand
{
    void TurnOn();
    void TurnOff(); 
}


class Command : ICommand
{
    private Light _light;

    public Command(Light light)
    {
        _light = light;
    }

    public void TurnOff()
    {
        _light.TurnOff();
    }

    public void TurnOn()
    {
        _light.TurnOn();
    }
}


class Light
{
    public void TurnOn()
    {
        Console.WriteLine("The light is on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("The light is off.");
    }
}

class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.TurnOn();  
    }

    public void PressOff()
    {
        _command.TurnOff();
    }
}

class VoiceControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void SayOn()
    {

        _command.TurnOn();
    }

    public void SayOff()
    {
        _command.TurnOff();
    }
}

class ButtonControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressOn()
    {
        _command.TurnOn();
    }

    public void PressOff()
    {
        _command.TurnOff();
    }
}

class Program
{
    static void Main()
    {

        Light light = new Light();
        ICommand command = new Command(light);

        RemoteControl remote = new RemoteControl();
        VoiceControl voiceControl = new VoiceControl();
        ButtonControl buttonControl = new ButtonControl();

        remote.SetCommand(command);
        buttonControl.SetCommand(command);
        voiceControl.SetCommand(command);

        remote.PressButton();
        remote.PressOff();
        voiceControl.SayOn();
        voiceControl.SayOff();
        buttonControl.PressOn();
        buttonControl.PressOff();
    }
}