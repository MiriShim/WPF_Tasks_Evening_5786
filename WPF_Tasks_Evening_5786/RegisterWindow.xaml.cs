using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPF_Tasks_Evening_5786.Models;

namespace WPF_Tasks_Evening_5786
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        //CRUD:
       //CREATE, Read, Update, Delete
        private void SaveNewPerson(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text.Length<2 || tbLastName.Text.Length < 2)
            {
                MessageBox.Show("חובה לספק שם פרטי ושם משפחה");
                return;
            }

            if (pass1.Password != pass2.Password)
            {
                MessageBox.Show("הסיסמאות אינן תואמות!");
                return;
            }

            Person newPerson = new Person() 
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                DateOfBirth = DateOnly.FromDateTime(dpBirthdate.SelectedDate ?? DateTime.Today) ,
                UserPassword = pass1.Password
            };
            //יצירת מופע של הקשר-מסד-הנתונים  כדי לשמור את האדם החדש
            try
            {
                //הקשר הוא אובייקט שמייצג את החיבור למסד הנתונים,
                //ומאפשר לנו לבצע פעולות כמו הוספה, עדכון, מחיקה ושליפת נתונים

                using (PesachTasksDbContext context = new PesachTasksDbContext())
                {
                    //C: Create
                    context.People.Add(newPerson);
                    context.SaveChanges();
                } // כאן כבר מתבצע שחרור המשאבים של הקשר למסד הנתונים - מנקה את הזיכרון
            }
            catch  
            {
                MessageBox.Show("אירעה שגיאה בעת  הגישה למסד הנתונים לשמירת המשתמש:" );
                return;
            }   
            MessageBox.Show("נשמר בהצלחה");

        }

        private void GoToListOfPerson(object sender, RoutedEventArgs e)
        {
            PeoplsWindow pw = new PeoplsWindow();
            
            pw.ShowDialog();
           
        }
    }
}
