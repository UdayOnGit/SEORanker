using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SEORanker
{
	public class HTMLParser
	{
		public static (bool isURLRanked, IList<string> urlPositionList) FindPosition(string inputHTML, string urlToFind)
		{
			var urlPosition = new List<string>();
			var isURLRanked = false;

			if (!Uri.TryCreate(urlToFind, UriKind.Absolute, out var uriToFind))
			{
				urlPosition.Add("0");
				return (isURLRanked, urlPosition);
			}

			var regex = "(<h3 class=\"r\"><a.href=\"\\/url\\?q=https?://(.*?)>.*?<\\/a><\\/h3>)";
			var matches = Regex.Matches(inputHTML, regex);

			for (int i = 0; i < matches.Count; i++)
			{
				var match = matches[i].Groups[2].Value;
				if (match.Contains(uriToFind.Host))
				{
					urlPosition.Add((i + 1).ToString());
					isURLRanked = true;
				}
			}

			return (isURLRanked, urlPosition);
		}
	}
}
