using System;

namespace Repository
{
    public class ScreenRepositoryCacheKey
    {
        private readonly string title;
        private readonly Type screenType;

        public ScreenRepositoryCacheKey(string title, Type screenType)
        {
            this.title = title;
            this.screenType = screenType;
        }

        protected virtual bool Equals(ScreenRepositoryCacheKey screenRepositoryCacheKey)
        {
            if (screenRepositoryCacheKey == null) return false;
            return Equals(title, screenRepositoryCacheKey.title) && Equals(screenType, screenRepositoryCacheKey.screenType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ScreenRepositoryCacheKey);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode() + 29*screenType.GetHashCode();
        }

        public virtual bool Matches(Type type, Predicate<string> match)
        {
            if (!type.Equals(screenType)) return false;
            return match.Invoke(title);
        }
    }
}