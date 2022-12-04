using System;

int charToValue(char c)
{
	return Char.IsUpper(c) ? (c - 'A') + 27 : (c - 'a') + 1;
}

int total = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	// Store all char appearances of left side
	HashSet<char> exists = new HashSet<char>();
	for (int i = 0; i < line.Length / 2; i++)
	{
		exists.Add(line[i]);
	}

	// Find shared char in right side
	for (int i = line.Length / 2; i < line.Length; i++)
	{
		if (exists.Contains(line[i]))
		{
			total += charToValue(line[i]);
			break;
		}
	}
}

Console.WriteLine(total);