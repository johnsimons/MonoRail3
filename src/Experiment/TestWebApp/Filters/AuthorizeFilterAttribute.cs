namespace TestWebApp.Filters
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizeFilterAttribute : Attribute
    {
        public Permission Permission { get; set; }

        public AuthorizeFilterAttribute(Permission permission)
        {
            Permission = permission;
        }

        public string FailMessage { get; set; }
    }

    public struct Permission
    {
    }
}