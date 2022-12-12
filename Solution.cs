using System;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

// Manually add monkeys
List<Monkey> monkeys = new List<Monkey>();
monkeys.Add(new Monkey(
	new List<int>(new int[] { 64 }),
	(worry) => worry * 7,
	(worry) => worry % 13 == 0,
	1, 3
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 60, 84, 84, 65 }),
	(worry) => worry + 7,
	(worry) => worry % 19 == 0,
	2, 7
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 52, 67, 74, 88, 51, 61 }),
	(worry) => worry * 3,
	(worry) => worry % 5 == 0,
	5, 7
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 67, 72 }),
	(worry) => worry + 3,
	(worry) => worry % 2 == 0,
	1, 2
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 80, 79, 58, 77, 68, 74, 98, 64 }),
	(worry) => worry * worry,
	(worry) => worry % 17 == 0,
	6, 0
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 62, 53, 61, 89, 86 }),
	(worry) => worry + 8,
	(worry) => worry % 11 == 0,
	4, 6
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 86, 89, 82 }),
	(worry) => worry + 2,
	(worry) => worry % 7 == 0,
	3, 0
));
monkeys.Add(new Monkey(
	new List<int>(new int[] { 92, 81, 70, 96, 69, 84, 83 }),
	(worry) => worry + 4,
	(worry) => worry % 3 == 0,
	4, 5
));

// Run through rounds
for (int i = 0; i < 20; i++)
{
	foreach (Monkey monkey in monkeys)
	{
		List<int> items = monkey.items;
		for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
		{
			monkey.inspected++;
			items[itemIndex] = monkey.operation(items[itemIndex]) / 3;
			int target = monkey.test(items[itemIndex]) ? monkey.trueTarget : monkey.falseTarget;
			monkeys[target].items.Add(items[itemIndex]);
		}
		items.Clear();
	}
}


for (int i = 0; i < monkeys.Count; i++)
{
	string temp = String.Join(",", monkeys[i].items);
	Console.WriteLine($"{monkeys[i].inspected}");
}