using Bricks.DynamicProxy;
using White.Core.UIItems;

namespace White.Core.CustomCommands
{
    public class CustomCommandFactory
    {
        public virtual T Create<T>(UIItem uiItem)
        {
            return (T) DynamicProxyGenerator.Instance.CreateProxy(new CustomCommandInterceptor(uiItem), typeof(T));
        }
    }
}