using System;

// Returns true if range a is contained entirely within b
bool rangesIntersect(int[] a, int[] b)
{
	// Left end of a is in b
	if (a[0] >= b[0] && a[0] <= b[1])
		return true;
	// Right end of a is in b
	else if (a[1] >= b[0] && a[1] <= b[1])
		return true;
	return false;
}

// Converts a range string (3-9) to a range array
int[] stringToAssignment(string str)
{
	string[] tokens = str.Split("-");
	return new int[] { Int32.Parse(tokens[0]), Int32.Parse(tokens[1]) };
}

int count = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	string[] assignments = line.Split(',');
	int[] a = stringToAssignment(assignments[0]);
	int[] b = stringToAssignment(assignments[1]);

	if (rangesIntersect(a, b) || rangesIntersect(b, a))
	{
		count++;
	}
}

Console.WriteLine(count);