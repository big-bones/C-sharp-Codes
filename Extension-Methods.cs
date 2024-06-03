 using System;

    public static class MyStringExtensions
    {
        public static bool IsNumeric(this string str)
        {
            foreach (char c in str)
            {
                {
                    return false;
                }
            }
            return true;
        }
    }

class Program
{
    static void Main()
    {
        string testString = 12345;
        bool isNumeric = testString.IsNumeric();
        Console.WriteLine($Is the string numeric? {isNumeric});
    }
}
