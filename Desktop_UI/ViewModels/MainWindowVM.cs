using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Desktop_UI;

namespace Desktop_UI.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedstudent;







        [RelayCommand]
        public void AddStudent()
        {
            var st = new AddUserVM();

            AddUserWindow window = new AddUserWindow(st);
            window.ShowDialog();

            if (st.Student.FirstName != null)
            {
                users.Add(st.Student);
            }
            
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedstudent != null)
            {
                string name = selectedstudent.FirstName;
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you want to delete {name}?", "conformation", MessageBoxButton.YesNo);


                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    users.Remove(selectedstudent);
                    MessageBox.Show($"{name} is Deleted successfuly.", "DELETE \a ");
                }
                else
                {

                }



            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error!!");
            }
        }


        [RelayCommand]
        public void EditStudent()
        {
            if (selectedstudent != null)
            {
                var st = new AddUserVM(selectedstudent);
                var window = new AddUserWindow(st);

                window.ShowDialog();


                int index = users.IndexOf(selectedstudent);
                users.RemoveAt(index);
                users.Insert(index, st.Student);

            }
            else
            {
                MessageBox.Show("Please Select the student Before Edit", "Warning!!");
            }
        }


        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            users.Add(new User("Balasinkam", "Vithusan", 24, "03/05/1999", 2.91, image1));

            BitmapImage image2 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            users.Add(new User("Thavamohan", "Thananchayan", 23, "21/7/2000", 3.75, image2));

            BitmapImage image3 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            users.Add(new User("Rasalinkam", "Sathursan", 23, "14/10/2000", 3.45, image3));

            BitmapImage image4 = new BitmapImage(new Uri("/Images/10.png", UriKind.Relative));
            users.Add(new User("Sakayanathan", "Gorge Dilen", 23, "19/11/2000", 3.05, image4));

            BitmapImage image5 = new BitmapImage(new Uri("/Images/9.png", UriKind.Relative));
            users.Add(new User("Richard", "Nitharsan", 23, "29/1/2000", 2.99, image4));

            BitmapImage image6 = new BitmapImage(new Uri("/Images/8.png", UriKind.Relative));
            users.Add(new User("Razil", "Ahammed", 23, "09/12/2000", 3.99, image4));

        }

    }
}

