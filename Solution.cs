using System;
using System.IO;

int max = -1;
int curr = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	// Empty line: Update max and reset elf count
	if (line.Length == 0)
	{
		max = Math.Max(max, curr);
		curr = 0;
		continue;
	}

	curr += Int32.Parse(line);
}

Console.WriteLine(max);