namespace Castle.MonoRail.Hosting.Mvc
{
    using System;
    using System.ComponentModel.Composition;
    using System.Net;
    using System.Web;
    using Typed.Internal;

    [Export(typeof(IViewEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class WebFormsViewEngine : VirtualPathProviderViewEngine
    {
        [Import]
        public IWebFormFactory WebFormFactory { get; set; } 

        public WebFormsViewEngine()
        {
            LayoutLocationFormats = new[] {
                "~/Views/{1}/{0}.master",
                "~/Views/Shared/{0}.master"
            };

            AreaLayoutLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.master",
                "~/Areas/{2}/Views/Shared/{0}.master",
            };

            ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.aspx",
                "~/Views/{1}/{0}.ascx",
                "~/Views/Shared/{0}.aspx",
                "~/Views/Shared/{0}.ascx"
            };

            AreaViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.aspx",
                "~/Areas/{2}/Views/{1}/{0}.ascx",
                "~/Areas/{2}/Views/Shared/{0}.aspx",
                "~/Areas/{2}/Views/Shared/{0}.ascx",
            };

            PartialViewLocationFormats = ViewLocationFormats;
            AreaPartialViewLocationFormats = AreaViewLocationFormats;
        }

        protected override IView CreateView(string viewPath, string layoutPath)
        {
            return new WebFormView(this.WebFormFactory, viewPath, layoutPath);
        }

        protected override bool FileExists(string path)
        {
            try
            {
                object page = WebFormFactory.CreateInstanceFromVirtualPath(path, typeof(object));
                if (page is IDisposable)
                {
                    (page as IDisposable).Dispose();
                }
                return page != null;
            }
            catch (HttpException he)
            {
                if (he is HttpParseException)
                {
                    // The build manager found something, but instantiation failed due to a runtime lookup failure
                    throw;
                }

                if (he.GetHttpCode() == (int)HttpStatusCode.NotFound)
                {
                    // If BuildManager returns a 404 (Not Found) that means that a file did not exist.
                    // If the view itself doesn't exist, then this method should report that rather than throw an exception.
                    if (!base.FileExists(path))
                    {
                        return false;
                    }
                }

                // All other error codes imply other errors such as compilation or parsing errors
                throw;
            }
        }
    }
}
