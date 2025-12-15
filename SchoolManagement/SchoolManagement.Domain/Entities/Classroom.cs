using SchoolManagement.Domain.Common;
using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.Domain.Entities
{
    public class Classroom:AggregateRoot
    {
        public string Title { get; private set; }
        public int Capacity { get; private set; }
        public Guid TeacherId { get; private set; }

        private List<Enrollment> _enrollments = new();

         public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

         private Classroom(){}

         public Classroom(string title, int capacity,Guid teacherId)
        {
            if (capacity <= 0)
                throw new DomainException("Capacity must be greater than zero.");

            Title = title;
            Capacity = capacity;
            TeacherId = teacherId;
        }

        internal void AddStudent(Student student)
        {
            if(_enrollments.Count>=Capacity)
            {
                throw new DomainException("Classroom capacity is full.");
            }
        }
    }
}