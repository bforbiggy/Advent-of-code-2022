using System;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

List<Monkey> monkeys = new List<Monkey>();

// Filter string to only include digits
string filterDigits(string input)
{
	var digitEnumerable = input.Where(c => Char.IsDigit(c));
	return new String(digitEnumerable.ToArray());
}

// Parse all monkeys
string[] lines = File.ReadAllLines("input.txt");
for (int i = 0; i < lines.Length; i += 7)
{
	// Determine monkey items
	List<int> items = new List<int>();
	foreach (string itemString in lines[i + 1].Split(","))
	{
		string filtered = filterDigits(itemString);
		int item = Int32.Parse(filtered);
		items.Add(item);
	}

	// Determine monkey operation
	Func<int, int> operation;
	if (lines[i + 2].Contains("*"))
	{
		// Hardcoded test for new = old * old;
		if (Regex.Matches(lines[i + 2], "old").Count == 2)
		{

		}
		else
		{
			int operationNum = Int32.Parse(filterDigits(lines[i + 2]));
			operation = (old) => old * operationNum;
		}
	}
	else if (lines[i + 2].Contains("+"))
	{
		int operationNum = Int32.Parse(filterDigits(lines[i + 2]));
		operation = (old) => old + operationNum;
	}
}