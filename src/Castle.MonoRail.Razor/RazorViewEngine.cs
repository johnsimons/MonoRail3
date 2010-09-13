namespace Castle.MonoRail.Razor
{
    using System;
    using System.ComponentModel.Composition;
    using Hosting.Mvc;
    using Hosting.Mvc.Internal;

    [Export(typeof(IViewEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RazorViewEngine : VirtualPathProviderViewEngine
    {
        [Import]
        public IHostingBridge HostingBridge { get; set; }

        public RazorViewEngine()
        {
            AreaViewLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            AreaLayoutLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            AreaPartialViewLocationFormats = new [] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
            ViewLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml"
            };
            LayoutLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new [] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml"
            };
        }

        protected override IView CreateView(string viewPath, string layoutPath)
        {
            return new RazorView(this.HostingBridge, viewPath, layoutPath);
        }

        protected override bool FileExists(string path)
        {
            return HostingBridge.FileExists(path);
        }
    }
}
