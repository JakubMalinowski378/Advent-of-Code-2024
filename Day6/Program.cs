using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n").Select(x => x.ToCharArray()).ToArray();
(int x, int y) position = (0, 0);
var direction = Direction.Up;
int n = map.Length;
int m = map[0].Length;
for (int i = 0; i < map.Length; i++)
{
    for (int j = 0; j < map[0].Length; j++)
    {
        if (map[i][j] == '^')
        {
            position = (j, i);
            break;
        }
    }
}

while (position.x != 0 && position.x != m - 1 && position.y != 0 && position.y != n - 1)
{
    switch (direction)
    {
        case Direction.Up:
            for (int i = position.y; i >= 0; i--)
            {
                if (map[i][position.x] == '#')
                {
                    position = (position.x, i + 1);
                    direction = Direction.Right;
                    break;
                }
                else
                {
                    map[i][position.x] = 'X';
                    position = (position.x, i);
                }
            }
            break;
        case Direction.Down:
            for (int i = position.y; i < n; i++)
            {
                if (map[i][position.x] == '#')
                {
                    position = (position.x, i - 1);
                    direction = Direction.Left;
                    break;
                }
                else
                {
                    map[i][position.x] = 'X';
                    position = (position.x, i);
                }
            }
            break;
        case Direction.Right:
            for (int i = position.x; i < m; i++)
            {
                if (map[position.y][i] == '#')
                {
                    position = (i - 1, position.y);
                    direction = Direction.Down;
                    break;
                }
                else
                {
                    map[position.y][i] = 'X';
                    position = (i, position.y);
                }
            }
            break;
        case Direction.Left:
            for (int i = position.x; i >= 0; i--)
            {
                if (map[position.y][i] == '#')
                {
                    position = (i + 1, position.y);
                    direction = Direction.Up;
                    break;
                }
                else
                {
                    map[position.y][i] = 'X';
                    position = (i, position.y);
                }
            }
            break;
    }
}

Console.WriteLine(map.Sum(x => x.Count(y => y == 'X')));

internal enum Direction
{
    Up,
    Right,
    Down,
    Left
}