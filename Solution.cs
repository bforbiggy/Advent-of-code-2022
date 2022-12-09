using System;

// Grid information
List<Position> knots = new List<Position>();
for (int i = 0; i < 10; i++)
	knots.Add(new Position(0, 0));

HashSet<Position> visited = new HashSet<Position>();

// Have this knot follow other knot if necessary
Position follow(Position a, Position b)
{
	Position delta = new Position(0, 0);
	Position distance = new Position(b.x - a.x, b.y - a.y);

	// Required movements
	if (distance.x >= 2)
		delta.x = 1;
	if (distance.x <= -2)
		delta.x = -1;
	if (distance.y >= 2)
		delta.y = 1;
	if (distance.y <= -2)
		delta.y = -1;

	// Optional alignment movements
	if (delta.x != 0 && delta.y == 0)
	{
		if (distance.y >= 1)
			delta.y = 1;
		if (distance.y <= -1)
			delta.y = -1;
	}
	if (delta.x == 0 && delta.y != 0)
	{
		if (distance.x >= 1)
			delta.x = 1;
		if (distance.x <= -1)
			delta.x = -1;
	}

	// Perform movement
	return a + delta;
}

// Perform head movement
foreach (string line in File.ReadLines("input.txt"))
{
	char direction = line[0];
	int distance = Int32.Parse(line.Substring(2));

	// Calculate change in position
	Position delta = new Position(0, 0);
	if (direction == 'U')
		delta.y = 1;
	else if (direction == 'D')
		delta.y = -1;
	else if (direction == 'L')
		delta.x = -1;
	else if (direction == 'R')
		delta.x = 1;

	// Repeat movement as specified
	for (int i = 0; i < distance; i++)
	{
		knots[9] += delta;

		// After moving head, have each knot follow the next
		for (int j = 8; j >= 0; j--)
		{
			knots[j] = follow(knots[j], knots[j + 1]);
		}

		visited.Add(knots[0]);
	}
}

Console.WriteLine(visited.Count);