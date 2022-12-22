using System;
using System.Collections;
using System.Runtime.CompilerServices;

// Construct heightmap
string[] lines = File.ReadAllLines("input.txt");
int[][] map = new int[lines.Length][];
List<Position> starts = new List<Position>();
Position end = null!;
for (int row = 0; row < lines.Length; row++)
{
	map[row] = new int[lines[row].Length];
	for (int col = 0; col < lines[row].Length; col++)
	{
		if (lines[row][col] == 'a')
		{
			map[row][col] = 'a' - 'a';
			Position start = new Position(row, col);
			starts.Add(start);
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
int min = int.MaxValue;
foreach (Position start in starts)
{
	HashSet<Position> visited = new HashSet<Position>();
	Queue<List<Position>> queue = new Queue<List<Position>>();
	queue.Enqueue(new List<Position>(new Position[] { start }));

	while (queue.Count != 0)
	{
		List<Position> path = queue.Dequeue();
		Position next = path[path.Count - 1];

		// Path reached end, done
		if (end.Equals(next))
		{
			if (path.Count < min)
				min = path.Count;
			break;
		}

		// Visit node, ignoring already visited ones
		if (visited.Contains(next))
			continue;
		visited.Add(next);

		// Traverse neighbors
		IEnumerable<Position> neighbors = getNeighbors(next);
		foreach (Position neighbor in neighbors)
		{
			// Unreachable positions are ignored
			if (map[next.row][next.col] + 1 < map[neighbor.row][neighbor.col])
				continue;

			List<Position> newPath = new List<Position>(path);
			newPath.Add(neighbor);
			queue.Enqueue(newPath);
		}
	}
}
Console.WriteLine(min - 1);

