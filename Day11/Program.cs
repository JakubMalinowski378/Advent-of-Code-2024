using var streamReader = new StreamReader("input.txt");
var stones = streamReader.ReadLine()!.Split(" ").Select(ulong.Parse).ToList();
var cache = new Dictionary<(ulong, int), ulong>();
int blinkCount = 75;
ulong result = 0;
foreach (var stone in stones)
{
    result += Ans(stone, blinkCount);
}
Console.WriteLine(result);

ulong Ans(ulong x, int n)
{
    if (n == 0)
        return 1;
    if (!cache.ContainsKey((x, n)))
    {
        ulong result;
        var xAsString = x.ToString();
        if (x == 0)
            result = Ans(1, n - 1);
        else if (xAsString.Length % 2 == 0)
        {
            result = Ans(ulong.Parse(xAsString[..(xAsString.Length / 2)]), n - 1);
            result += Ans(ulong.Parse(xAsString[(xAsString.Length / 2)..]), n - 1);
        }
        else
        {
            result = Ans(2024 * x, n - 1);
        }
        cache[(x, n)] = result;
    }
    return cache[(x, n)];
}