using System;

// Parsing setup
Node root = new Node();
root.children = new List<Node>();
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
			current = current.children.Find((node) => node.name.Equals(new_path));
	}
	// System command: ls
	else if (line.StartsWith("$ ls"))
	{
		// Ignore...
	}
	// Directory listing
	else if (line.StartsWith("dir"))
	{
		Node directory = new Node();
		directory.parent = current;
		directory.name = line.Substring(4);
		directory.children = new List<Node>();

		current.children.Add(directory);
	}
	// File listing
	else
	{
		string[] tokens = line.Split(' ');
		Node file = new Node();
		file.parent = current;
		file.name = tokens[1];
		file.value = Int32.Parse(tokens[0]);

		current.children.Add(file);
	}
}

// Traverse file system, tracking file size along the way
int total = 0;
int traverse(Node node)
{
	if (node.isFile())
	{
		return node.value;
	}
	else
	{
		foreach (Node child in node.children)
			node.value += traverse(child);

		if (node.value <= 100000)
			total += node.value;
		return node.value;
	}
}
traverse(root);
Console.WriteLine(total);