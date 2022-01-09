using System;
using System.Collections.Generic;

public static class Globals
{
	
	internal static SortedDictionary<int, int> f_cash = new SortedDictionary<int, int>();

	public static int f(int x)
	{ 

		if (x < 3)
		{
			return 0; 
		}

		if (x == 3)
		{
			return 1; 
		}


		if ((x) > 0)
		{
			f_cash[x] = f(x / 2) + f(x - x / 2);
		}

		return f_cash[x];

	}



	internal static void Main()
	{

		int a;

		a = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

		Console.Write(f(a));

	}
}


internal static class ConsoleInput
{
	private static bool goodLastRead = false;
	public static bool LastReadWasGood
	{
		get
		{
			return goodLastRead;
		}
	}

	public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
	{
		string input = "";

		char nextChar;
		while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
		{
			
			if (!skipLeadingWhiteSpace)
				input += nextChar;
		}
		
		input += nextChar;

		
		while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
		{
			input += nextChar;
		}

		goodLastRead = input.Length > 0;
		return input;
	}

	public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
	{
		string input = "";

		char nextChar;
		if (unwantedSequence != null)
		{
			nextChar = '\0';
			for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
			{
				if (char.IsWhiteSpace(unwantedSequence[charIndex]))
				{
					
					while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
					{
					}
				}
				else
				{
					
					nextChar = (char)System.Console.Read();
					if (nextChar != unwantedSequence[charIndex])
						return null;
				}
			}

			input = nextChar.ToString();
			if (maxFieldLength == 1)
				return input;
		}

		while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
		{
			input += nextChar;
			if (maxFieldLength == input.Length)
				return input;
		}

		return input;
	}

}
