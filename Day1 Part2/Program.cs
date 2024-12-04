var list1 = new List<int>();
var dict = new Dictionary<int, int>();

using var streamReader = new StreamReader("input.txt");
string line;
while ((line = streamReader.ReadLine()!) != null)
{
    var splittedLine = line.Split("   ");
    list1.Add(int.Parse(splittedLine[0]));
    var v2 = int.Parse(splittedLine[1]);
    if (dict.TryGetValue(v2, out int value))
    {
        dict[v2] = ++value;
    }
    else
    {
        dict[v2] = 1;
    }
}
long result = 0;

for (int i = 0; i < list1.Count; i++)
{
    var isInDict = dict.TryGetValue(list1[i], out int value);
    result += list1[i] * (isInDict ? value : 0);
}
Console.WriteLine(result);