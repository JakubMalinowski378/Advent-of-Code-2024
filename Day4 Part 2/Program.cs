using var streamReader = new StreamReader("input.txt");
var map = streamReader.ReadToEnd().Split("\r\n");
int n = map.Length;
int m = map[0].Length;
int xmasCounter = 0;

for (int i = 1; i < n - 1; i++)
{
    for (int j = 1; j < m - 1; j++)
    {
        if (map[i][j] == 'A' &&
            (((map[i - 1][j - 1] == 'M' && map[i + 1][j + 1] == 'S') ||
              (map[i - 1][j - 1] == 'S' && map[i + 1][j + 1] == 'M')) &&
              ((map[i + 1][j - 1] == 'M' && map[i - 1][j + 1] == 'S') ||
              (map[i + 1][j - 1] == 'S' && map[i - 1][j + 1] == 'M'))))
            xmasCounter++;
    }
}
Console.WriteLine(xmasCounter);