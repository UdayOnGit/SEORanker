using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEORanker;

namespace SmokeBallAssignmentTest
{
	[TestClass]
	public class HTMLDownloaderTest
	{
		[TestMethod]
		public void TestGetHTML_ValidInput()
		{
			var searchKeyword = "software";
			var result = HTMLDownloader.GetHTML(new TestConfiguration(), searchKeyword);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Length > 0);
		}

		[TestMethod]
		public void TestGetHTML_EmptySearchKeyword()
		{
			var searchKeyword = string.Empty;
			var result = HTMLDownloader.GetHTML(new TestConfiguration(), searchKeyword);
			Assert.IsTrue(string.IsNullOrEmpty(result));
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestGetHTML_TestWithInvalidConfiguration()
		{
			var searchKeyword = "software";
			HTMLDownloader.GetHTML(new DummyConfiguration(), searchKeyword);
		}

		class DummyConfiguration : IConfiguration
		{
			public string BaseSearchURL => string.Empty;

			public string NoOfRecordsToSearchIn => string.Empty;
		}

		class TestConfiguration : IConfiguration
		{
			public string BaseSearchURL => "http://www.google.com.au/search?";

			public string NoOfRecordsToSearchIn => "100";
		}
	}
}
