namespace StudentGradeManagement
{
    /// <summary>
    /// Manages student records and grade operations
    /// </summary>
    public class GradeManager
    {
        private Dictionary<string, int> students = new Dictionary<string, int>();

        /// <summary>
        /// Adds a new student with their grade
        /// </summary>
        public void AddStudent(string name, int grade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            // Update if student exists, otherwise add new
            if (students.ContainsKey(name))
                students[name] = grade;
            else
                students.Add(name, grade);
        }

        /// <summary>
        /// Removes a student from the records
        /// </summary>
        public bool RemoveStudent(string name)
        {
            return students.Remove(name);
        }

        /// <summary>
        /// Searches for a student and returns their grade
        /// </summary>
        public int? SearchStudent(string name)
        {
            if (students.TryGetValue(name, out int grade))
                return grade;
            return null;
        }

        /// <summary>
        /// Gets all students
        /// </summary>
        public Dictionary<string, int> GetAllStudents()
        {
            return new Dictionary<string, int>(students);
        }

        /// <summary>
        /// Calculates the average grade of all students
        /// </summary>
        public double CalculateAverageGrade()
        {
            if (students.Count == 0)
                return 0;

            return students.Values.Average();
        }

        /// <summary>
        /// Finds the highest grade
        /// </summary>
        public int? GetHighestGrade()
        {
            return students.Count > 0 ? students.Values.Max() : null;
        }

        /// <summary>
        /// Finds the lowest grade
        /// </summary>
        public int? GetLowestGrade()
        {
            return students.Count > 0 ? students.Values.Min() : null;
        }

        /// <summary>
        /// Gets the student(s) with the highest grade
        /// </summary>
        public List<string> GetTopStudents()
        {
            if (students.Count == 0)
                return new List<string>();

            int maxGrade = students.Values.Max();
            return students.Where(s => s.Value == maxGrade).Select(s => s.Key).ToList();
        }

        /// <summary>
        /// Gets the student(s) with the lowest grade
        /// </summary>
        public List<string> GetLowestStudents()
        {
            if (students.Count == 0)
                return new List<string>();

            int minGrade = students.Values.Min();
            return students.Where(s => s.Value == minGrade).Select(s => s.Key).ToList();
        }

        /// <summary>
        /// Gets total number of students
        /// </summary>
        public int GetStudentCount()
        {
            return students.Count;
        }

        /// <summary>
        /// Clears all student records
        /// </summary>
        public void ClearAllRecords()
        {
            students.Clear();
        }
    }
}
