namespace Castle.MonoRail
{
    using System;
    using System.Web;
    using Hosting.Mvc;

    public class ViewResult : ActionResult
    {
        public object Model { get; set; }
        public string View { get; set; }
        public string Layout { get; set; }

        public ViewResult()
        {
        }

        public ViewResult(object model)
        {
            this.Model = model;
        }

        public ViewResult(string viewName)
        {
            this.View = viewName;
        }

        public ViewResult(string viewName, string layoutName)
        {
            this.View = viewName;
            this.Layout = layoutName;
        }

        public override void Execute(ActionResultContext context, IMonoRailServices services)
        {
            var viewEngines = services.ViewEngines;

            var result = viewEngines.ResolveView(this.View, this.Layout, 
                new ViewResolutionContext(context));

            if (result.Successful)
            {
                try
                {
                    result.View.Process(
                        // fix this: params need to come from elsewhere (no statics!)
                        new ViewContext(
                            new HttpContextWrapper(HttpContext.Current), HttpContext.Current.Response.Output),
                        HttpContext.Current.Response.Output);
                }
                finally
                {
                    result.ViewEngine.Release(result.View);
                }
            }
            else
            {
                throw new Exception("Could not find view (or layout?) " + this.View + 
                    ". Searched at " + string.Join(", ", result.SearchedLocations));
            }
        }
    }
}
