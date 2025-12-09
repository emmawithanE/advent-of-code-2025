Console.WriteLine("Begin");

int val = 50;
int zeroes = 0;
int method_b = 0;

foreach (String line in File.ReadLines("input.txt"))
{
    char c = line[0];
    int shift = Int32.Parse(line.Substring(1));
    int passes = 0;
    int oldval = val;

    switch (c) {
        case 'L':
            bool started_from_zero = (val == 0);
            val -= shift;
            if (val <= 0)
            {
                passes = (val * -1 / 100);
                if (!started_from_zero)
                {
                    // count the extra 0 we got on the way
                    passes++;
                }

            }
            break;
        case 'R':
            val += shift;
            passes = (val / 100);
            break;
        default:
            Console.WriteLine("unexpected line: " + line);
            break;
    }

    // Console.WriteLine("shifting {0} from {1} to {2} ({3}), passes {4}", c, oldval, val, line, passes);

    val = val % 100;
    if ( val < 0 )
    {
        val += 100; // HATE HATE HATE
    }

    if (val == 0) {  zeroes++; }
    method_b += passes;

}

Console.WriteLine("zeroes found: " + zeroes.ToString());
Console.WriteLine("method 0x434C49434B zeroes found: " + method_b.ToString());

return;