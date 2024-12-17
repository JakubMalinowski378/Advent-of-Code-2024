using var streamReader = new StreamReader("input.txt");
string line;
var map = new List<char[]>();
string moves = string.Empty;
while ((line = streamReader.ReadLine()!) != string.Empty)
    map.Add(string.Join("", line
        .Select(x =>
        {
            return x switch
            {
                '#' => "##",
                'O' => "[]",
                '.' => "..",
                '@' => "@.",
                _ => string.Empty,
            };
        }))
        .ToCharArray());
while ((line = streamReader.ReadLine()!) != null)
    moves += line;
int n = map.Count, m = map[0].Length;
int x = 0, y = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (map[i][j] == '@')
        {
            map[i][j] = '.';
            x = j;
            y = i;
            break;
        }
    }
}
HashSet<char> boxes = ['[', ']'];
foreach (var move in moves)
{
    int swapX = x, swapY = y;
    switch (move)
    {
        case '^':
            if (y == 1)
                continue;
            swapY--;
            if (map[swapY][swapX] == '#')
                continue;
            if (map[swapY][swapX] == '.' || map[swapY][swapX] == '#')
            {
                y--;
                continue;
            }
            if (MoveVerticalIfPossible(swapX, swapY, -1))
                y--;
            break;
        case '>':
            swapX++;
            if (map[swapY][swapX] == '.')
            {
                x++;
                continue;
            }
            while (boxes.Contains(map[swapY][swapX]))
            {
                swapX++;
            }
            if (map[swapY][swapX] == '.')
            {
                var odd = true;
                for (int i = x + 2; i <= swapX; i++)
                {
                    map[y][i] = odd ? '[' : ']';
                    odd ^= true;
                }
                x++;
                map[y][x] = '.';
            }
            break;
        case '<':
            swapX--;
            if (map[swapY][swapX] == '.')
            {
                x--;
                continue;
            }
            while (boxes.Contains(map[swapY][swapX]))
            {
                swapX--;
            }
            if (map[swapY][swapX] == '.')
            {
                var odd = false;
                for (int i = x - 2; i >= swapX; i--)
                {
                    map[y][i] = odd ? '[' : ']';
                    odd ^= true;
                }
                x--;
                map[y][x] = '.';
            }
            break;
        case 'v':
            if (y == n - 2)
                continue;
            swapY++;
            if (map[swapY][swapX] == '#')
                continue;
            if (map[swapY][swapX] == '.')
            {
                y++;
                continue;
            }
            if (MoveVerticalIfPossible(swapX, swapY, 1))
                y++;
            break;
    }
}

int result = 0;
for (int i = 1; i < n - 1; i++)
{
    for (int j = 1; j < m - 1; j++)
    {
        if (map[i][j] == '[')
            result += 100 * i + j;
    }
}
Console.WriteLine(result);

bool MoveVerticalIfPossible(int x, int y, int dy)
{
    var secondPoint = (map[y][x] == '[' ? x + 1 : x - 1, y);
    var visited = new HashSet<(int x, int y)>([(x, y), secondPoint]);
    var queue = new Queue<(int x, int y)>();
    queue.Enqueue((x, y));
    queue.Enqueue(secondPoint);
    while (queue.Count > 0)
    {
        var (cx, cy) = queue.Dequeue();
        switch (map[cy + dy][cx])
        {
            case '#':
                return false;
            case '[':
                queue.Enqueue((cx, cy + dy));
                queue.Enqueue((cx + 1, cy + dy));
                visited.Add((cx, cy + dy));
                visited.Add((cx + 1, cy + dy));
                break;
            case ']':
                queue.Enqueue((cx, cy + dy));
                queue.Enqueue((cx - 1, cy + dy));
                visited.Add((cx, cy + dy));
                visited.Add((cx - 1, cy + dy));
                break;
        }
    }
    var points = new List<(int x, int y)>(visited);
    if (dy == -1) points = [.. points.OrderBy(x => x.y)];
    else points = [.. points.OrderByDescending(x => x.y)];
    foreach (var (px, py) in points)
    {
        var currentChar = map[py][px];
        map[py + dy][px] = currentChar;
        map[py][px] = '.';
    }
    return true;
}
