using System.Web.Mvc;

namespace Common.Web
{
    public static class HtmlHelperExtension
    {
        public static WidgetFactory Widget(this HtmlHelper helper)
        {
            return new WidgetFactory(helper);
        }

        public static ActionInfo GetCurrentAction(this HtmlHelper helper)
        {
            return new ActionInfo()
            {
                Controller = helper.ViewContext.RouteData.GetController(),
                Action = helper.ViewContext.RouteData.GetAction(),
                Area = helper.ViewContext.RouteData.GetArea()
            };
        }
    }
}
