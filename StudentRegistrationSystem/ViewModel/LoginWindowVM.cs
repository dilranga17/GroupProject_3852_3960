using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows;
using StudentRegistrationSystem.View;

namespace StudentRegistrationSystem.ViewModel
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;



        [RelayCommand]
        public void Login()
        {
            if (UserName != null)
            {
                using (var database = new DatabaseContext())
                {
                    bool present = database.Users.Any(prsn => prsn.Name == UserName && prsn.Password == Password);

                    if (present)
                    {
                        bool isadmin = database.Users.Any(prsn => prsn.Name == UserName && prsn.Password == Password && prsn.isAdmin);
                        
                        StudentWindow window = new StudentWindow();
                        window.Show();
                        
                       
                        CloseCurrentWindow();

                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorect");

                    }


                }



            }


        }

        private void CloseCurrentWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Close();
                }
            }
        }
    }
}
