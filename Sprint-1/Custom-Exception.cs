using System;
using static System.Console;


class CustomException : Exception{
    public CustomException(string message) : base(message){
        
    }
}

class Practice {
  static void Main() {
    try{
        int i = 10;
        if(i < 0){
            throw new CustomException("Value less than zero found");
        }else{
            WriteLine(i);
        }
    }catch(CustomException e){
        WriteLine(e.Message);
    }
  }
}