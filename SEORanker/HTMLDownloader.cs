using System.Net.Http;
using System.Web;

namespace SEORanker
{
	public class HTMLDownloader
	{
		public static string GetHTML(IConfiguration configuration, string searchKeyword)
		{
			if (string.IsNullOrEmpty(searchKeyword))
			{
				return string.Empty;
			}
			var searchUriString = $"{configuration.BaseSearchURL}num={configuration.NoOfRecordsToSearchIn}&q={HttpUtility.UrlEncode(searchKeyword)}";

			using (var client = new HttpClient())
			{
				using (var response = client.GetAsync(searchUriString).Result)
				{
					using (var content = response.Content)
					{
						return content.ReadAsStringAsync().Result;
					}
				}
			}
		}
	}
}
