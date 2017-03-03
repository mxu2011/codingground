using System.IO;
using System;

public class Program
{
    public static void Main()
    {
        test1();
    }
    
    private static void test1() {
        var str = "ABABDEDFBG";
        
        var obj = new LongestSubstringWithoutRepeatingCharacters();
        
        Console.WriteLine("Ths lenth of Longest substring (without repeating characters): {0}",
        obj.FindLongestSubstringLength(str));        
    }
}
