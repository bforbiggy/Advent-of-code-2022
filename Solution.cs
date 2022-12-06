using System;

string input = File.ReadAllText("input.txt");

int unique = 0;
LinkedList<char> previous = new LinkedList<char>();
for (int i = 0; i < input.Length; i++)
{
	// Prune current list if necessary
	if (previous.Count >= 14)
	{
		char removed = previous.First.Value;
		previous.RemoveFirst();
		if (!previous.Any(match => match == removed))
			unique--;
	}

	// Unique character being added: Update count
	if (!previous.Any(match => match == input[i]))
		unique++;
	// Achieved unique character count: Solution found
	if (unique == 14)
	{
		Console.WriteLine(i + 1);
		break;
	}
	previous.AddLast(input[i]);
}