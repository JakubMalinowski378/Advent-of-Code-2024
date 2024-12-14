using var streamReader = new StreamReader("input.txt");
string line;
var robots = new List<Robot>();
int mapHeight = 103, mapWidth = 101;
var robotsInEachQuadrant = new int[4];
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
foreach (var robot in robots)
{
    int x = (((robot.X + 100 * robot.Dx) % mapWidth) + mapWidth) % mapWidth;
    int y = (((robot.Y + 100 * robot.Dy) % mapHeight) + mapHeight) % mapHeight;
    if (x < mapWidth / 2 && y < mapHeight / 2)
        robotsInEachQuadrant[0]++;
    else if (x > mapWidth / 2 && y < mapHeight / 2)
        robotsInEachQuadrant[1]++;
    else if (x < mapWidth / 2 && y > mapHeight / 2)
        robotsInEachQuadrant[2]++;
    else if (x > mapWidth / 2 && y > mapHeight / 2)
        robotsInEachQuadrant[3]++;
}
Console.WriteLine(robotsInEachQuadrant[0] *
    robotsInEachQuadrant[1] *
    robotsInEachQuadrant[2] *
    robotsInEachQuadrant[3]);

internal class Robot(int x, int y, int dx, int dy)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Dx { get; set; } = dx;
    public int Dy { get; set; } = dy;
}