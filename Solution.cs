using System;

// On certain cycles, sum signal strength
int strengthSum = 0;
void processCycle(int register, int cycle)
{
	if ((cycle - 20) % 40 == 0)
		strengthSum += register * cycle;
}

int register = 1;
int cycle = 1;
foreach (string line in File.ReadLines("input.txt"))
{
	// Noop: One cycle blank instruction
	if (line.StartsWith("noop"))
	{
		processCycle(register, cycle);
		cycle++;
	}
	// Addx: Two cycle add instruction
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

Console.WriteLine(strengthSum);