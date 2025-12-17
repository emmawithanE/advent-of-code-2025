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

String Get2DigitNumber(String input)
{
    // Find the highest digit up to but not including the last one
    // Then append the highest digit after that

    //Console.WriteLine("Input line: " + input);

    (char highest, int index) = GetHighestCharAndIndex(input.Substring(0, input.Length - 1));

    (char second, int _) = GetHighestCharAndIndex(input.Substring(index + 1));

    return new String([highest, second]);
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

List<String> Get2DigitStrings(IEnumerable<String> input)
{
    List<String> list = new List<String>();

    foreach (String line in input)
    {
        list.Add(Get2DigitNumber(line));
    }

    return list;
}

Int64 SumOfStrings(List<String> input) { return input.Sum(str => ToInt(str)); }


void ASide(IEnumerable<String> input)
{
    Int64 sum = SumOfStrings(Get2DigitStrings(input));

    Console.WriteLine("Sum of 2 Digit Joltages: " + sum.ToString());
}



// *inhale*
// *exhale*
// okay now let's actually do the thing

ASide(GetInput());