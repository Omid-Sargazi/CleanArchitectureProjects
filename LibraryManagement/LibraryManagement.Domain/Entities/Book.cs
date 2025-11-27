namespace LibraryManagement.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Title {get;set;}  =string.Empty;
        public string Author {get;set;} = string.Empty;
        public string Category {get;set;} =string.Empty;
         public string ISBN { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public string Edition { get; set; } = string.Empty;
        public int Quantity { get; set; }

        ICollection<Loan> Loans {get;set;} = new List<Loan>();


    }
}