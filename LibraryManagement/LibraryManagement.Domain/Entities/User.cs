namespace LibraryManagement.Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName {get; set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public string PasswordHash {get;set;}  =string.Empty;
        public bool IsActive {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles {get;set;} = new List<UserRole>();
        public Member? Member {get;set;}
    }
}