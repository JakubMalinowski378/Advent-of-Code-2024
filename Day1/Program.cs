var list1 = new List<int>();
var list2 = new List<int>();

using var streamReader = new StreamReader("input.txt");
string line;
while ((line = streamReader.ReadLine()!) != null)
{
    var splittedLine = line.Split("   ");
    list1.Add(int.Parse(splittedLine[0]));
    list2.Add(int.Parse(splittedLine[1]));
}

list1.Sort();
list2.Sort();

int diff = 0;

for (int i = 0; i < list1.Count; i++)
{
    diff += Math.Abs(list1[i] - list2[i]);
}

Console.WriteLine(diff);
