Console.WriteLine("Begin");

int val = 50;
int zeroes = 0;

foreach (String line in File.ReadLines("input.txt"))
{
    char c = line[0];
    int shift = Int32.Parse(line.Substring(1));
    switch (c) {
        case 'L':
            val -= shift;
            break;
        case 'R':
            val += shift;
            break;
        default:
            Console.WriteLine("unexpected line: " + line);
            break;
    }

    val = val % 100;

    if (val == 0) {  zeroes++; }

}

Console.WriteLine("zeroes found: " + zeroes.ToString());

return;