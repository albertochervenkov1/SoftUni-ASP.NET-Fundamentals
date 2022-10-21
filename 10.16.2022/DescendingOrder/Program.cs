using System;
using System.Collections.Generic;
using System.Text;

public static class Kata
{
    public static string Order(string words)
    {
        if (string.IsNullOrEmpty(words))
        {
            return string.Empty;
        }
        
        var list = words.Split(" ").ToList();
        StringBuilder sb = new StringBuilder();
        int count = 1;
        for (int i = 0; i < list.Count; i++)
        {
            char[] c = list[i].ToCharArray();
            if (c.Contains(char.Parse(count.ToString())))
            {
                sb.Append($"{list[i]} ");
                i = -1;
                count++;
            }
        }

        return sb.ToString().TrimEnd();
    }
}