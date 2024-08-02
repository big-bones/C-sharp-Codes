using System;

namespace Bridge{
    public interface IColor
    {
        void ApplyColor();
    }

    public class Red : IColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Applying Red color");
        }
    }

    public class Blue : IColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Applying Blue color");
        }
    }

    public abstract class Shape
    {
        protected IColor color;
        protected Shape(IColor color)
        {
            this.color = color;
        }

        public abstract void Draw();

    }

    public class Circle : Shape
    {
        public Circle(IColor color) : base(color) 
        {

        }
     
        public override void Draw()
        {
            Console.WriteLine("Circle is being drawn");
            color.ApplyColor();
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(IColor color) : base(color)
        {

        }

        public override void Draw()
        {
            Console.WriteLine("Rectangle is being drawn");
            color.ApplyColor();
        }
    }

    public class Program
    {
        public static void Main()
        {
            IColor red = new Red(); 
            Circle cr = new Circle(red);
            IColor blue = new Blue();
            Circle cb = new Circle(blue);
            Rectangle rr = new Rectangle(red);
            Rectangle rb = new Rectangle(blue);
            cb.Draw();
            cr.Draw();
            rr.Draw();
            rb.Draw();
        }
    }


}