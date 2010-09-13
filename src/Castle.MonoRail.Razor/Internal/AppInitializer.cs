namespace Castle.MonoRail.Razor.Internal
{
    extern alias ms;
    using ms::Microsoft.WebPages.Compilation;
    using System.Web.Compilation;

    public static class AppInitializer
    {
        private static bool alreadyStarted;

        public static void Init()
        {
            if (!alreadyStarted)
            {
                alreadyStarted = true;

                BuildProvider.RegisterBuildProvider(".cshtml", typeof(InlinePageBuildProvider));
//                CodeGeneratorSettings.AddGlobalImport("System.Web.Mvc");
//                CodeGeneratorSettings.AddGlobalImport("System.Web.Mvc.Ajax");
//                CodeGeneratorSettings.AddGlobalImport("System.Web.Mvc.Html");
//                CodeGeneratorSettings.AddGlobalImport("System.Web.Routing");

            }
        }
    }
}
