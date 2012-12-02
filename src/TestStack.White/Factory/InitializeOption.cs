using System;

namespace White.Core.Factory
{
    /// <summary>
    /// In cache mode:
    /// The return window contains all primary controls. Is useful when you are going to perform lot of actions on a window.
    /// Caching of controls is done only at this call. The cache is not refreshed automatically.
    /// In non-cache mode:
    /// The controls would be found based on demand. 
    /// </summary>
    public class InitializeOption
    {
        private bool cached;
        private string identifier;

        /// <summary>
        /// This option should not be used as this is only for internal white purposes
        /// </summary>
        public static InitializeOption WithCache
        {
            get { return new InitializeOption(true); }
        }

        public static InitializeOption NoCache
        {
            get { return new InitializeOption(false); }
        }

        private InitializeOption(bool cached)
        {
            this.cached = cached;
        }

        public virtual bool Cached
        {
            get { return cached; }
        }

        /// <summary>
        /// Specify the unique identification for your window. White remembers the location of UIItems inside a window as you find them.
        /// Next time when items inside the same window is found they are located first based on position which is faster.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public virtual InitializeOption AndIdentifiedBy(string identifier)
        {
            this.identifier = identifier;
            return this;
        }

        public virtual string Identifier
        {
            get { return identifier; }
        }

        public virtual bool NoIdentification
        {
            get { return string.IsNullOrEmpty(identifier); }
        }

        public override string ToString()
        {
            return "Cached=" + cached;
        }

        public virtual void NonCached()
        {
            cached = false;
        }
    }
}