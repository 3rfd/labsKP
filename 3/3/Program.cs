using System;
using System.Collections.Generic;

public static class Globals
{
	internal static void Main()
	{
		int nV= Convert.ToInt32(Console.ReadLine());
		int nE = Convert.ToInt32(Console.ReadLine()); 
		
		const int INF = 1000 * 1000 * 1000;
		List<List<int>> d = VectorHelper.NestedList(nV, nV, INF);
		for (int i = 0; i < nV; i++)
		{
			d[i][i] = 0;
		}
		for (int i = 0; i < nE; i++)
		{
			int v1 = Convert.ToInt32(Console.ReadLine()); 
			int v2 = Convert.ToInt32(Console.ReadLine()); 
			
			v1--;
			v2--;
			d[v1][v2] = 0;
			d[v2][v1] = Math.Min(d[v2][v1], 1);

		}
		for (int k = 0; k < nV; k++)
		{
			for (int i = 0; i < nV; i++)
			{
				for (int j = 0; j < nV; j++)
				{
					d[i][j] = Math.Min(d[i][j], d[i][k] + d[k][j]);
				}
			}
		}
		int max = 0;
		for (int i = 0; i < nV; i++)
		{
			for (int j = 0; j < nV; j++)
			{
				max = Math.Max(max, d[i][j]);
			}
		}

		Console.Write("{0:D}", max);
	}
}



internal static class VectorHelper
{
	public static void Resize<T>(this List<T> list, int newSize, T value = default(T))
	{
		if (list.Count > newSize)
			list.RemoveRange(newSize, list.Count - newSize);
		else if (list.Count < newSize)
		{
			for (int i = list.Count; i < newSize; i++)
			{
				list.Add(value);
			}
		}
	}

	public static void Swap<T>(this List<T> list1, List<T> list2)
	{
		List<T> temp = new List<T>(list1);
		list1.Clear();
		list1.AddRange(list2);
		list2.Clear();
		list2.AddRange(temp);
	}

	public static List<T> InitializedList<T>(int size, T value)
	{
		List<T> temp = new List<T>();
		for (int count = 1; count <= size; count++)
		{
			temp.Add(value);
		}

		return temp;
	}

	public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
	{
		List<List<T>> temp = new List<List<T>>();
		for (int count = 1; count <= outerSize; count++)
		{
			temp.Add(new List<T>(innerSize));
		}

		return temp;
	}

	public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
	{
		List<List<T>> temp = new List<List<T>>();
		for (int count = 1; count <= outerSize; count++)
		{
			temp.Add(InitializedList(innerSize, value));
		}

		return temp;
	}
}

