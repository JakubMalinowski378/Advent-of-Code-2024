int safeCount = 0;
using var streamReader = new StreamReader("input.txt");
string line;
while ((line = streamReader.ReadLine()!) != null)
{
    var numbers = line.Split(' ').Select(int.Parse).ToArray();
    if (IsValid(numbers, out var indices))
    {
        safeCount++;
    }
    else
    {
        foreach (var value in indices!)
        {
            int[] x = numbers.Take(value).Concat(numbers.Skip(value + 1)).ToArray();
            if (IsValid(x, out var _))
            {
                safeCount++;
                break;
            }
        }
    }
}
Console.WriteLine(safeCount);

static bool IsValid(int[] array, out int[]? indices)
{
    int increasing = 0;
    if (array[0] < array[1])
        increasing++;
    if (array[1] < array[2])
        increasing++;
    if (array[2] < array[3])
        increasing++;
    for (int i = 1; i < array.Length; i++)
    {
        var diff = Math.Abs(array[i - 1] - array[i]);
        if (!((diff >= 1 && diff <= 3) &&
            ((increasing >= 2 && array[i - 1] < array[i]) ||
            (increasing < 2 && array[i - 1] > array[i]))
            ))
        {
            indices = [i - 1, i];
            return false;
        }
    }
    indices = null;
    return true;
}