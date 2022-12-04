using System;

long score = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	Choice opponent = RPS.parseChar(line[0]);
	Choice you = Choice.ERROR;

	if (line[2] == 'X')
		you = RPS.getLose(opponent);
	else if (line[2] == 'Y')
		you = RPS.getDraw(opponent);
	else if (line[2] == 'Z')
		you = RPS.getWin(opponent);

	score += RPS.getResult(you, opponent);
	score += RPS.getValue(you);
}
Console.WriteLine(score);