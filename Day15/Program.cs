using var streamReader = new StreamReader("input.txt");
string line;
var map = new List<char[]>();
string moves = string.Empty;
while ((line = streamReader.ReadLine()!) != string.Empty)
    map.Add(line.ToCharArray());
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
foreach (var move in moves)
{
    int swapX = x, swapY = y;
    switch (move)
    {
        case '^':
            swapY--;
            if (map[swapY][swapX] == '.')
            {
                y--;
                continue;
            }
            while (map[swapY][swapX] == 'O')
            {
                swapY--;
            }
            if (map[swapY][swapX] == '.')
            {
                map[swapY][swapX] = 'O';
                y--;
                map[y][x] = '.';
            }
            break;
        case '>':
            swapX++;
            if (map[swapY][swapX] == '.')
            {
                x++;
                continue;
            }
            while (map[swapY][swapX] == 'O')
            {
                swapX++;
            }
            if (map[swapY][swapX] == '.')
            {
                map[swapY][swapX] = 'O';
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
            while (map[swapY][swapX] == 'O')
            {
                swapX--;
            }
            if (map[swapY][swapX] == '.')
            {
                map[swapY][swapX] = 'O';
                x--;
                map[y][x] = '.';
            }
            break;
        case 'v':
            swapY++;
            if (map[swapY][swapX] == '.')
            {
                y++;
                continue;
            }
            while (map[swapY][swapX] == 'O')
            {
                swapY++;
            }
            if (map[swapY][swapX] == '.')
            {
                map[swapY][swapX] = 'O';
                y++;
                map[y][x] = '.';
            }
            break;
    }
}
int result = 0;
for (int i = 1; i < n - 1; i++)
{
    for (int j = 1; j < m - 1; j++)
    {
        if (map[i][j] == 'O')
            result += 100 * i + j;
    }
}
Console.WriteLine(result);