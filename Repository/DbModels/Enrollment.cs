using Model.Enums;


namespace Repository.DbModels
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
}
