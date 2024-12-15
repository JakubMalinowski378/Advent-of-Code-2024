var map = File.ReadAllLines("input.txt");
var seen = new HashSet<(int x, int y)>();
var queue = new Queue<(int x, int y)>();
int area = 0, perimeter = 0, result = 0, n = map.Length, m = map[0].Length;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (seen.Contains((j, i))) continue;
        queue.Enqueue((j, i));
        seen.Add((j, i));
        var currentLetter = map[i][j];
        while (queue.Count != 0)
        {
            var (x, y) = queue.Dequeue();
            area++;
            if (y - 1 >= 0 && map[y - 1][x] == currentLetter)
            {
                if (!seen.Contains((x, y - 1)))
                {
                    seen.Add((x, y - 1));
                    queue.Enqueue((x, y - 1));
                }
            }
            else
            {
                perimeter++;
            }

            if (y + 1 < n && map[y + 1][x] == currentLetter)
            {
                if (!seen.Contains((x, y + 1)))
                {
                    seen.Add((x, y + 1));
                    queue.Enqueue((x, y + 1));
                }
            }
            else
            {
                perimeter++;
            }

            if (x - 1 >= 0 && map[y][x - 1] == currentLetter)
            {
                if (!seen.Contains((x - 1, y)))
                {
                    seen.Add((x - 1, y));
                    queue.Enqueue((x - 1, y));
                }
            }
            else
            {
                perimeter++;
            }

            if (x + 1 < m && map[y][x + 1] == currentLetter)
            {
                if (!seen.Contains((x + 1, y)))
                {
                    seen.Add((x + 1, y));
                    queue.Enqueue((x + 1, y));
                }
            }
            else
            {
                perimeter++;
            }
        }
        result += (perimeter * area);
        area = 0;
        perimeter = 0;
        Console.WriteLine();
    }
}
Console.WriteLine(result);