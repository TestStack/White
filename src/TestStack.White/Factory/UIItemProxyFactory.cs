using TestStack.White.Bricks;
using TestStack.White.Interceptors;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Factory
{
    public static class UIItemProxyFactory
    {
        public static IUIItem Create(IUIItem item, IActionListener actionListener)
        {
            return (IUIItem) DynamicProxyGenerator.Instance.CreateProxy(item.GetType(), new CoreInterceptor(item, actionListener));
        }
    }
}