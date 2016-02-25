namespace Common.Web
{
    public class ActionInfo
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public override string ToString()
        {
            if (Area == null)
                return $"{Controller}_{Action}";

            return $"{Area}_{Controller}_{Action}";
        }
    }
}
