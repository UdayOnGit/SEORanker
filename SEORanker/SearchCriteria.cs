using System;
using System.Collections.Generic;

namespace SEORanker
{
	public class SearchCriteria
	{
		#region Keyword

		public string KeyWord
		{
			get => keyWord;
			set
			{
				keyWord = value;
				ValidateKeyword();
			}
		}
		string keyWord;

		void ValidateKeyword()
		{
			if (string.IsNullOrEmpty(KeyWord))
			{
				HasError = true;
				AddError(ErrorType.InvalidKeyword);
			}
		}

		#endregion


		#region InputURL

		public string InputURL
		{
			get => inputURL;
			set
			{
				inputURL = value;
				ParseURL();
				ValidateInputURL();
			}
		}

		string inputURL;

		void ParseURL()
		{
			if (!string.IsNullOrEmpty(InputURL) && !InputURL.StartsWith("http", StringComparison.OrdinalIgnoreCase))
			{
				inputURL = "http://" + InputURL;
			}
		}

		void ValidateInputURL()
		{
			if(!Uri.IsWellFormedUriString(InputURL, UriKind.Absolute))
			{
				HasError = true;
				AddError(ErrorType.InvalidURL);
			}
		}

		#endregion

		public bool HasError { get; set; }

		public IList<string> ErrorMessages { get; private set; }

		void AddError(ErrorType errorType)
		{
			if (ErrorMessages == null)
			{
				ErrorMessages = new List<string>();
			}
			switch (errorType)
			{
				case ErrorType.InvalidKeyword:
					ErrorMessages.Add(invalidKeyword);
					break;
				case ErrorType.InvalidURL:
					ErrorMessages.Add(invalidInputURL);
					break;
			}
		}

		const string invalidKeyword = "Input keyword is not valid, please try again";
		const string invalidInputURL = "Input URL is not valid, please try again";

		enum ErrorType
		{
			InvalidKeyword = 0,
			InvalidURL = 1
		}
	}
}
