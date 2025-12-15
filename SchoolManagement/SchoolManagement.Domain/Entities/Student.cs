using SchoolManagement.Domain.Common;
using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.Domain.Entities
{
    public class Student:AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        public readonly List<Enrollment> _enrollments = new();
        public IReadOnlyCollection<Enrollment> Enrollments =>_enrollments.AsReadOnly();

        private Student(){}

        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                  throw new DomainException("First name is required.");
            }

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            RegisteredAt = DateTime.UtcNow;
        }

        public void Enroll(Classroom classroom)
        {
            
        }
    }
}