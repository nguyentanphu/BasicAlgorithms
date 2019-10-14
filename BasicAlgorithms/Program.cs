using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicAlgorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(nameof(FindPairWithSum));
			Console.WriteLine(FindPairWithSum(new[] { 1, 5, 6, 9 }, 8));
			Console.WriteLine(nameof(CheckDuplicateStringStream));
			CheckDuplicateStringStream(new[] {"abc", "sadsa", "werew"});
			Console.WriteLine(nameof(LongestMadeUpString));
			Console.WriteLine(LongestMadeUpString(new[] { "Hey", "you", "stop", "right", "there" }));
			Console.WriteLine(nameof(ConvertBinaryStringToInteger));
			Console.WriteLine(ConvertBinaryStringToInteger("11"));
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
		///Input: arr[] = {"geeks", "for", "geeks"}
		///Output:
		///No
		///	No
		///Yes

		///	Input: arr[] = {"abc", "aaa", "cba"}
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
		/// Input: arr[] = {"geeks", "for", "geeksfor", "geeksforgeeks"}
		///Output: geeksforgeeks
		///"geeksforgeeks" is made up of("geeks" + "for" + "geeks").
		///Even though "geeksfor" is also made up of other strings
		///but it is not the largest string.
		/// 
		///Input: arr[] = {"Hey", "you", "stop", "right", "there"}
		///Output : -1
		/// </summary>
		/// <param name="data"></param>
		static string LongestMadeUpString(string[] data)
		{
			var sortedBasedOnLength = data.OrderByDescending(s => s.Length).ToArray();
			var stringMap = sortedBasedOnLength.ToHashSet();
			for (int i = 0; i < sortedBasedOnLength.Length; i++)
			{
				stringMap.Remove(sortedBasedOnLength[i]);
				if (CanBeBuiltFromOtherElements(sortedBasedOnLength, i, stringMap))
				{
					return sortedBasedOnLength[i];
				}
			}

			return (-1).ToString();
		}

		static bool CanBeBuiltFromOtherElements(string[] data, int currentIndex, HashSet<string> stringMap)
		{
			var currentString = data[currentIndex];
			for (int i = 0; i < data.Length; i++)
			{
				if (i != currentIndex && currentString.StartsWith(data[i]))
				{
					var remainingString = currentString.Substring(data[i].Length);
					if (stringMap.Contains(remainingString))
					{
						return true;
					}
				}
			}

			return false;
		}

		static double ConvertBinaryStringToInteger(string binary)
		{
			double result = 0;
			var twoPower = 0;
			for (int i = binary.Length - 1; i >= 0; i--)
			{
				result += char.GetNumericValue(binary[i]) * Math.Pow(2, twoPower++);
			}

			return result;
		}

		static void SubArrayWithSum(string input)
		{
			Func<string, int[]> ConvertStringToIntArr = s =>
			{
				return s.Split(' ')
					.Select(n => int.Parse(n))
					.ToArray();
			};

			Action<int[], int> FindSumInArr = (ints, sum) =>
				{
					//var numDict = ints.Select((n, i) => new {n, i}).ToDictionary(x => x.n, x => x.i);
					var currentSum = 0;
					var hasMatchedSum = false;
					for (int i = 0; i < ints.Length; i++)
					{
						currentSum += ints[i];
						for (var j = i + 1; j < ints.Length; j++)
						{
							currentSum += ints[j];
							if (currentSum == sum)
							{
								hasMatchedSum = true;
								Console.WriteLine($"{i} {j}");
							}
						}
					}

					if (!hasMatchedSum)
					{
						Console.WriteLine(-1);
					}

				};
			var lines = input.Split('\n');
			var numberOfTestCases = int.Parse(lines.First());

			for (int i = 1; i < numberOfTestCases; i = i + 2)
			{
				var conditions = ConvertStringToIntArr(lines[i]);
				var inputArr = ConvertStringToIntArr(lines[i + 1]);

			}
		}

	}
}
