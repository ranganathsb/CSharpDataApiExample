using System.Configuration;

namespace FundsLibrary.DataApi.Example.Service.Configuration
{
	public class FundsLibraryApiConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty("authorizationKey", IsRequired = true)]
		public string AuthorizationKey
		{
			get { return (string)this["authorizationKey"]; }
			set { this["authorizationKey"] = value; }
		}

		[ConfigurationProperty("url", IsRequired = true)]
		public string Url
		{
			get { return (string)this["url"]; }
			set { this["url"] = value; }
		}
	}
}
