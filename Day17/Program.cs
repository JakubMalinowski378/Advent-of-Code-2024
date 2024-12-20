using System.Text;

using var streamReader = new StreamReader("testinput.txt");
var registers = new int[3];
string line;
for (int i = 0; i < 3; i++)
{
    line = streamReader.ReadLine()!;
    registers[i] = int.Parse(line[12..]);
}
_ = streamReader.ReadLine();
line = streamReader.ReadLine()!;
var commands = line[9..]
    .Split(',')
    .Select(int.Parse)
    .ToArray();
int opCodeIndex = 0;
var sb = new StringBuilder();
while (opCodeIndex < commands.Length)
{
    int numerator, denominator;
    switch (commands[opCodeIndex])
    {
        case 0:
            numerator = registers[0];
            denominator = (int)Math.Pow(2, GetComboValue(commands[opCodeIndex + 1]));
            registers[0] = numerator / denominator;
            break;
        case 1:
            var xor = registers[1] ^ commands[opCodeIndex + 1];
            registers[1] = xor;
            break;
        case 2:
            registers[1] = GetComboValue(commands[opCodeIndex + 1]) % 8;
            break;
        case 3:
            if (registers[0] != 0)
            {
                if (commands[opCodeIndex + 1] != opCodeIndex)
                {
                    opCodeIndex = commands[opCodeIndex + 1];
                    continue;
                }
            }
            break;
        case 4:
            registers[1] = registers[1] ^ registers[2];
            break;
        case 5:
            var combo = GetComboValue(commands[opCodeIndex + 1]);
            sb.Append($"{combo % 8},");
            break;
        case 6:
            numerator = registers[0];
            denominator = (int)Math.Pow(2, GetComboValue(commands[opCodeIndex + 1]));
            registers[1] = numerator / denominator;
            break;
        case 7:
            numerator = registers[0];
            denominator = (int)Math.Pow(2, GetComboValue(commands[opCodeIndex + 1]));
            registers[2] = numerator / denominator;
            break;
    }
    opCodeIndex += 2;
}
Console.WriteLine(sb.ToString()[..^1]);

int GetComboValue(int n)
{
    if (n >= 0 && n <= 3)
        return n;
    if (n >= 4 && n <= 6)
        return registers[n - 4];
    throw new ArgumentException();
}