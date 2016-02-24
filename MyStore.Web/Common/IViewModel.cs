namespace MyStore.Web.Common
{
    public interface IViewModel
    {
        int EntityId { get; }
        bool IsNew { get; }
        string DisplayName { get; }
        string RedirectUrl { get; set; }
    }
}