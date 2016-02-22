using Common.Repository;

namespace MyStore.Core.Entities
{
    public class Client : EntityVersionable
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
