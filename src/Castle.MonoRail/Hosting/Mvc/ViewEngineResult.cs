namespace Castle.MonoRail.Hosting.Mvc
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class ViewEngineResult
    {
        public ViewEngineResult(IEnumerable<string> searchedLocations)
        {
            Contract.Requires(searchedLocations != null);
            Contract.Ensures(!Successful);
            Contract.Ensures(View == null);
            Contract.Ensures(ViewEngine == null);
            Contract.EndContractBlock();

            SearchedLocations = searchedLocations;
        }

        public ViewEngineResult(IView view, IViewEngine viewEngine)
        {
            Contract.Requires(view != null);
            Contract.Requires(viewEngine != null);
            Contract.Ensures(Successful);
            Contract.Ensures(View != null);
            Contract.Ensures(ViewEngine != null);
            Contract.EndContractBlock();

            View = view;
            ViewEngine = viewEngine;
            Successful = true;
        }

        public bool Successful { get; private set; }
        public IEnumerable<string> SearchedLocations { get; set; }
        public IViewEngine ViewEngine { get; private set; }
        public IView View { get; private set; }
    }
}