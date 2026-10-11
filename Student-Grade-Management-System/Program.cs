namespace StudentGradeManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GradeManagementForm());
        }
    }
}
