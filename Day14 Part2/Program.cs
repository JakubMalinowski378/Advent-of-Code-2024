using var streamReader = new StreamReader("input.txt");
string line;
var robots = new List<Robot>();
int mapHeight = 103, mapWidth = 101;
var charArray = new char[mapHeight, mapWidth];
while ((line = streamReader.ReadLine()!) != null)
{
    var data = line
        .Replace("p=", "")
        .Replace("v=", "")
        .Replace(",", " ")
        .Split(" ")
        .Select(int.Parse)
        .ToArray();
    robots.Add(new Robot(data[0], data[1], data[2], data[3]));
}
int iterations = 0;
while (true)
{
    var seen = new HashSet<(int, int)>();
    foreach (var robot in robots)
    {
        robot.X = (((robot.X + robot.Dx) % mapWidth) + mapWidth) % mapWidth;
        robot.Y = (((robot.Y + robot.Dy) % mapHeight) + mapHeight) % mapHeight;
        seen.Add((robot.X, robot.Y));
    }
    iterations++;
    if (seen.Count == robots.Count)
    {
        Console.WriteLine($"Iterations: {iterations}");
        foreach (var robot in robots)
            charArray[robot.Y, robot.X] = 'X';
        for (int j = 0; j < mapHeight; j++)
        {
            for (int k = 0; k < mapWidth; k++)
            {
                Console.Write(charArray[j, k] == '\0' ? " " : "X");
            }
            Console.Write('\n');
        }
        break;
    }
}


internal class Robot(int x, int y, int dx, int dy)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Dx { get; set; } = dx;
    public int Dy { get; set; } = dy;
}