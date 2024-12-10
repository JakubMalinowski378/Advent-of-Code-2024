using var streamReader = new StreamReader("input.txt");
var input = streamReader.ReadLine()!;
var diskMap = new List<int?>();
int id = 0;
for (int i = 0; i < input.Length; i++)
{
    if (i % 2 == 1)
    {
        for (int j = 0; j < input[i] - '0'; j++)
            diskMap.Add(null);
        continue;
    }
    for (int j = 0; j < input[i] - '0'; j++)
        diskMap.Add(id);
    id++;
}
for (int i = 0, j = diskMap.Count - 1; i < j; i++, j--)
{
    while (diskMap[i] is not null && i < j)
        i++;
    while (diskMap[j] is null && i < j)
        j--;
    (diskMap[i], diskMap[j]) = (diskMap[j], diskMap[i]);
}
long result = 0;
for (int i = 0; i < diskMap.IndexOf(null); i++)
{
    result += (long)(diskMap[i] * i)!;
}
Console.WriteLine(result);