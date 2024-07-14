using System;
using System.CodeDom;


namespace Factory
{
    public interface IButton
    {
        void CreateButton();
    }

    public interface ICheckBox
    {
        void CreateCheckBox();
    }

    public class WindowButton : IButton
    {
        public void CreateButton()
        {
            Console.WriteLine("This is windows Button");
        }
    }

    public class MacButton : IButton
    {
        public void CreateButton()
        {
            Console.WriteLine("This is Mac Button");
        }
    }

    public class MacCheckBox : ICheckBox
    {
        public void CreateCheckBox()
        {
            Console.WriteLine("This is Mac CheckBox");
        }
    }

    public class WindowCheckBox : ICheckBox
    {
        public void CreateCheckBox()
        {
            Console.WriteLine("This is Window CheckBox");
        }
    }

    public interface IUIFactory
    {
        IButton RenderButton();
        ICheckBox RenderCheckBox();  
    }

    public class WindowFactory : IUIFactory
    {
        public IButton RenderButton()
        {
            return new WindowButton();
        }

        public ICheckBox RenderCheckBox()
        {
            return new WindowCheckBox();   
        }
    }

    public class MacFactory : IUIFactory
    {
        public IButton RenderButton()
        {
            return new MacButton();
        }

        public ICheckBox RenderCheckBox()
        {
            return new MacCheckBox();
        }
    }

    public class DisplayWindow
    {
        private IButton _button;
        private ICheckBox _checkBox;
        private IUIFactory _factory;
        public DisplayWindow(IUIFactory factory)
        {
            _factory = factory; 
            AssignElements();
        }

        private void AssignElements()
        {

            _button = _factory.RenderButton();
            _checkBox = _factory.RenderCheckBox();
        }


        public void RenderUI()
        {
            _button.CreateButton();
            _checkBox.CreateCheckBox(); 
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IUIFactory randomFactory = new WindowFactory();
            DisplayWindow d = new DisplayWindow(randomFactory);
            d.RenderUI();   
            randomFactory = new MacFactory();   
            DisplayWindow m = new DisplayWindow(randomFactory);
            m.RenderUI();   
        }
    }
}