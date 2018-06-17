using System;
using SEORanker;

namespace SmokeBallAssignment
{
	class Program
	{
		static void Main(string[] args)
		{
			var validInput = false;
			while (!validInput)
			{
				var searchCriteria = new SearchCriteria();

				Console.WriteLine("Please enter the keyword to search");
				searchCriteria.KeyWord = Console.ReadLine();

				Console.WriteLine("Please enter the URL to search");
				searchCriteria.InputURL = Console.ReadLine();

				if (searchCriteria.HasError)
				{
					Console.Clear();
					var errors = string.Join(Environment.NewLine, searchCriteria.ErrorMessages);
					Console.WriteLine(errors + Environment.NewLine);
				}
				else
				{
					validInput = true;
				}
				var downloadedHTML = HTMLDownloader.GetHTML(new Configuration(), searchCriteria.KeyWord);
				var(isURLRanked, urlPositionList) = HTMLParser.FindPosition(downloadedHTML, searchCriteria.InputURL);
				var result = isURLRanked ?
$"Found {urlPositionList.Count} occurances for {searchCriteria.InputURL} at positions: {string.Join(", ", urlPositionList)}" :
$"Found no occurances for {searchCriteria.InputURL}";
				Console.WriteLine(result);
				Console.ReadLine();
			}
		}
	}
}