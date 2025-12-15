using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain.Entities
{
    public class Teacher:AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime HireDate { get; private set; }

    private Teacher() { }
     public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        HireDate = DateTime.UtcNow;
    }
    }
}