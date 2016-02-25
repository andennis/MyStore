using System.Web.Mvc;
using Common.Web.Grid;

namespace Common.Web
{
    public class WidgetFactory
    {
        private readonly HtmlHelper _htmlHelper;

        public WidgetFactory(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public virtual GridBuilder<TModel> Grid<TModel>() where TModel : class
        {
            return new GridBuilder<TModel>(_htmlHelper);
        }

    }
}
