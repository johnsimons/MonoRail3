namespace TestWebApp.Controller
{
	using System.Web;

	public class HomeController
	{
		public void Index(HttpContextBase contextBase)
		{
			contextBase.Response.Write(contextBase.Items["text"]);
		}

		public void Blah(HttpContextWrapper wrapper)
		{
			wrapper.Response.Write("blah");
		}
	}
}