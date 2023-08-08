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

	[DefaultProperty("src")]
	[ToolboxData(
@"<{0}:link__loader__InAppSub runat=server  NavigateUrl=""division_in_app_""  title=""un-urlEncoded"">
	<%--displayed text--%>
</{0}:link__loader__InAppSub>")]
	public class link__loader__InAppSub : HyperLink
	{

		public string title
		{
			get
			{
				string s = (string)ViewState[nameof(title)];
				return s ?? "";


			}
			set
			{
				ViewState[nameof(title)] = value;
			}
		}




		protected override void Render(HtmlTextWriter output)
		{
			NavigateUrl = link__Loader.LoaderPrefix + nilnul.web.CfgX.SLASH___APP__STEM___SLASH+(NavigateUrl ?? "") + "&title=" + HttpUtility.UrlEncode(title);

			if (this.DesignMode)
			{
				NavigateUrl = nilnul.web.Properties.settings._url.Origin.Default.schemelessOrigin + NavigateUrl;
			}


			base.Render(output);



			
		}


	}
}

