namespace TestWebApp.Controller
{
	using System.Web;

	public class HomeController
	{

		public void Index(HttpContextBase contextBase)
		{
			contextBase.Response.Write(contextBase.Items["text"]);
		}


//        [RespondToHtml, RespondToJSon, RespondToXml]
//		public User Blah(HttpContextWrapper wrapper)
//		{
//			wrapper.Response.Write("blah");
//
		    // Respond( format => format.Html() );
//
//		}
	}
}