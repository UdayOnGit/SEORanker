using System.Configuration;

namespace SEORanker
{
	public interface IConfiguration
	{
		string BaseSearchURL { get; }
		string NoOfRecordsToSearchIn { get; }
	}

	public class Configuration : IConfiguration
	{
		public string BaseSearchURL => ConfigurationManager.AppSettings["GoogleSearchBaseURL"];

		public string NoOfRecordsToSearchIn => ConfigurationManager.AppSettings["NoOfRecrodsToSearchIn"];
	}
}