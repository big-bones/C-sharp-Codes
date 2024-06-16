class Base{
    public virtual void Method(){
        Console.WriteLine(This is a base class);
    }
}

class Derived : Base{
    public override void Method(){
        Console.WriteLine(This is derived class);
    }
    public void DerivedMethod(){
        Console.WriteLine(This is so cool);
    }
}

class Generic<T> where T : Base{
    public T value;
    public Generic(T item){
        value = item;
    }
    public void Invoke(){
        value.Method();
        Console.WriteLine(value.GetType().Name);
    }
}

class HelloWorld {
  static void Main() {
     var otherTemp = new Generic<Base>(new Derived());
     var secondTemp = new Generic<Derived>(new Derived());
     otherTemp.Invoke();
     secondTemp.value.DerivedMethod();
  }
}
