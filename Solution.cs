using System;

string[] lines = File.ReadAllLines("input.txt");

// Construct 2D grid
int[][] trees = new int[lines.Length][];
for (int y = 0; y < trees.Length; y++)
{
	trees[y] = new int[lines[y].Length];
	for (int x = 0; x < trees[y].Length; x++)
		trees[y][x] = lines[y][x] - '0';
}

int viewTop(int x, int y)
{
	int count = 0;
	int height = trees[y][x];
	while (--y >= 0)
	{
		count++;
		if (trees[y][x] >= height)
			return count;
	}
	return count;
}

int viewBottom(int x, int y)
{
	int count = 0;
	int height = trees[y][x];
	while (++y < trees.Length)
	{
		count++;
		if (trees[y][x] >= height)
			return count;
	}
	return count;
}

int viewLeft(int x, int y)
{
	int count = 0;
	int height = trees[y][x];
	while (--x >= 0)
	{
		count++;
		if (trees[y][x] >= height)
			return count;
	}
	return count;
}

int viewRight(int x, int y)
{
	int count = 0;
	int height = trees[y][x];
	while (++x < trees[y].Length)
	{
		count++;
		if (trees[y][x] >= height)
			return count;
	}
	return count;
}


int max = 0;
for (int y = 0; y < trees.Length; y++)
{
	for (int x = 0; x < trees[y].Length; x++)
	{
		int temp = viewLeft(x, y) * viewRight(x, y) * viewTop(x, y) * viewBottom(x, y);
		max = Math.Max(max, temp);
	}
}
Console.WriteLine(max);
