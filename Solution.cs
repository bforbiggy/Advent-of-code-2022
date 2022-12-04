using System;
using System.IO;

List<long> top = new List<long>(3);

// Update calorie leaderboard with new score
void parseMax(long num)
{
	// If leaderboard is too small, just add element
	if (top.Count < 3)
	{
		top.Add(num);
		top.Sort();
		return;
	}

	// Update leaderboard if num is big enough
	if (num > top[0])
	{
		top[0] = num;
		top.Sort();
	}
}

// Retrieve each elf's total calorie count
long curr = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	// Empty line: Update max and reset elf count
	if (line.Length == 0)
	{
		parseMax(curr);
		curr = 0;
		continue;
	}

	// Calorie Count: Add to current elf's total
	curr += long.Parse(line);
}

// Sum up top elf's calorie counts
long total = 0;
foreach (long calorie in top)
	total += calorie;
Console.WriteLine(total);