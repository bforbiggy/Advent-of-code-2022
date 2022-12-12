public class Position
{
	public int row;
	public int col;

	public Position(int row, int col)
	{
		this.row = row;
		this.col = col;
	}

	public override int GetHashCode()
	{
		return $"{row},{col}".GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
			return false;

		Position other = (Position)obj;
		return row == other.row && col == other.col;
	}
}