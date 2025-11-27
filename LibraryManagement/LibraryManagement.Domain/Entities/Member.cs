namespace LibraryManagement.Domain.Entities
{
    public class Member:BaseEntity
    {
        public int UserId {get;set;}
        public string FullName {get;set;}  =string.Empty;
        public string Phone {get;set;} = string.Empty;
        public string MemberShipNumber {get;set;}  =string.Empty;
        public DateTime JoinedAt {get;set;} = DateTime.UtcNow;

        public User User {get ;set;} = null!;

        public ICollection<Loan> Loans {get;set;} = new List<Loan>();
        public ICollection<Penalty> Penalties {get;set;} = new List<Penalty>();
    }
}