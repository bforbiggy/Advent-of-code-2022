using System;

bool[,] display = new bool[6, 40];

void processCycle(int register, int cycle)
{
	int temp = cycle % (6 * 40);
	int row = temp / 40;
	int col = temp % 40;

	// Sprite is at current draw location
	if (col <= register + 1 && col >= register - 1)
	{
		display[row, col] = true;
	}
}

int register = 1;
int cycle = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	if (line.StartsWith("noop"))
	{
		processCycle(register, cycle);
		cycle++;
	}
	else if (line.StartsWith("addx"))
	{
		int val = Int32.Parse(line.Substring(5));

		for (int i = 0; i < 2; i++)
		{
			processCycle(register, cycle);
			cycle++;
		}

		register += val;
	}
}

for (int y = 0; y < display.GetLength(0); y++)
{
	for (int x = 0; x < display.GetLength(1); x++)
	{
		Console.Write(display[y, x] ? "#" : ".");
	}
	Console.WriteLine();
}