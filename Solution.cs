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
int total_traverse(Node node)
{
	if (node.isFile())
	{
		return node.value;
	}
	else
	{
		foreach (Node child in node.children)
			node.value += total_traverse(child);
		return node.value;
	}
}
int used = total_traverse(root);

// Traverse file system, looking for smallest directory to delete
int freeAmount = 70000000 - used;
int minimumFree = 30000000 - freeAmount;
int smallest = Int32.MaxValue;
void free_traverse(Node node)
{
	if (node.isFile())
	{
		return;
	}
	else
	{
		foreach (Node child in node.children)
			free_traverse(child);
		if (node.value >= minimumFree && node.value <= smallest)
			smallest = node.value;
	}
}
free_traverse(root);
Console.WriteLine(smallest);