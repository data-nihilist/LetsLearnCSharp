class Result
{

    /*
     * Complete the 'areAlmostEquivalent' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY s
     *  2. STRING_ARRAY t
     */

    public static List<string> areAlmostEquivalent(List<string> s, List<string> t)
    {
        List<string> output = new List<string>(s.Count);
        
        int length = Math.Max(s.Count, t.Count);
        
        for (int i = 0; i < length; i++)
        {
            if(i >= s.Count || i >= t.Count)
            {
                output.Add("NO");
            }
            string a = s[i];
            string b = t[i];
            if(isAlmostEquivalent(a, b))
            {
                output.Add("YES");
            }
            else
            {
                output.Add("NO");
            }
        }
        return output;
    }
    
    public static bool isAlmostEquivalent(string a, string b)
    {
        if(a.Length != b.Length)
        {
            return false;
        }
        for(int i = 0; i < a.Length; i++)
        {
            char target = a[i];
            int charCountInA = findCharOccurrences(target, a);
            int charCountInB = findCharOccurrences(target, b);
            int difference = Math.Abs(charCountInA - charCountInB);
            if (difference > 3)
            {
                return false;
            }
        }
        return true;
    }
    
    public static int findCharOccurrences(char target, string input)
    {   
        int foundIt = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == target)
            {
                foundIt++;
            }
        }
        return foundIt;
    }
//-------------------------------------------------------------------------------------------------------
    /* 1, 2, 3
    1 -> 1 -> 1 -> 1
    1 -> 1 -> 2
    1 -> 2 -> 1
    1 -> 3
    2 -> 1 -> 1
    2 -> 2
    3 -> 1
*/

    static int ReturnSteps(int n)
    {
        int[] resultArray = new int[n + 2];
        resultArray[0] = 1;
        resultArray[1] = 1;     // was resultArray[1] = 2;
        resultArray[2] = 2;     // was resultArray[2] = 3;


        for(int i = 3; i <= n; i++)
        {
            resultArray[i] = resultArray[i - 1] + resultArray[i - 2] + resultArray[i - 3];
        }

        return resultArray[n];
    }
}