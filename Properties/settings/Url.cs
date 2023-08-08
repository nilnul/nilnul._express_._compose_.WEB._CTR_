using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nilnul.web.Properties.settings._url;

namespace nilnul._express_._compose_.WEB._CTR_.Properties.settings
{

	public class Url : nilnul.web.Properties.settings._url.origin.WebApp
	{


		public Url() : base(Settings.Default.webDenote)
		{
		}

		public Url(Origin.App url) : base(url, Settings.Default.webDenote)
		{
		}

		public Url(string scheme, string authority) : base(scheme, authority, Settings.Default.webDenote)
		{
		}


		static public Url Singleton
		{
			get
			{
				return nilnul.obj_.Singleton<Url>.Instance;
			}
		}

	}
}
