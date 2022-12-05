using System;
using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines("input.txt");
int columnCount = (lines[0].Length / 4) + 1;

// Create array of stacks
LinkedList<char>[] stacks = new LinkedList<char>[columnCount];
for (int index = 0; index < columnCount; index++)
	stacks[index] = new LinkedList<char>();

// Populate stacks row by row
int row;
for (row = 0; lines[row].Contains("["); row++)
{
	// Parse each crate in line
	int col = 0;
	for (int j = 1; j < lines[row].Length; j += 4)
	{
		if (!char.IsWhiteSpace(lines[row][j]))
		{
			stacks[col].AddFirst(lines[row][j]);
		}
		col++;
	}
}
row += 2;

// Parse all move operations
for (int i = row; i < lines.Length; i++)
{
	// Format the string into number tokens
	string filteredLine = new String(lines[i].Where((c) => char.IsDigit(c) || char.IsWhiteSpace(c)).ToArray());
	filteredLine = filteredLine.Replace("  ", " ").TrimStart();
	string[] tokens = filteredLine.Split(' ');

	// Parse number tokens
	int removeCount = Int32.Parse(tokens[0]);
	int fromIndex = Int32.Parse(tokens[1]) - 1;
	int toIndex = Int32.Parse(tokens[2]) - 1;

	// Perform operation
	for (int j = 0; j < removeCount; j++)
	{
		stacks[toIndex].AddLast(stacks[fromIndex].Last.Value);
		stacks[fromIndex].RemoveLast();
	}
}

// Output stacks
foreach (LinkedList<char> stack in stacks)
{
	Console.Write(stack.Last.Value);
}