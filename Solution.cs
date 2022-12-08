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

bool visibleFromTop(int x, int y)
{
	int height = trees[y][x];
	while (--y >= 0)
	{
		if (trees[y][x] >= height)
			return false;
	}
	return true;
}

bool visibleFromBottom(int x, int y)
{
	int height = trees[y][x];
	while (++y < trees.Length)
	{
		if (trees[y][x] >= height)
			return false;
	}
	return true;
}

bool visibleFromLeft(int x, int y)
{
	int height = trees[y][x];
	while (--x >= 0)
	{
		if (trees[y][x] >= height)
			return false;
	}
	return true;
}

bool visibleFromRight(int x, int y)
{
	int height = trees[y][x];
	while (++x < trees[y].Length)
	{
		if (trees[y][x] >= height)
			return false;
	}
	return true;
}

int total = 0;
for (int y = 0; y < trees.Length; y++)
{
	for (int x = 0; x < trees[y].Length; x++)
	{
		if (visibleFromLeft(x, y) || visibleFromRight(x, y) || visibleFromTop(x, y) || visibleFromBottom(x, y))
			total++;
	}
}
Console.WriteLine(total);
