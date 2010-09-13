namespace Castle.MonoRail.Razor
{
    extern alias ms;
    using System;
    using System.Globalization;
    using ms::Microsoft.WebPages;

    public abstract class WebViewPage : WebPageBase // IViewDataContainer
    {
        protected override WebPageBase CreatePageFromVirtualPath(WebPageBase basePage, string path)
        {
            WebViewPage page = base.CreatePageFromVirtualPath(basePage, path) as WebViewPage;
            if (page == null)
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture, 
                    "Wrong base type for view: {0}", path));
            }
            WebViewPage page2 = basePage as WebViewPage;
            if (page2 == null)
            {
                throw new InvalidOperationException();
            }
//            page.ViewContext = page2.ViewContext;
//            page.ViewData = page2.ViewData;
//            page.InitHelpers();
            return page;
        }

        public override void ExecutePageHierarchy()
        {
//            this.ViewContext.Writer = base.Output;
            base.ExecutePageHierarchy();
//            if (!string.IsNullOrEmpty(this.OverridenLayoutPath))
//            {
//                this.LayoutPage = this.OverridenLayoutPath;
//            }
        }

        public virtual void InitHelpers()
        {
//            this.Ajax = new AjaxHelper<object>(this.ViewContext, this);
//            this.Html = new HtmlHelper<object>(this.ViewContext, this);
//            this.Url = new UrlHelper(this.ViewContext.RequestContext);
        }

//        protected virtual void SetViewData(ViewDataDictionary viewData)
//        {
//            this._viewData = viewData;
//        }

    }
}
