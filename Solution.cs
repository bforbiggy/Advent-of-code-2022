using System;

// Parsing setup
Node root = new Node(children: new List<Node>());
string[] lines = File.ReadAllLines("input.txt");

// Flesh out file system
Node current = root;
for (int i = 0; i < lines.Length; i++)
{
	string line = lines[i];

	// System command: cd
	if (line.StartsWith("$ cd "))
	{
		string new_path = line.Substring(5);
		if (new_path.Equals(".."))
			current = current.parent;
		else if (new_path.Equals("/"))
			current = root;
		else
			current = current.children.Find((node) => node.name.Equals(new_path))!;
	}
	// System command: ls
	else if (line.StartsWith("$ ls"))
	{
		// Ignore...
	}
	// Directory listing
	else if (line.StartsWith("dir"))
	{
		Node directory = new Node(name: line.Substring(4), parent: current, children: new List<Node>());
		current.addChild(directory);
	}
	// File listing
	else
	{
		string[] tokens = line.Split(' ');
		Node file = new Node(name: tokens[1], value: Int32.Parse(tokens[0]), parent: current);
		current.addChild(file);
	}
}

// Traverse file system, summing up valid directories
int total = 0;
void total_traverse(Node node)
{
	// Base case: Files are ignored
	if (node.isFile())
		return;

	// Recursive case: Traverse children
	foreach (Node child in node.children)
		total_traverse(child);
	if (node.value <= 100000)
		total += node.value;
}
total_traverse(root);
Console.WriteLine(total);