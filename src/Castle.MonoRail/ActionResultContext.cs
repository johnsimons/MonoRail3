namespace Castle.MonoRail
{
    using Hosting.Mvc;

    public class ActionResultContext : BaseMvcContext
    {
        public ActionResultContext(string areaName, string controllerName, string actionName) : 
            base(areaName, controllerName, actionName)
        {
        }
    }
}