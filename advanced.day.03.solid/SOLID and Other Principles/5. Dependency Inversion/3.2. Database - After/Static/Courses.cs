namespace DependencyInversionDatabaseAfter.Static
{
    public class Courses
    {
        public IDatabase db;
        public Courses(IDatabase db)
        {
            this.db = db;
        }

        public void PrintAll()
        {
            var courses = this.db.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = this.db.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = this.db.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = this.db.Search(substring);

            // print courses
        }
    }
}
