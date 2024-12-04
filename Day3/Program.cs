using System.Text.RegularExpressions;

using var streamReader = new StreamReader("input.txt");
int sum = 0;
var pattern = @"mul\(\d{1,3},\d{1,3}\)";
string input = streamReader.ReadToEnd();

var matchingExpressions = Regex.Matches(input, pattern);
foreach (var value in matchingExpressions)
{
    var c = value.ToString()!.ToCharArray();
    var indexOfOpeningBracket = Array.IndexOf(c, '(') + 1;
    var indexOfComma = Array.IndexOf(c, ',');
    var v1 = c[indexOfOpeningBracket..indexOfComma];
    var v2 = c[(indexOfComma + 1)..(c.Length - 1)];
    sum += int.Parse(new string(v1)) * int.Parse(new string(v2));
}
Console.WriteLine(sum);