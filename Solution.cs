using System;

int strengthSum = 0;
void processCycle(int register, int cycle)
{
	if ((cycle - 20) % 40 == 0)
		strengthSum += register * cycle;
}

int x = 1;
int cycle = 1;
foreach (string line in File.ReadLines("input.txt"))
{
	if (line.StartsWith("noop"))
	{
		processCycle(x, cycle);
		cycle++;
	}
	else if (line.StartsWith("addx"))
	{
		int val = Int32.Parse(line.Substring(5));

		for (int i = 0; i < 2; i++)
		{
			processCycle(x, cycle);
			cycle++;
		}

		x += val;
	}
}

Console.WriteLine(strengthSum);