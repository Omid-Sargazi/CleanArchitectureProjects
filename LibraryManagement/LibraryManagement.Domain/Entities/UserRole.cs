namespace LibraryManagement.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        public int UserId {get;set;}
        public int UserRoleId {get;set;}

        public User User {get;set;}
        public Role Role {get;set;}
    }
}