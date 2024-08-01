public class Solution
{
    public int CountSeniors(string[] details)
    {
        var result = 0;
        foreach (var detail in details)
        {
            var age = (detail[11] - '0') * 10 + (detail[12] - '0');
            if (age > 60)
            {
                result++;
            }
        }
        return result;
    }
}