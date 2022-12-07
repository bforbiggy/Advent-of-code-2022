public class Node
{
	public int value = 0;
	public string name = "";
	public Node parent = null;
	public List<Node> children = null; // TODO: Use dictionary for unique children

	public bool isDir()
	{
		return children != null;
	}

	public bool isFile()
	{
		return children == null;
	}
}