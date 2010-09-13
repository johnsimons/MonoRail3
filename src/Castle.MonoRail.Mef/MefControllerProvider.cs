namespace Castle.MonoRail.Mef
{
    using System;
    using System.ComponentModel.Composition;
    using System.Web;
    using System.Web.Routing;
    using Primitives;

    [Export(typeof(ControllerProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MefControllerProvider : ControllerProvider
    {
        public override ControllerMeta Create(RouteData data, HttpContextBase context)
        {
            // Connects to a MEF Container on the app side

            throw new NotImplementedException();
        }
    }
}
