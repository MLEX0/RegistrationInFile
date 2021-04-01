using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace RegistrationInFile
{
    /// <summary>
    /// Логика взаимодействия для WorkWin.xaml
    /// </summary>
    public partial class WorkWin : Window
    {
        List<UserClass> users = new List<UserClass>();
        public WorkWin()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader("Data.txt"))
            {
                string[] words;
                for (int i = 0; i < File.ReadLines("Data.txt").Count(); i++)
                {
                    string str = sr.ReadLine();
                    words = str.Split(new char[] {'@'});
                    users.Add(new UserClass{ 
                        Id = Convert.ToInt32(words[0]), 
                        FirstName = words[1],
                        LastName = words[2],
                        Age = Convert.ToInt32(words[3])
                    });
                }
            }

            DataGrid.ItemsSource = users;

        }
    }
}
