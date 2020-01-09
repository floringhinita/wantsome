namespace DependencyInversionDatabaseAfter.Static
{
    public interface IDatabase
    {
        public static IEnumerable<int> CourseIds();

        public static IEnumerable<string> CourseNames();

        public static IEnumerable<string> Search(string substring);

        public static string GetCourseById(int id);
    }
}