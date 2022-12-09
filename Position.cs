public class Position
{
	public int x;
	public int y;

	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (obj == null)
			return false;
		return Equals(obj as Position);
	}

	public bool Equals(Position? p)
	{
		if (p == null)
			return false;
		return x == p.x && y == p.y;
	}

	public static Position operator +(Position a, Position b)
	{
		return new Position(a.x + b.x, a.y + b.y);
	}
}