using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace RegistrationInFile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("Data.txt") == false)
            {
                File.Create("Data.txt");
            }
        }

        private void btnLogin1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Data.txt") == true && txtFirstName.Text != "" && txtLastName.Text != " " && txtAge.Text != "")
            {
                MessageBox.Show($"{txtFirstName.Text} {txtLastName.Text} {txtAge.Text}", "Запись создана успешно!");
                SaveFileClass.FileWriteLine($"{(File.ReadLines("Data.txt").Count()) + 1}@{txtFirstName.Text}@{txtLastName.Text}@{txtAge.Text}", "Data.txt");
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAge.Text = "";

                WorkWin workwin = new WorkWin();
                this.Hide();
                workwin.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            //else
            //{
            //    MessageBox.Show($"{txtFirstName.Text} {txtLastName.Text} {txtAge.Text}", "Запись создана успешно!");
            //    SaveFileClass.FileWriteLine($"{txtFirstName.Text} {txtLastName.Text} {txtAge.Text}", "Data.txt");
            //}
        }


        private void txtAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void txtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int vai;
            if (int.TryParse(e.Text, out vai))
            {
                e.Handled = true;
            }
        }

        private void txtFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int vai;
            if (int.TryParse(e.Text, out vai))
            {
                e.Handled = true;
            }
        }

        private void btnClose1_Click(object sender, RoutedEventArgs e)
        {
            WorkWin workwin = new WorkWin();
            this.Hide();
            workwin.ShowDialog();
            this.Show();
        }
    }
}
