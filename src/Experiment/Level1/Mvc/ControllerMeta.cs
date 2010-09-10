namespace Layer2
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public class ControllerMeta
    {
        public ControllerMeta(object controller)
        {
            Contract.Requires(controller != null);
            Contract.Ensures(Metadata != null);
            Contract.Ensures(ControllerInstance != null);
            Contract.EndContractBlock();

            Metadata = new Dictionary<string, object>();
            ControllerInstance = controller;
        }

        public IDictionary<string, object> Metadata { get; set; }

        public object ControllerInstance { get; set; }
    }
}
