using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n").ToArray();
int trailHeadCounter = 0;
int n = map.Length;
int m = map[0].Length;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (map[i][j] == '0')
            trailHeadCounter += FindTrailHeadsCount(i, j);
    }
}
Console.WriteLine(trailHeadCounter);

int FindTrailHeadsCount(int i, int j)
{
    int counter = 0;
    var stack = new Stack<(int a, int b)>();
    stack.Push((i, j));
    var visited = new HashSet<(int a, int b)>() { (i, j) };
    int currentValue = '0';
    while (stack.Count != 0)
    {
        var (a, b) = stack.Pop();
        if (map[a][b] == '9')
        {
            counter++;
            continue;
        }
        if (map[a][b] != currentValue)
            currentValue = map[a][b];
        //right
        if (b + 1 < m && !visited.Contains((a, b + 1)) && map[a][b + 1] == currentValue + 1)
        {
            visited.Add((a, b + 1));
            stack.Push((a, b + 1));
        }
        //left
        if (b - 1 >= 0 && !visited.Contains((a, b - 1)) && map[a][b - 1] == currentValue + 1)
        {
            visited.Add((a, b - 1));
            stack.Push((a, b - 1));
        }
        //up
        if (a - 1 >= 0 && !visited.Contains((a - 1, b)) && map[a - 1][b] == currentValue + 1)
        {
            visited.Add((a - 1, b));
            stack.Push((a - 1, b));
        }
        //down
        if (a + 1 < n && !visited.Contains((a + 1, b)) && map[a + 1][b] == currentValue + 1)
        {
            visited.Add((a + 1, b));
            stack.Push((a + 1, b));
        }
    }
    return counter;
}