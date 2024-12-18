var data = File.ReadAllLines("input.txt");
const int n = 71;
var map = new char[n, n];
const int CORRUPTED_BITS = 1024;
for (int i = 0; i < CORRUPTED_BITS; i++)
{
    var parsedDataLine = data[i].Split(',').Select(int.Parse).ToArray();
    map[parsedDataLine[1], parsedDataLine[0]] = '#';
}
Console.WriteLine(Bfs((0, 0), (n - 1, n - 1)));

int Bfs((int x, int y) start, (int x, int y) destination)
{
    var queue = new Queue<((int x, int y), int steps)>();
    queue.Enqueue((start, 0));
    var visited = new HashSet<(int x, int y)>() { start };
    while (queue.Count > 0)
    {
        var (current, steps) = queue.Dequeue();

        if (current == destination)
            return steps;

        if (current.x + 1 < n &&
           !visited.Contains((current.x + 1, current.y)) &&
           map[current.y, current.x + 1] != '#')
        {
            visited.Add((current.x + 1, current.y));
            queue.Enqueue(((current.x + 1, current.y), steps + 1));
        }

        if (current.y + 1 < n &&
            !visited.Contains((current.x, current.y + 1)) &&
            map[current.y + 1, current.x] != '#')
        {
            visited.Add((current.x, current.y + 1));
            queue.Enqueue(((current.x, current.y + 1), steps + 1));
        }

        if (current.x - 1 >= 0 &&
            !visited.Contains((current.x - 1, current.y)) &&
            map[current.y, current.x - 1] != '#')
        {
            visited.Add((current.x - 1, current.y));
            queue.Enqueue(((current.x - 1, current.y), steps + 1));
        }

        if (current.y - 1 >= 0 &&
             !visited.Contains((current.x, current.y - 1)) &&
             map[current.y - 1, current.x] != '#')
        {
            visited.Add((current.x, current.y - 1));
            queue.Enqueue(((current.x, current.y - 1), steps + 1));
        }
    }
    return -1;
}
