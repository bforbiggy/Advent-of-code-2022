public class Monkey
{
	public List<int> items;
	public Func<int, int> operation;
	public Func<int, bool> test;
	public int trueTarget;
	public int falseTarget;

	public Monkey(List<int> items, Func<int, int> operation, Func<int, bool> test, int trueTarget, int falseTarget)
	{
		this.items = items;
		this.operation = operation;
		this.test = test;
		this.trueTarget = trueTarget;
		this.falseTarget = falseTarget;
	}
}