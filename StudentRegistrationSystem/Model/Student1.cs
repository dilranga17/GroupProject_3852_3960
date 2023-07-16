using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Model
{
    public class Student1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int RegisterNumber { get; set; }

        public ObservableCollection<Module> Modules { get; set; }

        public double GPA { get; set; }

        public double CalcGPA()
        {

            //Student? selectedStudent = sele

            double Gpa;
            int totCredit = 0;
            double gradePoint;
            double totGradePoint = 0;

            foreach (Module module in Modules)
            {
                int credit = module.Credits;



                switch (module.Grade)
                {
                    case "A":
                        gradePoint = 4.00;
                        break;
                    case "B":
                        gradePoint = 3.00;
                        break;
                    case "C":
                        gradePoint = 2.00;
                        break;
                    case "D":
                        gradePoint = 1.00;
                        break;
                    case "E":
                        gradePoint = 0.00;
                        credit = 0;
                        break;
                    default:
                        gradePoint = 0.00;
                        credit = 0;

                        break;
                }
                totCredit = totCredit + credit;

                if (gradePoint > 0)
                {
                    totGradePoint = totGradePoint + (gradePoint * credit);

                }

            }
            if (totGradePoint > 0)
            {

                Gpa = totGradePoint / totCredit;

            }
            else
            {
                Gpa = 0.0;
            }
            //selectedStudent.GPA = Gpa;
            return Gpa;

        }
    }
}
