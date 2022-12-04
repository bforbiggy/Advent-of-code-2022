using System;
using System.IO;

long max = -1;
long curr = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	// Empty line: Update max and reset elf count
	if (line.Length == 0)
	{
		max = Math.Max(max, curr);
		curr = 0;
		continue;
	}

	curr += long.Parse(line);
}

Console.WriteLine(max);