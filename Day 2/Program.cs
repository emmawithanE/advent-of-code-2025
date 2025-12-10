/*
Given ranges X-Y,
find the sum of all N where X <= N <= Y and N is made up of two repetitions of a set of digits

what are the possible spaces of N?
- must be even digits (no leading zeroes)
- if X and Y are even-digited:
  - if X is the number AB, and Y is CD, then AA is a possible solution if B < A (and CC is a solution if D > C)
  - is BB possible? yes, if it would be less than CD, but we have no guarantees there
  - similar applies to DD
  - intermediate solutions exist - (A+1)(A+1) will be a solution if less than CD

  - wait im just thinking about this wrong aren't i lmao
  - if we start at AA (or (A+1)(A+1) and continue to go up until we are above CD, that just finds all of them
  - we don't need to care about digits bc we will wrap from, eg. 88, 99, 1010, skipping all odd digit numbers in the way
- if X is odd:
  - start from the next even candidate up
  - eg. X = 7, next candidate is 11 (AA, A = 1)
- if Y is odd:
  - doesn't matter we'll still go from N <= Y to N > Y at some point
*/

// now, how do we get our input and split on commas?

using System.Numerics;

String input = File.ReadAllText("input.txt");

List<long> invalids = new List<long>();

long CalculateAA(long a)
{
    // construct aa, which is a + (a but shifted up by length digits)
    return a + a * (int)Math.Pow(10, Math.Ceiling(Math.Log10((float)a + 0.5))); // do NOT look at what i am doing at the end here (to deal with a being an exact multiple of 10)
}

foreach (var range in input.Split(','))
{
    var values = range.Split('-');
    String lower = values[0];
    String upper = values[1];

    // Construct starting value of A (of AA fame)
    long a;
    if (lower.Length % 2 != 0)
    {
        // lower is odd length, start at A = 1(0)N, where N is such that total digits is half the length of lower (rounded up)
        // (which is 10 ^ length / 2 rounded down?

        a = (long)Math.Pow(10, (lower.Length / 2));
    }
    else
    {
        a = Int64.Parse(lower.Substring(0, lower.Length / 2));
        var b = Int64.Parse(lower.Substring(lower.Length / 2));

        if (b > a)
        {
            a++;
        }
    }

    long upper_val = Int64.Parse(upper);

    long aa = CalculateAA(a);

    // Console.WriteLine("{0} gives a={1}, aa={2}", range, a, aa);

    Console.WriteLine("range: " + range);

    while (aa <= upper_val)
    {
        Console.WriteLine("   id: {0}", aa);
        invalids.Add(aa);
        a++;
        aa = CalculateAA(a);

    }
}

Console.WriteLine("found {0} invalid ids with a sum of {1}", invalids.Count(), invalids.Sum());