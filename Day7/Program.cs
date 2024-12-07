using System.Data;
using System.Text.RegularExpressions;

using var streamReader = new StreamReader("input.txt");
string line;
var data = new List<(long result, string expression)>();
while ((line = streamReader.ReadLine()!) != null)
{
    int colonIndex = line.IndexOf(':');
    var z = line[(colonIndex + 2)..].Replace(" ", ")Y") + ")";
    data.Add((long.Parse(line[..colonIndex]), new string('(', z.Count(x => x == 'Y') + 1) + z));
}
long sum = 0;
foreach (var input in data)
{
    var combinations = new List<string>();
    GenerateCombinations(input.expression, ref combinations);
    foreach (var value in combinations)
    {
        var result = Evaluate(value);
        if (result == input.result)
        {
            sum += result;
            break;
        }
    }
}

Console.WriteLine(sum);

static void GenerateCombinations(string expression, ref List<string> results)
{
    int index = expression.IndexOf('Y');
    if (index == -1)
    {
        results.Add(expression);
        return;
    }
    string withMultiplication = expression.Substring(0, index) + "*" + expression.Substring(index + 1);
    GenerateCombinations(withMultiplication, ref results);
    string withAddition = expression.Substring(0, index) + "+" + expression.Substring(index + 1);
    GenerateCombinations(withAddition, ref results);
}

static long Evaluate(string expression)
{
    expression = Regex.Replace(expression, @"\d+(\.\d+)?",
        m =>
        {
            var x = m.ToString();
            return x.Contains(".") ? x : string.Format("{0}.0", x);
        });
    DataTable table = new DataTable();
    return Convert.ToInt64(table.Compute(expression, string.Empty));
}