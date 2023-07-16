using System.Collections.Generic;
using Xunit;
using FluentAssertions;

using StudentRegistrationSystem.Model;
using System.Collections.ObjectModel;

namespace StudentRegistrationSystem.Tests
{
    public class StudentGPATests
    {
        [Fact]
        public void WhenNoModules_ReturnsZeroGPA()
        {
            var student = new Student1
            {
                Modules = new ObservableCollection<Module>()
            };

            double gpa = student.CalcGPA();

            gpa.Should().Be(0.0);
        }

        [Fact]
        public void WhenModulesHaveGrades_CalculatesCorrectGPA()
        {
            var modules = new ObservableCollection<Module>
            {
                new Module { Credits=2, Grade = "A" },
                new Module { Credits = 2, Grade = "B" },
                new Module { Credits = 3, Grade = "C" }
            };

            var student = new Student1
            {
                Modules = modules
            };

            double gpa = student.CalcGPA();

            gpa.Should().BeApproximately(2.85, 0.01);
        }

        [Fact]
        public void WhenAllModuleGradesAreE_ReturnsZeroGPA()
        {
            var modules = new ObservableCollection<Module>
            {
                new Module { Credits = 2, Grade = "E" },
                new Module { Credits = 7, Grade = "E" },
                new Module { Credits = 1, Grade = "E" }
            };

            var student = new Student1
            {
                Modules = modules
            };

            double gpa = student.CalcGPA();

            gpa.Should().Be(0.0);
        }


        [Fact]
        public void WhenSingleModuleWithGrade_CalculatesCorrectGPA()
        {
            var modules = new ObservableCollection<Module>
            {
                new Module { Credits = 2 , Grade = "B" }
            };

            var student = new Student1
            {
                Modules = modules
            };

            double gpa = student.CalcGPA();

            gpa.Should().BeApproximately(3.0, 0.01);
        }

        [Fact]
        public void WhenModulesHaveInvalidGrades_ReturnsZeroGPA()
        {
            var modules = new ObservableCollection<Module>
            {
                new Module { Credits = 5, Grade = "Z" },
                new Module { Credits = 5, Grade = "Y" },
                new Module { Credits = 5, Grade = "X" }
            };

            var student = new Student1
            {
                Modules = modules
            };

            double gpa = student.CalcGPA();

            gpa.Should().Be(0.0);
        }

        [Fact]
        public void WhenModulesHaveMixedValidAndInvalidGrades_CalculatesCorrectGPA()
        {
            var modules = new ObservableCollection<Module>
            {
                new Module { Credits = 1, Grade = "A" },
                new Module { Credits = 2, Grade = "X" },
                new Module { Credits = 3, Grade = "B" },
                new Module { Credits = 1, Grade = "Y" }
            };

            var student = new Student1
            {
                Modules = modules
            };

            double gpa = student.CalcGPA();

            gpa.Should().BeApproximately(3.25, 0.01);
        }
    }
}
