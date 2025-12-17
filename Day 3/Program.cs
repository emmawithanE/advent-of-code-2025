/*

Okay, let's try to write some more reusable code this time lmao

given a string of digits, find the greatest 2 digit number you can make by taking digits in order
eg. 1234567890 -> 90

How do you find the highest number?
- the highest digit that isn't the last one must be first (eg. an 8 as the first digit beats anything that starts with a 7)
- the second digit must be the highest digit after that

unfortunately i am cheating a little in that i have seen what the B side is for today bc a friend was complaining about it lmao

at the end we sum all of them so we do need ints at that point, but until then i don't actually care about the numbers themselves ngl, it's just easier to pass around strings and substrings
is a C# string an array of characters? can i iterate through it? let's see!
*/

using System.Runtime.CompilerServices;

IEnumerable<String> GetInput()
{
    return File.ReadLines("Input.txt"); // I wonder if this is something I can have as like a library that this whole solution accesses? idk i should learn how to write C#
}

String GetNDigitNumber(String input, int digits)
{
    // Find the highest digit that lets us still make a complete number
    // Then append digits after that

    //Console.WriteLine("Input line: " + input);

    List<char> chars = new List<char>();
    int digits_remaining = digits;
    int index = 0;

    while (digits_remaining > 0)
    {
        String substring = input.Substring(index, input.Length - (index + digits_remaining - 1));
        (char highest, int relative_index) = GetHighestCharAndIndex(substring);
        index += relative_index + 1;
        chars.Add(highest);
        digits_remaining--;
    }

    return new String(chars.ToArray());
}

(char, int) GetHighestCharAndIndex(String input)
{
    // get the highest character in a string
    // return what the character is and also where we found it, so the function that called us can find characters behind us next time

    //Console.WriteLine("  Getting highest digit in " + input);

    char highest = '0';
    int index = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] > highest)
        {
            highest = input[i];
            index = i;
        }
    }

    // Console.WriteLine("  Found {0} at index {1}", highest, index);
    return (highest, index);
}

Int64 ToInt(String input) { return Int64.Parse(input); }

List<String> GetNDigitStrings(IEnumerable<String> input, int digits)
{
    List<String> list = new List<String>();

    foreach (String line in input)
    {
        list.Add(GetNDigitNumber(line, digits));
    }

    return list;
}

Int64 SumOfStrings(List<String> input) { return input.Sum(str => ToInt(str)); }


void ProcessAndPrintNDigits(IEnumerable<String> input, int digits)
{
    Int64 sum = SumOfStrings(GetNDigitStrings(input, digits));

    Console.WriteLine("Sum of {0} Digit Joltages: {1}", digits, sum);
}



void ASide(IEnumerable<String> input)
{
    ProcessAndPrintNDigits(input, 2);
}

void BSide(IEnumerable<String> input)
{
    ProcessAndPrintNDigits(input, 12);
}



// *inhale*
// *exhale*
// okay now let's actually do the thing

ASide(GetInput());

BSide(GetInput());