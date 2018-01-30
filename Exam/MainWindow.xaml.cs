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
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employers;
        public MainWindow()
        {
            InitializeComponent();
            employers = new ObservableCollection<Employee>();
            employeeData.ItemsSource = employers;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            employers.Add(new Employee
            {
                Id=Guid.NewGuid(),
                Name = "Введите имя...",
                Division = "Введите должность...",
            });
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            employers.Remove((Employee)employeeData.SelectedItem);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Employee>));
            using(FileStream fs= new FileStream("employee.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs,employers);
            }
            MessageBox.Show("Сохранено в employee.json");
        }
    }
}
