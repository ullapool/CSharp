using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static int BlockPlayer(int a, int b)
	{
		WinAnalizer winanalizer = new WinAnalizer();
		return winanalizer.GetBlockedFields(a, b);
	}

}
public class WinAnalizer
{
	public WinAnalizer()
	{
		LoadWinPatterns();
	}

	public int GetBlockedFields(int a, int b)
	{
		int[] winPattern = GetWinPattern(a, b);
		return winPattern.Where(n => n != a && n != b).ToArray()[0];

	}

	public int[] GetWinPattern(int cell_1, int cell_2)
	{
		foreach (int[] winPattern in _winPatterns)
		{
			if (winPattern.Contains(cell_1) && winPattern.Contains(cell_2))
			{
				return winPattern;
			}

		}
		return new int[0];
	}
	private List<int[]> _winPatterns;

	private void LoadWinPatterns()
	{
		_winPatterns = new List<int[]>
		{
			new int[]{0, 1, 2},
			new int[]{3, 4, 5},
			new int[]{6, 7, 8},
			new int[]{0, 4, 8},
			new int[]{6, 4, 2},
			new int[]{0, 3, 6},
			new int[]{1, 4, 7},
			new int[]{2, 5, 8},
		};

	}

	public static void Main()
	{
		Console.WriteLine(Program.BlockPlayer(2, 8));
	}
}