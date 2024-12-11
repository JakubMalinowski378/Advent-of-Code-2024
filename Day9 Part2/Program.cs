using var streamReader = new StreamReader("input.txt");
var input = streamReader.ReadLine()!;
var disk = new List<IFilePlaceholder>();
int id = 0;
for (int i = 0; i < input.Length; i++)
{
    if (i % 2 == 1)
    {
        disk.Add(new FreeSpace(input[i] - '0'));
        continue;
    }
    disk.Add(new File(id, input[i] - '0'));
    id++;
}

for (int i = disk.Count - 1; i >= 0; i--)
{
    if (disk[i] is File file)
    {
        for (int j = 0; j < i; j++)
        {
            if (disk[j] is FreeSpace freeSpace && freeSpace.Size >= file.Count)
            {
                disk.Insert(j, file);
                disk[i + 1] = new FreeSpace(file.Count);
                disk[j + 1] = new FreeSpace(freeSpace.Size - file.Count);
                i++;
                break;
            }
        }
    }
}

long checkSum = 0;
int weight = 0;
for (int i = 0; i < disk.Count; i++)
{
    if (disk[i] is File file)
    {
        for (int j = 0; j < file.Count; j++)
        {
            checkSum += file.Id * weight;
            weight++;
        }
        continue;
    }
    if (disk[i] is FreeSpace freeSpace)
    {
        weight += freeSpace.Size;
    }
}
Console.WriteLine(checkSum);

internal interface IFilePlaceholder { }
internal class File(int id, int count) : IFilePlaceholder
{
    public int Id { get; set; } = id;
    public int Count { get; set; } = count;
}

internal class FreeSpace(int size) : IFilePlaceholder
{
    public int Size { get; set; } = size;
}