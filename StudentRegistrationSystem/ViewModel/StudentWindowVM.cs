using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Model;

namespace StudentRegistrationSystem.ViewModel
{
    public partial class StudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student1> student1s;

        [ObservableProperty]
        public Student1 selectedStudent;


        [ObservableProperty]
        public Module selectedModule;
        [ObservableProperty]
        public ObservableCollection<Module> modulesList;
        public string _firstName;
        public string _lastName; //tele
        public string _moduleCode;
        public string _moduleName; //addre
        public string _grade;
        public string _modCoordinatorId; //reg id

        //Name
        public string FirstName
        {
            get
            {
                return _firstName;

            }
            set
            {
                if (_firstName == value)
                {
                    return;
                }
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));

            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName == value)
                {
                    return;
                }
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string ModuleName
        {
            get
            {
                return _moduleName;
            }
            set
            {
                if (_moduleName == value)
                {
                    return;
                }
                _moduleName = value;
                OnPropertyChanged(nameof(ModuleName));
            }
        }

        public string Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                if (_grade == value)
                {
                    return;
                }
                _grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }

        public string ModuleCode
        {
            get
            {
                return _moduleCode;
            }
            set
            {
                if (_moduleCode == value)
                {
                    return;
                }
                _moduleCode = value;
                OnPropertyChanged(nameof(ModuleCode));
            }
        }


        public string ModCoordintorId
        {
            get
            {
                return _modCoordinatorId;
            }
            set
            {
                if (_modCoordinatorId == value)
                {
                    return;
                }
                _modCoordinatorId = value;
                OnPropertyChanged(nameof(ModCoordintorId));
            }
        }


        public void getModules()
        {
            using (var db = new DatabaseContext())
            {
                List<Module> mods = db.Modules.ToList();
                modulesList = new ObservableCollection<Module>(

                   mods

                    );
            }
        }

        public StudentWindowVM()
        {
            getModules();
            ReadData();
        }


        [RelayCommand]
        public void AddModule()
        {
            if (SelectedModule != null)
            {

                if (!ModulesList.Contains(SelectedModule))
                {
                    ModulesList.Add(SelectedModule);
                }
            }
        }

        [RelayCommand]
        public void AddStudent()
        {
            using (var db = new DatabaseContext())
            {
                if (ModCoordintorId != null)
                {




                    var l = new Student1
                    {
                        Id = Int32.Parse(ModCoordintorId),
                        Name = FirstName,
                        Address = ModuleName,
                        Modules = ModulesList,


                    };

                       l.GPA = l.CalcGPA();
                    db.Students1.Add(l

                        );





                    db.SaveChanges();
                }
            }
        }


        [RelayCommand]
        public void EditStudent()
        {
            using (var db = new DatabaseContext())
            {
                if (ModCoordintorId != null)
                {

                    Student1 newe = db.Students1.Find(SelectedStudent);

                    newe.PhoneNumber = LastName;
                    newe.Name = FirstName;
                    newe.Address = ModuleName;
                    newe.Modules = ModulesList;

                    db.SaveChanges();
                }
            }
        }

        [RelayCommand]

        public void DeleteStudent()
        {
            using (var db = new DatabaseContext())
            {
                Student1 newe = db.Students1.Find(SelectedStudent);
                db.Students1.Remove(newe);
                db.SaveChanges();
            }
        }

        [RelayCommand]
        public void ReadData()
        {
            using (var db = new DatabaseContext())
            {
                List<Student1> mods = db.Students1.ToList();
                Student1s = new ObservableCollection<Student1>(

                   mods

                    );
            }
        }
    }
}
