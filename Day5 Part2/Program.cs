using var streamReader = new StreamReader("input.txt");
string line;
var pageOrderingRules = new Dictionary<int, HashSet<int>>();
while ((line = streamReader.ReadLine()!) != string.Empty)
{
    var splittedValues = line.Split('|').Select(int.Parse).ToArray();
    if (pageOrderingRules.TryGetValue(splittedValues[0], out var hashset))
        hashset.Add(splittedValues[1]);
    else
        pageOrderingRules[splittedValues[0]] = [splittedValues[1]];
}
var updates = new List<int[]>();
while ((line = streamReader.ReadLine()!) != null)
{
    updates.Add(line.Split(',').Select(int.Parse).ToArray());
}
int sum = 0;
foreach (var update in updates)
{
    bool hasBeenFixed = false;
    int n = update.Length;
    for (int i = 1; i < n; i++)
    {
        var isInPageOrdering = pageOrderingRules.TryGetValue(update[i], out var cantAppearBefore);
        if (!isInPageOrdering)
            continue;
        var intersection = update[..i].Intersect(cantAppearBefore!).ToArray();
        if (intersection.Length > 0)
        {
            hasBeenFixed = true;
            int j = Array.IndexOf(update, intersection[0]);
            (update[i], update[j]) = (update[j], update[i]);
            i = j - 1;
        }
    }
    if (hasBeenFixed)
        sum += update[n / 2];
}
Console.WriteLine(sum);