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
int constructedWords = 0;
foreach (var word in words)
{
    if (CanConstruct(word))
        constructedWords++;
}
Console.WriteLine(constructedWords);

bool CanConstruct(string word)
{
    if (word == string.Empty)
        return true;
    for (int i = 0; i < word.Length; i++)
    {
        if (availablePatterns.Contains(word[..(i + 1)]) && CanConstruct(word[(i + 1)..]))
            return true;
    }
    return false;
}
