using System;

string[] lines = File.ReadAllLines("input.txt");
int columnCount = (lines[0].Length / 4) + 1;

// Create array of stacks
LinkedList<char>[] stacks = new LinkedList<char>[columnCount];
for (int index = 0; index < columnCount; index++)
	stacks[index] = new LinkedList<char>();

// Populate stacks row by row
int i;
for (i = 0; lines[i].Contains("["); i++)
{
	// Parse each crate in line
	int col = 0;
	for (int j = 1; j < lines[i].Length; j += 4)
	{
		if (!char.IsWhiteSpace(lines[i][j]))
		{
			stacks[col].AddFirst(lines[i][j]);
		}
		col++;
	}
}

// Validate stacks
foreach (LinkedList<char> stack in stacks)
{
	Console.WriteLine(string.Join(",", stack));
}