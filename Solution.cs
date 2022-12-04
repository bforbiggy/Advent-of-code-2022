using System;

int charToValue(char c)
{
	return Char.IsUpper(c) ? (c - 'A') + 27 : (c - 'a') + 1;
}

int total = 0;

string[] lines = File.ReadAllLines("input.txt");
for (int i = 0; i < lines.Length; i += 3)
{
	Dictionary<char, int> shared = new Dictionary<char, int>();

	for (int j = i; j < i + 3; j++)
	{
		HashSet<char> set = new HashSet<char>();
		foreach (char c in lines[j])
		{
			// New characters are tracked
			if (!set.Contains(c))
			{
				shared[c] = shared.GetValueOrDefault(c, 0) + 1;
				set.Add(c);
			}
		}
	}

	foreach (KeyValuePair<char, int> entry in shared)
	{
		if (entry.Value == 3)
		{
			total += charToValue(entry.Key);
			break;
		}
	}
}

Console.WriteLine(total);