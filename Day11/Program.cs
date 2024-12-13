using var streamReader = new StreamReader("input.txt");
var stones = streamReader.ReadLine()!.Split(" ").Select(ulong.Parse).ToList();
var cache = new Dictionary<ulong, ulong>() { { 0, 1 } };
int blinkCount = 25;
ulong result = 0;
foreach (var stone in stones)
{
    //result += Blink([stone]);
}
Console.WriteLine(stones.Count);

/*ulong Blink(ulong[] stones)
{
    foreach (var stone in stones)
    {
        if (cache.TryGetValue(stone, out var result))
            return result;
        if (stone == 0)
        {
            return 1;
        }
        var asString = stone.ToString();
        if (asString.Length % 2 == 0)
        {
            stones[i] = ulong.Parse(asString[..(asString.Length / 2)]);
            stones.Add(ulong.Parse(asString[(asString.Length / 2)..]));
            continue;
        }
        stones[i] *= 2024;
    }
}*/