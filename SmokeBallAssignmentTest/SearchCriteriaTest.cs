using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEORanker;

namespace SmokeBallAssignmentTest
{
	[TestClass]
	public class SearchCriteriaTest
	{
		[TestMethod]
		public void TestKeyWord_ValidInput()
		{
			var searchCriteria = new SearchCriteria
			{
				KeyWord = "Dummy string"
			};
			Assert.IsFalse(searchCriteria.HasError);
			Assert.AreEqual("Dummy string", searchCriteria.KeyWord);

			searchCriteria.KeyWord = "Test 123 string";
			Assert.IsFalse(searchCriteria.HasError);
			Assert.AreEqual("Test 123 string", searchCriteria.KeyWord);
		}

		[TestMethod]
		public void TestKeyWord_InvalidInput()
		{
			var searchCriteria = new SearchCriteria
			{
				KeyWord = string.Empty
			};
			Assert.IsTrue(searchCriteria.HasError);
			Assert.AreEqual("Input keyword is not valid, please try again", searchCriteria.ErrorMessages[0]);
		}

		[TestMethod]
		public void TestInputURL_ValidInput()
		{
			var searchCriteria = new SearchCriteria
			{
				InputURL = "www.abc.com.au"
			};
			Assert.IsFalse(searchCriteria.HasError);
			Assert.AreEqual("http://www.abc.com.au", searchCriteria.InputURL);

			searchCriteria.InputURL = "http://www.abc.com.au";
			Assert.IsFalse(searchCriteria.HasError);
			Assert.AreEqual("http://www.abc.com.au", searchCriteria.InputURL);

			searchCriteria.InputURL = "https://abc.com";
			Assert.IsFalse(searchCriteria.HasError);
			Assert.AreEqual("https://abc.com", searchCriteria.InputURL);
		}

		[TestMethod]
		public void TestInputURL_InvalidInput()
		{
			var searchCriteria = new SearchCriteria
			{
				InputURL = string.Empty
			};
			Assert.IsTrue(searchCriteria.HasError);
			Assert.AreEqual("Input URL is not valid, please try again", searchCriteria.ErrorMessages[0]);
		}
	}
}
