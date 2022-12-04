using System;

long score = 0;
foreach (string line in File.ReadLines("input.txt"))
{
	Choice opponent = RPS.parseChar(line[0]);
	Choice you = RPS.parseChar(line[2]);

	score += RPS.getResult(you, opponent);
	score += RPS.getValue(you);
}
Console.WriteLine(score);