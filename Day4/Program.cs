using var streamReader = new StreamReader("input.txt");

var map = streamReader.ReadToEnd().Split("\r\n");
int n = map.Length;
int m = map[0].Length;
int xmasCounter = 0;
string[] correctWords = ["XMAS", "SAMX"];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (j < m - 3)
        {
            var horizontalString = map[i][j..(j + 4)];
            if (correctWords.Contains(horizontalString))
                xmasCounter++;
        }
        if (i < n - 3)
        {
            var verticalString = $"{map[i][j]}{map[i + 1][j]}{map[i + 2][j]}{map[i + 3][j]}";
            if (correctWords.Contains(verticalString))
                xmasCounter++;
        }
        if (i < n - 3 && j < m - 3)
        {
            var diagonalString = $"{map[i][j]}{map[i + 1][j + 1]}{map[i + 2][j + 2]}{map[i + 3][j + 3]}";
            if (correctWords.Contains(diagonalString))
                xmasCounter++;

        }
        if (j >= 3 && i < n - 3)
        {
            var reverseeDiagonalString = $"{map[i][j]}{map[i + 1][j - 1]}{map[i + 2][j - 2]}{map[i + 3][j - 3]}";
            if (correctWords.Contains(reverseeDiagonalString))
                xmasCounter++;
        }
    }
}

Console.WriteLine(xmasCounter);