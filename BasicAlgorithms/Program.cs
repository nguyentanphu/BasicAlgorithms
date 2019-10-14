using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicAlgorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(nameof(Program.FindPairWithSum));
			Console.WriteLine(FindPairWithSum(new int[] { 1, 5, 6, 9 }, 8));
			Console.WriteLine(nameof(Program.CheckDuplicateStringStream));
			CheckDuplicateStringStream(new string[] {"abc", "sadsa", "werew"});
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
			var complements = new HashSet<int>();
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
		/// <summary>
		///Input: arr[] = {“geeks”, “for”, “geeks”}
		///Output:
		///No
		///	No
		///Yes

		///	Input: arr[] = {“abc”, “aaa”, “cba”}
		///Output:
		///No
		///	No
		///No
		/// </summary>
		/// <param name="data"></param>
		static void CheckDuplicateStringStream(string[] data)
		{
			var foundStrings = new HashSet<string>();
			foreach (var s in data)
			{
				if (foundStrings.Contains(s))
				{
					Console.WriteLine("Yes");
				}
				else
				{
					foundStrings.Add(s);
					Console.WriteLine("No");
				}
			}
		}

		/// <summary>
		/// Input: arr[] = {“geeks”, “for”, “geeksfor”, “geeksforgeeks”}
		///Output: geeksforgeeks
		///“geeksforgeeks” is made up of(“geeks” + “for” + “geeks”).
		///Even though “geeksfor” is also made up of other strings
		///but it is not the largest string.
		/// 
		///Input: arr[] = {“Hey”, “you”, “stop”, “right”, “there”}
		///Output : -1
		/// </summary>
		/// <param name="data"></param>
		static void LongestMadeUpString(string[] data)
		{
			var sortedBasedOnLength = data.OrderByDescending(s => s.Length).ToArray();
			var stringMap = sortedBasedOnLength.ToHashSet();
			foreach (var s in sortedBasedOnLength)
			{
				
			}
		}

		static bool CanBeBuiltFromOtherElements(string[] data, int currentIndex, HashSet<string> stringMap)
		{
			var currentString = data[currentIndex];
			for (int i = 0; i < data.Length; i++)
			{
				if (i != currentIndex && currentString.)
			}
		}
	}
}
