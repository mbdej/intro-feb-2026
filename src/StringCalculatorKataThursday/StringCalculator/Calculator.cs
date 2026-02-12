
using System.Text.RegularExpressions;

public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == "") 
        {  
            return 0; 
        }

        string delimiters = @"[^0-9|\-]";

        string[] arr = Regex.Split(numbers, delimiters);

        List<string> list = arr
                            .Where(s => !string.IsNullOrEmpty(s))
                            .ToList();
        int sum = 0;

        List<int> negatives = new List<int>();
        bool hasNegatives = false;

        foreach (string num in list)
        {
            int n = int.Parse(num);
            if (n > 1000)
            {
                continue;
            }
            if (n < 0)
            {
                hasNegatives = true;
                negatives.Add(n);
            }
            sum += n;
        }

        if (hasNegatives)
        {
            string message = "";
            foreach (int num in negatives)
            {
                message += (num.ToString() + ",");
            }
            message = message.Remove(message.Length - 1);
            throw new Exception(message);
        }

        return sum;
    }
}
