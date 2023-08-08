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

namespace nilnul._express_._compose_.WEB._CTR_.link_.loader_
{

	/// <summary>
	/// allow following paths:
	///		tilded such as "~/abc"
	///		relative such as "abc/def"
	///		absolute such as "/abc/def"
	/// </summary>
	[DefaultProperty("src")]
	[ToolboxData(@"<{0}:link__loader__InThisApp runat=server  NavigateUrl=""in_thisApplication_iri_resolved_per_root"" title=""un-urlEncoded"">
<%--~/abc/def.ascx or /abc or abc/def--%>
</{0}:link__loader__InThisApp>")]
	public class link__loader__InThisApp : HyperLink
	{

		public string toRootUrl(string in_application_iri_resolved_per_root)
		{
			return this.ResolveUrl(in_application_iri_resolved_per_root);
		}
		static public string ______ToRootUrl(string in_application_iri_resolved_per_root)
		{
			///VirtualPathUtility.ToAbsolute requires you to have a ~ in the beginning.
			///
			//HttpRuntime.AppDomainAppVirtualPath
			//The HttpRuntime.AppDomainAppVirtualPath property works in both situations. It returns "~/" for websites, but returns null in unit tests so it does not break them
			return VirtualPathUtility.ToAbsolute(in_application_iri_resolved_per_root);
		}

		//static public string Link4Loadee(string in_application_iri_resolved_per_root)
		//{
		//	return LoaderPrefix + (in_application_iri_resolved_per_root);

		//}




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
			NavigateUrl =link__Loader. LoaderPrefix + toRootUrl(NavigateUrl ?? "")+"&title="+  HttpUtility.UrlEncode(title);

			if (this.DesignMode)
			{
				NavigateUrl = nilnul.web.Properties.settings._url.Origin.Default.schemelessOrigin + NavigateUrl;
			}


			base.Render(output);

			//RenderContents(writer);
		}


	}
}

