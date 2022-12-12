using System;
using System.Runtime.CompilerServices;

// Construct heightmap
string[] lines = File.ReadAllLines("input.txt");
int[][] map = new int[lines.Length][];
Position start = null!;
Position end = null!;
for (int row = 0; row < lines.Length; row++)
{
	map[row] = new int[lines[row].Length];
	for (int col = 0; col < lines[row].Length; col++)
	{
		if (lines[row][col] == 'S')
		{
			map[row][col] = 'a' - 'a';
			start = new Position(row, col);
		}
		else if (lines[row][col] == 'E')
		{
			map[row][col] = 'z' - 'a';
			end = new Position(row, col);
		}
		else
			map[row][col] = lines[row][col] - 'a';
	}
}

// Validate position
bool validPosition(Position pos)
{
	int row = pos.row;
	int col = pos.col;
	return row >= 0 && row < lines.Length && col >= 0 && col < lines[row].Length;
}

// Get neighbors
IEnumerable<Position> getNeighbors(Position pos)
{
	LinkedList<Position> neighbors = new LinkedList<Position>();

	// Up
	Position up = new Position(pos.row - 1, pos.col);
	if (validPosition(up))
		neighbors.AddLast(up);

	// Down
	Position down = new Position(pos.row + 1, pos.col);
	if (validPosition(down))
		neighbors.AddLast(down);

	// Left
	Position left = new Position(pos.row, pos.col - 1);
	if (validPosition(left))
		neighbors.AddLast(left);

	// Right
	Position right = new Position(pos.row, pos.col + 1);
	if (validPosition(right))
		neighbors.AddLast(right);
	return neighbors;
}

// Breadth first search until target is found
int walk = 0;
HashSet<Position> visited = new HashSet<Position>();
Queue<Position> queue = new Queue<Position>();
queue.Enqueue(start);
while (queue.Count != 0)
{
	Position pos = queue.Dequeue();
	visited.Add(pos);

	// Traverse neighbors
	IEnumerable<Position> neighbors = getNeighbors(pos);
	foreach (Position next in neighbors)
	{
		// Unreachable positions are ignored
		if (map[next.row][next.col] + 1 < map[pos.row][pos.col])
			continue;

		// Visited neighbors are ignored
		if (visited.Contains(next))
			continue;

		// Found goal: print walk length and quit
		if (end.Equals(next))
		{
			Console.WriteLine(walk);
			System.Environment.Exit(0);
		}

		queue.Enqueue(next);
	}
}