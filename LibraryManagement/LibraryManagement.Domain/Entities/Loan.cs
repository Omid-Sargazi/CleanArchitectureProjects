namespace LibraryManagement.Domain.Entities
{
    public class Loan:BaseEntity
    {
        public int MemberId {get;set;}
        public int BookId {get;set;}
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Active";

        public Member Member {get;set;} = null!;
        public Book Book {get;set;} = null!;
        public ICollection<Penalty> Penalties {get;set;} = new List<Penalty>();
    }
}