namespace RainbowSchoolMarksApi.Models
{
    public class StudentMark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}
