namespace Castle.MonoRail
{
    using System;

    // optional base class
    public abstract class Controller
    {
        public void RespondTo(Action<Format> format)
        {
        }

        public class Format
        {
            public Format Html()
            {
                return this;
            }

            public Format Html(Action action)
            {
                return this;
            }

            public Format Js()
            {
                return this;
            }

            public Format Xml()
            {
                return this;
            }

            public Format JSon()
            {
                return this;
            }

            public Format Text()
            {
                return this;
            }
            
            public Format Csv()
            {
                return this;
            }
            
            public Format Rss()
            {
                return this;
            }
            
            public Format Atom()
            {
                return this;
            }

            public Format All()
            {
                return this;
            }
        }
    }
}
