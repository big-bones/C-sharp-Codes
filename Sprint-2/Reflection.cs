using System;
using System.Reflection;

class MyClass{
    public string MyProperty{get;private set;}
    public void MyMethod(){
        Console.WriteLine("Hi there");
    }
    private void PrivateMethod(){
        Console.WriteLine("This is a private method");
    }
    public void Add(int a,int b){
        Console.WriteLine(a+b);
    }
}


class Practice{
  static void Main() {
    Type type = typeof(MyClass);
    Console.WriteLine(type.Name);
    PropertyInfo [] properties = type.GetProperties();
    foreach (var property in properties){
        Console.WriteLine("Property: " + property.Name);
    }
    MethodInfo [] methods = type.GetMethods();
    foreach(var method in methods){
        Console.WriteLine("Method: " + method.Name);
    }
    Assembly assembly = Assembly.GetExecutingAssembly();
    Console.WriteLine(assembly.FullName);
    Console.WriteLine(assembly.Location);
    object instance = Activator.CreateInstance(type);
    MethodInfo methodInstance = type.GetMethod("PrivateMethod",BindingFlags.Instance|BindingFlags.NonPublic);
    methodInstance.Invoke(instance,null);
    MethodInfo addMethod = type.GetMethod("Add");
    addMethod.Invoke(instance,new object [] {1,2});
    PropertyInfo prop = type.GetProperty("MyProperty",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    prop.SetValue(instance,"sarang");
    object value = prop.GetValue(instance);
    Console.WriteLine(value);
    //same for fileds if property does not have set you can't use this
  }
}