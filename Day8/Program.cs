using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n");
var antennasLocations = new Dictionary<char, List<(int x, int y)>>();
int n = map.Length;
int m = map[0].Length;

for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map[0].Length; j++)
    {
        var item = map[i][j];
        if (item == '.') continue;
        if (antennasLocations.TryGetValue(item, out var locations))
            locations.Add((j, i));
        else
            antennasLocations[item] = [(j, i)];
    }
}

var antiNodesLocations = new HashSet<(int, int)>();

foreach (var kv in antennasLocations)
{
    var locations = kv.Value;
    for (int i = 0; i < locations.Count; i++)
    {
        for (int j = i + 1; j < locations.Count; j++)
        {
            var (dx, dy) = CountPointsDistance(locations[i], locations[j]);

            var location1 = (locations[i].x + dx, locations[i].y + dy);
            var location2 = (locations[j].x - dx, locations[j].y - dy);

            if (location1.Item1 >= 0 && location1.Item1 < m &&
                location1.Item2 >= 0 && location1.Item2 < n)
                antiNodesLocations.Add(location1);

            if (location2.Item1 >= 0 && location2.Item1 < m &&
                location2.Item2 >= 0 && location2.Item2 < n)
                antiNodesLocations.Add(location2);
        }
    }
}

Console.WriteLine(antiNodesLocations.Count);

static (int dx, int dy) CountPointsDistance((int x, int y) point1, (int x, int y) point2)
{
    return (point1.x - point2.x, point1.y - point2.y);
}