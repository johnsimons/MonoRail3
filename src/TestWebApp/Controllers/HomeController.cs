namespace TestWebApp.Controllers
{
	using System.Web;
	using Castle.MonoRail;

	public class HomeController
	{
		public ActionResult Index()
		{
			// contextBase.Response.Write(contextBase.Items["text"]);
			return new ViewResult("index");
		}

//      [RespondToHtml, RespondToJSon, RespondToXml]
//		public User Blah(HttpContextWrapper wrapper)
//		{
//			return new User();
//		}
	}
}