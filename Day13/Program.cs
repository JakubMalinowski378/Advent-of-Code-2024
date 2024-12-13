using var streamReader = new StreamReader("input.txt");
var input = new List<Input>();
string line;
int result = 0;
while ((line = streamReader.ReadLine()!) != null)
{
    var line2 = streamReader.ReadLine();
    var line3 = streamReader.ReadLine();

    input.Add(new Input()
    {
        ButtonAdx = int.Parse(line[(line.IndexOf('X') + 2)..(line.IndexOf(','))]),
        ButtonAdy = int.Parse(line[(line.IndexOf('Y') + 2)..]),
        ButtonBdx = int.Parse(line2![(line2!.IndexOf('X') + 2)..(line2.IndexOf(','))]),
        ButtonBdy = int.Parse(line2[(line2.IndexOf('Y') + 2)..]),
        Destination = ((int.Parse(line3![(line3!.IndexOf('=') + 1)..line3.IndexOf(',')])),
        (int.Parse(line3[(line3.IndexOf('Y') + 2)..])))
    });
    _ = streamReader.ReadLine();
}
foreach (var inputLine in input)
{
    int D = inputLine.ButtonAdx * inputLine.ButtonBdy - inputLine.ButtonAdy * inputLine.ButtonBdx;
    if (D == 0)
        continue;

    int Dx = inputLine.Destination.x * inputLine.ButtonBdy - inputLine.Destination.y * inputLine.ButtonBdx;
    int Dy = inputLine.ButtonAdx * inputLine.Destination.y - inputLine.ButtonAdy * inputLine.Destination.x;

    double x = (double)Dx / D;
    double y = (double)Dy / D;
    if (x >= 0 && x <= 100 && y >= 0 && y <= 100)
    {
        result += (int)(x * 3 + y);
    }
}
Console.WriteLine(result);

internal class Input
{
    public int ButtonAdx { get; set; }
    public int ButtonAdy { get; set; }
    public int ButtonBdx { get; set; }
    public int ButtonBdy { get; set; }
    public (int x, int y) Destination { get; set; }
}
