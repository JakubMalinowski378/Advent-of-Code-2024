using System.Data;
using System.Text.RegularExpressions;

using var streamReader = new StreamReader("input.txt");
string line;
var data = new List<(long result, string expression)>();
while ((line = streamReader.ReadLine()!) != null)
{
    int colonIndex = line.IndexOf(':');
    var z = line[(colonIndex + 2)..].Replace(" ", ")Y") + ")";
    var expression = Regex.Replace(z, @"\d+(\.\d+)?",
        m =>
        {
            var x = m.ToString();
            return x.Contains(".") ? x : string.Format("{0}.0", x);
        });
    data.Add((long.Parse(line[..colonIndex]), new string('(', z.Count(x => x == 'Y') + 1) + expression));
}

long sum = 0;
foreach (var input in data)
{
    bool isMatchFound = false;
    GenerateCombinations(input.expression, input.result, ref sum, ref isMatchFound);
}

Console.WriteLine(sum);

static void GenerateCombinations(string expression, long targetResult, ref long sum, ref bool isMatchFound)
{
    if (isMatchFound) return;
    int index = expression.IndexOf('Y');
    if (index == -1)
    {
        var result = Evaluate(expression);
        if (result == targetResult)
        {
            sum += result;
            isMatchFound = true;
        }
        return;
    }
    string withMultiplication = expression.Substring(0, index) + "*" + expression.Substring(index + 1);
    GenerateCombinations(withMultiplication, targetResult, ref sum, ref isMatchFound);
    if (isMatchFound) return;

    string withAddition = expression.Substring(0, index) + "+" + expression.Substring(index + 1);
    GenerateCombinations(withAddition, targetResult, ref sum, ref isMatchFound);
    if (isMatchFound) return;

    string withConcatenation = expression.Substring(0, index) + "||" + expression.Substring(index + 1);
    GenerateCombinations(withConcatenation, targetResult, ref sum, ref isMatchFound);
}

static long Evaluate(string expression)
{
    var indexOfConcatenation = expression.IndexOf("||");
    if (indexOfConcatenation != -1)
    {
        var apprenticesCount = expression[indexOfConcatenation..].Count(x => x == ')');
        var leftSide = Evaluate(expression[apprenticesCount..indexOfConcatenation]);
        var z = expression[(indexOfConcatenation + 2)..];
        var newExpression = $"{expression[..apprenticesCount]}{leftSide}{expression[(indexOfConcatenation + 2)..]}";
        return Evaluate(newExpression);
    }
    DataTable table = new DataTable();
    return Convert.ToInt64(table.Compute(expression, string.Empty));
}