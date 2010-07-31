namespace Layer2
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web;
    using Level1;

    public class ComposableMvcHandler : ComposableHandler
    {
        [ImportMany]
        public IEnumerable<ControllerProvider> ControllerProviders { get; set; }
        
        [ImportMany]
        public IEnumerable<ControllerExecutorProvider> ControllerExecutorProviders { get; set; }

        public override void ProcessRequest(HttpContextBase context)
        {
            
        }
    }
}
