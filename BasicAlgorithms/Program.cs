using System;
using System.Collections.Generic;

namespace BasicAlgorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(FindPairWithSum(new int[] { 1, 5, 6, 9 }, 8));
		}

		/// <summary>
		/// [1,2,4,8] = no
		/// [1,2,4,4] = yes
		/// </summary>
		/// <param name="data"></param>
		/// <param name="sum"></param>
		/// <returns></returns>
		static bool FindPairWithSum(int[] data, int sum)
		{
			HashSet<int> complements = new HashSet<int>();
			foreach (var value in data)
			{
				if (complements.Contains(sum - value))
				{
					return true;
				}
				complements.Add(value);
			}

			return false;
		}
	}
}
