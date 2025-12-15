namespace SchoolManagement.Domain.Entities
{
    public class Enrollment
    {
        public Guid StudentId { get; private set; }
        public Guid ClassroomId { get; private set; }
        public DateTime EnrolledAt { get; private set; }

        private Enrollment(){}

        public Enrollment(Guid studentId, Guid classroomId)
        {
            StudentId = studentId;
            ClassroomId = classroomId;
            EnrolledAt = DateTime.UtcNow;
        }
    }
}