namespace MyStore.Web.Common
{
    public class BaseViewModel : IViewModel
    {
        public virtual string DisplayName => this.GetType().Name.Replace("ViewModel", string.Empty);
        public virtual int EntityId => 0;
        public virtual bool IsNew => (EntityId <= 0);
        public virtual string RedirectUrl { get; set; }
    }
}
