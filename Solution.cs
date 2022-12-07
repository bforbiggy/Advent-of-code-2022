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

// Traverse file system, looking for smallest directory to delete
int freeAmount = 70000000 - root.value;
int minimumFree = 30000000 - freeAmount;
int smallest = Int32.MaxValue;
void free_traverse(Node node)
{
	// Base case: Files are ignored
	if (node.isFile())
		return;

	// Recursive case: Traverse children
	foreach (Node child in node.children)
		free_traverse(child);
	if (node.value >= minimumFree && node.value <= smallest)
		smallest = node.value;
}
free_traverse(root);
Console.WriteLine(smallest);