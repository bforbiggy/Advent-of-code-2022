using System.Security.Cryptography;

public class Node
{
	public int value;
	public string name;
	public Node parent;
	public List<Node> children; // TODO: Use dictionary for unique children

	public Node(int value = 0, string name = "", Node parent = null, List<Node> children = null)
	{
		this.value = value;
		this.name = name;
		this.parent = parent;
		this.children = children;
	}

	public bool isDir()
	{
		return children != null;
	}

	public bool isFile()
	{
		return children == null;
	}

	public void addChild(Node child)
	{
		children.Add(child);
		Node temp = this;
		while (temp != null)
		{
			temp.value += child.value;
			temp = temp.parent;
		}
	}
}