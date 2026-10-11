namespace StudentGradeManagement
{
    /// <summary>
    /// Main Windows Forms UI for the Student Grade Management System
    /// </summary>
    public partial class GradeManagementForm : Form
    {
        private GradeManager gradeManager = new GradeManager();

        public GradeManagementForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Student Grade Management System";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Create main panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // Title
            Label titleLabel = new Label
            {
                Text = "Student Grade Management System",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            mainPanel.Controls.Add(titleLabel);

            // Input Section
            Panel inputPanel = CreateInputPanel();
            inputPanel.Location = new Point(10, 50);
            mainPanel.Controls.Add(inputPanel);

            // Buttons Panel
            Panel buttonPanel = CreateButtonPanel();
            buttonPanel.Location = new Point(10, 150);
            mainPanel.Controls.Add(buttonPanel);

            // Display Section
            Panel displayPanel = CreateDisplayPanel();
            displayPanel.Location = new Point(10, 250);
            mainPanel.Controls.Add(displayPanel);

            this.Controls.Add(mainPanel);
        }

        private Panel CreateInputPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(850, 90),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label nameLabel = new Label
            {
                Text = "Student Name:",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(nameLabel);

            TextBox nameTextBox = new TextBox
            {
                Name = "nameTextBox",
                Location = new Point(120, 10),
                Width = 250,
                Height = 25
            };
            panel.Controls.Add(nameTextBox);

            Label gradeLabel = new Label
            {
                Text = "Grade (0-100):",
                AutoSize = true,
                Location = new Point(390, 10)
            };
            panel.Controls.Add(gradeLabel);

            TextBox gradeTextBox = new TextBox
            {
                Name = "gradeTextBox",
                Location = new Point(520, 10),
                Width = 100,
                Height = 25
            };
            panel.Controls.Add(gradeTextBox);

            Label searchLabel = new Label
            {
                Text = "Search Name:",
                AutoSize = true,
                Location = new Point(10, 50)
            };
            panel.Controls.Add(searchLabel);

            TextBox searchTextBox = new TextBox
            {
                Name = "searchTextBox",
                Location = new Point(120, 50),
                Width = 250,
                Height = 25
            };
            panel.Controls.Add(searchTextBox);

            return panel;
        }

        private Panel CreateButtonPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(850, 90),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button addButton = new Button
            {
                Text = "Add Student",
                Location = new Point(10, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            addButton.Click += (s, e) => AddStudent();
            panel.Controls.Add(addButton);

            Button displayButton = new Button
            {
                Text = "Display All",
                Location = new Point(120, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            displayButton.Click += (s, e) => DisplayAllStudents();
            panel.Controls.Add(displayButton);

            Button searchButton = new Button
            {
                Text = "Search",
                Location = new Point(230, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            searchButton.Click += (s, e) => SearchStudent();
            panel.Controls.Add(searchButton);

            Button averageButton = new Button
            {
                Text = "Average",
                Location = new Point(340, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(107, 105, 123),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            averageButton.Click += (s, e) => ShowAverageGrade();
            panel.Controls.Add(averageButton);

            Button statsButton = new Button
            {
                Text = "Statistics",
                Location = new Point(450, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(107, 105, 123),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            statsButton.Click += (s, e) => ShowStatistics();
            panel.Controls.Add(statsButton);

            Button clearButton = new Button
            {
                Text = "Clear All",
                Location = new Point(560, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            clearButton.Click += (s, e) => ClearAllRecords();
            panel.Controls.Add(clearButton);

            Button removeButton = new Button
            {
                Text = "Remove",
                Location = new Point(670, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            removeButton.Click += (s, e) => RemoveStudent();
            panel.Controls.Add(removeButton);

            Button exitButton = new Button
            {
                Text = "Exit",
                Location = new Point(780, 10),
                Size = new Size(60, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            exitButton.Click += (s, e) => this.Close();
            panel.Controls.Add(exitButton);

            return panel;
        }

        private Panel CreateDisplayPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(850, 400),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label displayLabel = new Label
            {
                Text = "Display Area:",
                AutoSize = true,
                Location = new Point(10, 10),
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            panel.Controls.Add(displayLabel);

            ListBox displayListBox = new ListBox
            {
                Name = "displayListBox",
                Location = new Point(10, 35),
                Size = new Size(825, 350),
                Font = new Font("Courier New", 10)
            };
            panel.Controls.Add(displayListBox);

            return panel;
        }

        private void AddStudent()
        {
            try
            {
                TextBox nameTextBox = (TextBox)GetControlByName("nameTextBox");
                TextBox gradeTextBox = (TextBox)GetControlByName("gradeTextBox");

                string name = nameTextBox.Text.Trim();
                if (!int.TryParse(gradeTextBox.Text, out int grade))
                {
                    MessageBox.Show("Invalid grade. Please enter a number between 0 and 100.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gradeManager.AddStudent(name, grade);
                MessageBox.Show($"Student '{name}' added successfully with grade {grade}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTextBox.Clear();
                gradeTextBox.Clear();
                DisplayAllStudents();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DisplayAllStudents()
        {
            ListBox displayListBox = (ListBox)GetControlByName("displayListBox");
            displayListBox.Items.Clear();

            var students = gradeManager.GetAllStudents();
            if (students.Count == 0)
            {
                displayListBox.Items.Add("No students in the system.");
                return;
            }

            displayListBox.Items.Add("========== ALL STUDENTS ==========");
            foreach (var student in students.OrderByDescending(s => s.Value))
            {
                var category = GetGradeCategory(student.Value);
                displayListBox.Items.Add($"{student.Key,-30} Grade: {student.Value:D2}  Category: {category}");
            }
            displayListBox.Items.Add($"Total Students: {gradeManager.GetStudentCount()}");
        }

        private void SearchStudent()
        {
            try
            {
                TextBox searchTextBox = (TextBox)GetControlByName("searchTextBox");
                ListBox displayListBox = (ListBox)GetControlByName("displayListBox");

                string name = searchTextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a student name to search.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? grade = gradeManager.SearchStudent(name);
                displayListBox.Items.Clear();

                if (grade.HasValue)
                {
                    var category = GetGradeCategory(grade.Value);
                    displayListBox.Items.Add($"========== SEARCH RESULT ==========");
                    displayListBox.Items.Add($"Name: {name}");
                    displayListBox.Items.Add($"Grade: {grade}");
                    displayListBox.Items.Add($"Category: {category}");
                }
                else
                {
                    displayListBox.Items.Add($"Student '{name}' not found in the system.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAverageGrade()
        {
            ListBox displayListBox = (ListBox)GetControlByName("displayListBox");
            displayListBox.Items.Clear();

            if (gradeManager.GetStudentCount() == 0)
            {
                displayListBox.Items.Add("No students in the system to calculate average.");
                return;
            }

            double average = gradeManager.CalculateAverageGrade();
            displayListBox.Items.Add("========== GRADE STATISTICS ==========");
            displayListBox.Items.Add($"Average Grade: {average:F2}");
            displayListBox.Items.Add($"Total Students: {gradeManager.GetStudentCount()}");
        }

        private void ShowStatistics()
        {
            ListBox displayListBox = (ListBox)GetControlByName("displayListBox");
            displayListBox.Items.Clear();

            if (gradeManager.GetStudentCount() == 0)
            {
                displayListBox.Items.Add("No students in the system.");
                return;
            }

            double average = gradeManager.CalculateAverageGrade();
            int? highest = gradeManager.GetHighestGrade();
            int? lowest = gradeManager.GetLowestGrade();
            var topStudents = gradeManager.GetTopStudents();
            var lowestStudents = gradeManager.GetLowestStudents();

            displayListBox.Items.Add("========== DETAILED STATISTICS ==========");
            displayListBox.Items.Add($"Total Students: {gradeManager.GetStudentCount()}");
            displayListBox.Items.Add($"Average Grade: {average:F2}");
            displayListBox.Items.Add($"Highest Grade: {highest}");
            displayListBox.Items.Add($"Lowest Grade: {lowest}");
            displayListBox.Items.Add("");
            displayListBox.Items.Add("Top Performer(s):");
            foreach (var student in topStudents)
            {
                displayListBox.Items.Add($"  - {student}: {gradeManager.SearchStudent(student)}");
            }
            displayListBox.Items.Add("");
            displayListBox.Items.Add("Lowest Performer(s):");
            foreach (var student in lowestStudents)
            {
                displayListBox.Items.Add($"  - {student}: {gradeManager.SearchStudent(student)}");
            }
        }

        private void RemoveStudent()
        {
            try
            {
                TextBox nameTextBox = (TextBox)GetControlByName("nameTextBox");
                string name = nameTextBox.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a student name to remove.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (gradeManager.RemoveStudent(name))
                {
                    MessageBox.Show($"Student '{name}' removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nameTextBox.Clear();
                    DisplayAllStudents();
                }
                else
                {
                    MessageBox.Show($"Student '{name}' not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllRecords()
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all student records? This action cannot be undone.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                gradeManager.ClearAllRecords();
                ListBox displayListBox = (ListBox)GetControlByName("displayListBox");
                displayListBox.Items.Clear();
                displayListBox.Items.Add("All records cleared.");
                MessageBox.Show("All student records have been cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Control GetControlByName(string name)
        {
            foreach (Control control in this.GetAllControls())
            {
                if (control.Name == name)
                    return control;
            }
            return null;
        }

        private IEnumerable<Control> GetAllControls(Control container = null)
        {
            if (container == null)
                container = this;

            foreach (Control control in container.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        private string GetGradeCategory(int grade)
        {
            return grade switch
            {
                >= 90 => "Excellent",
                >= 80 => "Good",
                >= 70 => "Fair",
                >= 60 => "Pass",
                _ => "Fail"
            };
        }
    }
}
