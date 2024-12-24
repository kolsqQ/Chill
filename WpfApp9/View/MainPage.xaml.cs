using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static ObservableCollection<LessonList> Lessons = new ObservableCollection<LessonList>();

        public MainPage()
        {
            InitializeComponent();
            LessonsBox.ItemsSource = Lessons; 
        }

        private void AddLesson_Click(object sender, RoutedEventArgs e)
        {
            var addLessonWindow = new AddLesoon();
            if (addLessonWindow.ShowDialog() == true)
            {
                var newLesson = addLessonWindow.NewLesson;
                Lessons.Add(newLesson); 
                LessonsBox.ItemsSource = null;
                LessonsBox.ItemsSource = Lessons;
            }
        }

        private void LessonsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveLesson_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsBox.SelectedItem != null)
            {
                var selectedLesson = LessonsBox.SelectedItem as LessonList;
                Lessons.Remove(selectedLesson);

            }
        }
    }
}
