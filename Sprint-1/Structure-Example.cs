 using System;

interface IShapes{
    void Area();
    void Perimeter();
}

/*
Can only implement interface
Can not inherit Classes or other Structures
*/

struct Rectangle : IShapes{
    private double X {get ; set;}
    public double Y {get; set;}
    public Rectangle(double x,double y){
        X = x;
        Y = y;
    }
    public void Area(){
        double area = X*Y;
        Console.WriteLine(area);
    }
    public void Perimeter(){
        double perimeter = 2*X*Y;
        Console.WriteLine(perimeter);
    }
}


class Practice {
  static void Main() {
    Rectangle r = new Rectangle(12,10);
    r.Area();
    r.Perimeter();
  }
}

