using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray()).ToArray();
(int x, int y) startPosition = (0, 0);
var startDirection = Direction.Up;
int n = map.Length;
int m = map[0].Length;
for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map[0].Length; j++)
    {
        if (map[i][j] == '^')
        {
            startPosition = (j, i);
            break;
        }
    }
}

int obstacleCounter = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (map[i][j] != '.') continue;
        map[i][j] = '#';
        if (IsInLoop())
            obstacleCounter++;
        map[i][j] = '.';
    }
}
Console.WriteLine(obstacleCounter);

bool IsInLoop()
{
    var visited = new HashSet<(int, int, Direction)>();
    var state = (startPosition.x, startPosition.y, startDirection);
    while (true)
    {
        if (visited.Contains(state))
            return true;
        visited.Add(state);
        var nextX = state.x;
        var nextY = state.y;

        if (state.Item3 == Direction.Up) nextY--;
        else if (state.Item3 == Direction.Down) nextY++;
        else if (state.Item3 == Direction.Right) nextX++;
        else nextX--;

        if (nextX < 0 || nextX >= m || nextY < 0 || nextY >= n)
            return false;

        if (map[nextY][nextX] == '#')
        {
            state.Item3 = (Direction)(((int)state.Item3 + 1) % 4);
        }
        else
        {
            state = (nextX, nextY, state.Item3);
        }

    }
}
public enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}