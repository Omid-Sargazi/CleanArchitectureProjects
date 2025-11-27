namespace LibraryManagement.Domain.Entities
{
    public class Penalty:BaseEntity
    {
        public int MemberId { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public int DaysLate { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Member Member { get; set; } = null!;
        public Loan Loan { get; set; } = null!;
    }
}