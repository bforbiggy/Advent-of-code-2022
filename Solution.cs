using System;

// Grid information
Position head = new Position(0, 0);
Position tail = new Position(0, 0);
HashSet<Position> visited = new HashSet<Position>();

// Have tail follow head if necessary
void followHead()
{
	Position delta = new Position(0, 0);
	Position distance = new Position(head.x - tail.x, head.y - tail.y);

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
	tail += delta;
	visited.Add(tail);
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
		head += delta;
		followHead();
	}
}

Console.WriteLine(visited.Count);