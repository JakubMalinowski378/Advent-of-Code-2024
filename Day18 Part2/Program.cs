var data = File.ReadAllLines("input.txt")
    .Select(x => x.Split(',').Select(int.Parse).ToArray()).ToArray();
const int n = 71;
var map = new char[n, n];
int left = 0, right = data.Length - 1;
while (left < right)
{
    int mid = (left + right) / 2;
    for (int i = left; i <= mid; i++)
    {
        map[data[i][1], data[i][0]] = '#';
    }
    if (IsReachable((0, 0), (n - 1, n - 1)))
    {
        left = mid + 1;
    }
    else
    {
        for (int i = (left + mid) / 2; i <= mid; i++)
        {
            map[data[i][1], data[i][0]] = '\0';
        }
        right = mid - 1;
    }
}
Console.WriteLine($"{data[left][0]},{data[left][1]}");

bool IsReachable((int x, int y) start, (int x, int y) destination)
{
    var queue = new Queue<(int x, int y)>();
    queue.Enqueue(start);
    var visited = new HashSet<(int x, int y)>() { start };
    while (queue.Count > 0)
    {
        var current = queue.Dequeue();

        if (current == destination)
            return true;

        if (current.x + 1 < n &&
           !visited.Contains((current.x + 1, current.y)) &&
           map[current.y, current.x + 1] != '#')
        {
            visited.Add((current.x + 1, current.y));
            queue.Enqueue((current.x + 1, current.y));
        }

        if (current.y + 1 < n &&
            !visited.Contains((current.x, current.y + 1)) &&
            map[current.y + 1, current.x] != '#')
        {
            visited.Add((current.x, current.y + 1));
            queue.Enqueue((current.x, current.y + 1));
        }

        if (current.x - 1 >= 0 &&
            !visited.Contains((current.x - 1, current.y)) &&
            map[current.y, current.x - 1] != '#')
        {
            visited.Add((current.x - 1, current.y));
            queue.Enqueue((current.x - 1, current.y));
        }

        if (current.y - 1 >= 0 &&
             !visited.Contains((current.x, current.y - 1)) &&
             map[current.y - 1, current.x] != '#')
        {
            visited.Add((current.x, current.y - 1));
            queue.Enqueue((current.x, current.y - 1));
        }
    }
    return false;
}
