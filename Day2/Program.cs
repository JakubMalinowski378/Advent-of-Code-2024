int safeCount = 0;
using var streamReader = new StreamReader("input.txt");
string line;
while ((line = streamReader.ReadLine()!) != null)
{
    var numbers = line.Split(' ').Select(int.Parse).ToArray();
    bool conditionsFilled = true;
    bool isIncreasing = numbers[0] < numbers[1];
    for (int i = 1; i < numbers.Length; i++)
    {
        var diff = Math.Abs(numbers[i - 1] - numbers[i]);
        if (!((diff >= 1 && diff <= 3) &&
            ((isIncreasing && numbers[i - 1] < numbers[i]) ||
            (!isIncreasing && numbers[i - 1] > numbers[i]))))
        {
            conditionsFilled = false;
            break;
        }
    }
    if (conditionsFilled)
        safeCount++;
}
Console.WriteLine(safeCount);