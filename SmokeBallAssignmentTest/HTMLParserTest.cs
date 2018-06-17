using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEORanker;

namespace SmokeBallAssignmentTest
{
	[TestClass]
	public class HTMLParserTest
	{
		[TestMethod]
		public void TestFindPosition_ValidData()
		{
			var html = File.ReadAllText(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "DummyHtml.html"));
			var result = HTMLParser.FindPosition(html, "http://www.realestate.com.au");
			Assert.IsTrue(result.isURLRanked);
			Assert.AreEqual("1, 2, 3", string.Join(", ", result.urlPositionList));

			result = HTMLParser.FindPosition(html, "http://www.domain.com.au");
			Assert.IsTrue(result.isURLRanked);
			Assert.AreEqual("4, 5", string.Join(", ", result.urlPositionList));
		}

		[TestMethod]
		public void TestFindPosition_InvalidData()
		{
			var html = File.ReadAllText(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "DummyHtml.html"));
			var (isURLRanked, urlPositionList) = HTMLParser.FindPosition(html, "http://www.smokeball.com.au");
			Assert.IsFalse(isURLRanked);
			Assert.AreEqual(string.Empty, string.Join(", ", urlPositionList));
		}
	}
}
