using System;
using System.Collections.Generic;

class WeekDays{
    public IEnumerable<string> Days{
        get
        {
            yield return Monday;
            yield return Tuesday;
            yield return Wednesday;
            yield return Thursday;
            yield return Friday;
            yield return Saturday;
            yield return Sunday;
        }
    }
}

class Alphabet{
    private char [] letters = ABCDEFGHIJKLMNOPQRSTUVWXYZ.ToCharArray();
    public IEnumerable<char> this[int start,int end]{
        get{
            for (int i = start; i <= end; i++){
                yield return letters[i];
            }
        }
    }
}

class Practice{
  static void Main() {
      WeekDays wd = new WeekDays();
      foreach(string x in wd.Days){
          Console.Write(x +  );
      }
      Console.WriteLine();
      Alphabet a = new Alphabet();
      foreach(char c in a[0,25]){
          Console.Write(c);
      }
  }
}
