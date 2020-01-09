namespace DependencyInversionDatabaseAfter
{
	public interface IDatabase
    {
        public IEnumerable<int> CourseIds();

        public IEnumerable<string> CourseNames();

        public IEnumerable<string> Search(string substring);

        public string GetCourseById(int id);
    }
}