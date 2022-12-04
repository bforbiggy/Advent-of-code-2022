public enum Choice
{
	ROCK, PAPER, SCISSORS, ERROR
}

public class RPS
{
	public static int getResult(Choice a, Choice b)
	{
		if (a == b)
			return 3;

		return getLose(a) == b ? 6 : 0;
	}

	public static Choice getDraw(Choice c)
	{
		return c;
	}

	public static Choice getWin(Choice c)
	{
		if (c == Choice.ROCK)
			return Choice.PAPER;
		else if (c == Choice.PAPER)
			return Choice.SCISSORS;
		else if (c == Choice.SCISSORS)
			return Choice.ROCK;
		return Choice.ERROR;
	}

	public static Choice getLose(Choice c)
	{
		if (c == Choice.ROCK)
			return Choice.SCISSORS;
		else if (c == Choice.PAPER)
			return Choice.ROCK;
		else if (c == Choice.SCISSORS)
			return Choice.PAPER;
		return Choice.ERROR;
	}

	public static int getValue(Choice c)
	{
		if (c == Choice.ROCK)
			return 1;
		else if (c == Choice.PAPER)
			return 2;
		else if (c == Choice.SCISSORS)
			return 3;
		return -1;
	}

	public static Choice parseChar(char choiceChar)
	{
		if ("A".Contains(choiceChar))
			return Choice.ROCK;
		else if ("B".Contains(choiceChar))
			return Choice.PAPER;
		else if ("C".Contains(choiceChar))
			return Choice.SCISSORS;
		return Choice.ERROR;
	}
}