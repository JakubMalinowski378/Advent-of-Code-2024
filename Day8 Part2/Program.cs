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

            for (var currentLocation = (locations[i].x, locations[i].y);
                currentLocation.x >= 0 && currentLocation.x < m &&
                    currentLocation.y >= 0 && currentLocation.y < n;
                    currentLocation.x += dx, currentLocation.y += dy)
            {
                antiNodesLocations.Add(currentLocation);
            }

            for (var currentLocation = (locations[j].x, locations[j].y);
                currentLocation.x >= 0 && currentLocation.x < m &&
                    currentLocation.y >= 0 && currentLocation.y < n;
                    currentLocation.x -= dx, currentLocation.y -= dy)
            {
                antiNodesLocations.Add(currentLocation);
            }
        }
    }
}

Console.WriteLine(antiNodesLocations.Count);

static (int dx, int dy) CountPointsDistance((int x, int y) point1, (int x, int y) point2)
{
    return (point1.x - point2.x, point1.y - point2.y);
}