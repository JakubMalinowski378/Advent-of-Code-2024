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
try
{


    while (!((position.x == 0 && direction == Direction.Left) ||
        (position.x == m - 1 && direction == Direction.Right) ||
        (position.y == 0 && direction == Direction.Up) ||
        (position.y == n - 1 && direction == Direction.Down)))
    {
        switch (direction)
        {
            case Direction.Up:
                while (map[position.y][position.x] != '#')
                {
                    map[position.y][position.x] = 'X';
                    position = (position.x, position.y - 1);
                }
                position = (position.x, position.y + 1);
                direction = Direction.Right;
                break;
            case Direction.Down:
                while (map[position.y][position.x] != '#')
                {
                    map[position.y][position.x] = 'X';
                    position = (position.x, position.y + 1);
                }
                position = (position.x, position.y - 1);
                direction = Direction.Left;
                break;
            case Direction.Right:
                while (map[position.y][position.x] != '#')
                {
                    map[position.y][position.x] = 'X';
                    position = (position.x + 1, position.y);
                }
                position = (position.x - 1, position.y);
                direction = Direction.Down;
                break;
            case Direction.Left:
                while (map[position.y][position.x] != '#')
                {
                    map[position.y][position.x] = 'X';
                    position = (position.x - 1, position.y);
                }
                position = (position.x + 1, position.y);
                direction = Direction.Up;
                break;
        }
    }
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine(map.Sum(x => x.Count(y => y == 'X')));
}
public enum Direction
{
    Up,
    Right,
    Down,
    Left
}