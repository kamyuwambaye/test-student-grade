namespace StudentGradeManagement
{
    /// <summary>
    /// Represents a student with name and grade information
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.", nameof(name));

            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.", nameof(grade));

            Name = name;
            Grade = grade;
        }

        public GradeCategory GetGradeCategory()
        {
            return Grade switch
            {
                >= 90 => GradeCategory.Excellent,
                >= 80 => GradeCategory.Good,
                >= 70 => GradeCategory.Fair,
                >= 60 => GradeCategory.Pass,
                _ => GradeCategory.Fail
            };
        }

        public override string ToString()
        {
            return $"{Name}: {Grade} ({GetGradeCategory()})";
        }
    }
}
