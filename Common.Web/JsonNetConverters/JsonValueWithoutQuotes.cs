
namespace Common.Web.JsonNetConverters
{
    public class JsonValueWithoutQuotes
    {
        public JsonValueWithoutQuotes(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
