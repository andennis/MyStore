using System.Web.Mvc;

namespace MyStore.Web.Common
{
    public abstract class MyStoreWebViewPage<TModel> : WebViewPage<TModel>
    {
        public UserContext UserContext { get; set; }

        public override void InitHelpers()
        {
            UserContext = new UserContext();
            base.InitHelpers();
        }
    }
}
