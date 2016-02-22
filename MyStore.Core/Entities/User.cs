using Common.Repository;

namespace MyStore.Core.Entities
{
    public class User : EntityVersionable
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
