using System;
using System.Collections.Generic;

LinkedList<Object> parseLine(string line)
{
	LinkedList<Object> result = new LinkedList<Object>();
	return result;
}

string[] lines = File.ReadAllLines(@"input.txt");
for (int i = 0; i < lines.Length; i += 3)
{
	Console.WriteLine(lines[i]);
	Console.WriteLine(lines[i + 1]);
}