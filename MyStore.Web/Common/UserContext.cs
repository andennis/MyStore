using System.Web;

namespace MyStore.Web.Common
{
    public class UserContext
    {
        public int? UserId
        {
            get { return GetSessionValue<int?>("UserId"); }
            set { SetSessionValue("UserId", value);}
        }
        public int? ClientId
        {
            get { return GetSessionValue<int?>("ClientId"); }
            set { SetSessionValue("ClientId", value); }
        }

        private T GetSessionValue<T>(string key)
        {
            object val = HttpContext.Current.Session[key];
            return val != null ? (T) HttpContext.Current.Session[key] : default(T);
        }

        private void SetSessionValue(string key, object val)
        {
            HttpContext.Current.Session[key] = val;
        }
    }
}
