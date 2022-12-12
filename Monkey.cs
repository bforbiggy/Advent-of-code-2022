using System.Numerics;

public class Monkey
{
	public int inspected = 0;
	public List<BigInteger> items;
	public Func<BigInteger, BigInteger> operation;
	public Func<BigInteger, bool> test;
	public int trueTarget;
	public int falseTarget;

	public Monkey(List<BigInteger> items, Func<BigInteger, BigInteger> operation, Func<BigInteger, bool> test, int trueTarget, int falseTarget)
	{
		this.items = items;
		this.operation = operation;
		this.test = test;
		this.trueTarget = trueTarget;
		this.falseTarget = falseTarget;
	}
}