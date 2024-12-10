using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n").ToArray();
int trailHeadRating = 0;
int n = map.Length;
int m = map[0].Length;
var adjacencyList = CreateAdjacencyArray();

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (map[i][j] == '0')
        {
            trailHeadRating += Dfs((i, j), []);
        }
    }
}
Console.WriteLine(trailHeadRating);

List<(int, int)>[,] CreateAdjacencyArray()
{
    var adjacencyArray = new List<(int, int)>[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            adjacencyArray[i, j] = [];
            if (i - 1 >= 0 && map[i - 1][j] - 1 == map[i][j])
                adjacencyArray[i, j].Add((i - 1, j));
            if (i + 1 < n && map[i + 1][j] - 1 == map[i][j])
                adjacencyArray[i, j].Add((i + 1, j));
            if (j - 1 >= 0 && map[i][j - 1] - 1 == map[i][j])
                adjacencyArray[i, j].Add((i, j - 1));
            if (j + 1 < m && map[i][j + 1] - 1 == map[i][j])
                adjacencyArray[i, j].Add((i, j + 1));
        }
    }
    return adjacencyArray;
}

int Dfs((int i, int j) current, HashSet<(int i, int j)> visited)
{
    if (map[current.i][current.j] == '9')
        return 1;

    visited.Add(current);
    int pathCount = 0;
    foreach (var neighbour in adjacencyList[current.i, current.j])
    {
        if (!visited.Contains(neighbour))
            pathCount += Dfs(neighbour, visited);
    }
    visited.Remove(current);

    return pathCount;
}