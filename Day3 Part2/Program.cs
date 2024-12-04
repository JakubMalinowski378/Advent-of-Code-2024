using System.Text.RegularExpressions;

using var streamReader = new StreamReader("input.txt");
int sum = 0;
var pattern = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";
string input = streamReader.ReadToEnd();
var matchingExpressions = Regex.Matches(input, pattern);
bool adding = true;
foreach (var value in matchingExpressions)
{
    if (value.ToString() == "don't()")
    {
        adding = false;
        continue;
    }
    if (value.ToString() == "do()")
    {
        adding = true;
        continue;
    }
    if (!adding)
        continue;
    var c = value.ToString()!.ToCharArray();
    var indexOfOpeningBracket = Array.IndexOf(c, '(') + 1;
    var indexOfComma = Array.IndexOf(c, ',');
    var v1 = c[indexOfOpeningBracket..indexOfComma];
    var v2 = c[(indexOfComma + 1)..(c.Length - 1)];
    sum += int.Parse(new string(v1)) * int.Parse(new string(v2));
}
Console.WriteLine(sum);