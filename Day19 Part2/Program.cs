using var streamReader = new StreamReader("input.txt");

var availablePatterns = streamReader.ReadLine()!
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToHashSet();
string line;
_ = streamReader.ReadLine();
var words = new List<string>();
while ((line = streamReader.ReadLine()!) != null)
{
    words.Add(line);
}
long waysToConstructWords = 0;
foreach (var word in words)
{
    waysToConstructWords += WaysToConstructWord(word);
}
Console.WriteLine(waysToConstructWords);

long WaysToConstructWord(string word)
{
    var cache = new Dictionary<string, long>();
    return CountWays(word);

    long CountWays(string currentWord)
    {
        if (currentWord == string.Empty)
        {
            return 1;
        }
        if (cache.ContainsKey(currentWord))
        {
            return cache[currentWord];
        }
        long counter = 0;
        foreach (var pattern in availablePatterns)
        {
            if (currentWord.StartsWith(pattern))
            {
                counter += CountWays(currentWord[pattern.Length..]);
            }
        }
        cache[currentWord] = counter;
        return counter;
    }
}
