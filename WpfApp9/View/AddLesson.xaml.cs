using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp9.View
{
    /// <summary>
    /// Логика взаимодействия для AddLesson.xaml
    /// </summary>
    public partial class AddLesoon : Window
    {
        public static List<LessonList> Lessons = new List<LessonList>();

        public LessonList NewLesson { get; set; }

        public AddLesoon()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LessonName.Text) && Start.SelectedItem != null && End.SelectedItem != null)
            {
                int start = int.Parse(((ComboBoxItem)Start.SelectedItem).Content.ToString());
                int end = int.Parse(((ComboBoxItem)End.SelectedItem).Content.ToString());

                if (end <= start)
                {
                    MessageBox.Show("Время окончания должно быть позже времени начала.");
                    return;
                }

                foreach (var lesson in Lessons)
                {
                    if ((start < lesson.End) && (end > lesson.Start))
                    {
                        MessageBox.Show("Чувак, у тебя уже есть планы на это время!");
                        return;
                    }
                }

                NewLesson = new LessonList
                {
                    Name = LessonName.Text,
                    Start = start,
                    End = end
                };

                Lessons.Add(NewLesson);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }
    }
}