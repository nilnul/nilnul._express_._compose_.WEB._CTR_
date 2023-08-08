using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace nilnul._express_._compose_.WEB._CTR_.link_
{

	/// <summary>
	/// allow following paths:
	///		tilded such as "~/abc"
	///		relative such as "abc/def"
	///		absolute such as "/abc/def"
	/// </summary>
	[DefaultProperty("src")]
	[ToolboxData(@"<{0}:link__Loader runat=server  NavigateUrl=""/a/route"" title=""un-urlEncoded"">
<%--~/abc/def.ascx or /abc or abc/def--%>
</{0}:link__Loader>")]
	public class link__Loader : HyperLink
	{

	

		static public string LoaderPrefix
		{
			get {
				return Properties.settings.Url.Singleton.stem + "Loader1.aspx?url=";
			}
		}


		public string title
		{
			get {
				string s = (string)ViewState[nameof(title)];
				return s??"";


			}
			set {
				ViewState[nameof(title)] = value;
			}
		}

		protected override void Render(HtmlTextWriter output)
		{
			NavigateUrl = LoaderPrefix + (NavigateUrl ?? "")+"&title="+  HttpUtility.UrlEncode(title);

			if (this.DesignMode)
			{
				NavigateUrl = nilnul.web.Properties.settings._url.Origin.Default.schemelessOrigin + NavigateUrl;
			}


			base.Render(output);

			//RenderContents(writer);
		}


	}
}

