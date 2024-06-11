 using System;
using System.Collections;

public delegate void MyDelegate<T,CustomArgs>(T a,CustomArgs b);

class CustomArgs{
    public string Message {get;set;}
    public CustomArgs(string message){
        Message = message;
    }
}

class MovieCollection<T> : ArrayList{
    public string Category;
    private MyDelegate<MovieCollection<T>,CustomArgs> _onAddition;
    // public event MyDelegate<MovieCollection<T>,CustomArgs> OnAddition;
    public event MyDelegate<MovieCollection<T>,CustomArgs> OnAddition{
        add{
            _onAddition += value;
        }
        remove{
            _onAddition -= value;
        }
    }
    public MovieCollection(string category){
        Category = category;        
    }
    public void AddItem(T item){
        base.Add(item);
        _onAddition?.Invoke(this,new CustomArgs(Message));
    }
}

class Movies{
    public string Name {get;set;}
}

class Practice {
  static void OnCall(MovieCollection<Movies> a,CustomArgs b){
      Console.WriteLine(b.Message);
  }    
  static void Main() {
      MovieCollection<Movies> m = new MovieCollection<Movies>(Movies);
      m.OnAddition += OnCall;
      m.AddItem(new Movies{Name = POBW});
  }
}
