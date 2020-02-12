using System.Collections.Generic;
using System;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : BookBase, IBook
    {
        private List<double> grades;

        public string Title
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public string Description
        {
            get;
            private set;
        }

        public const string CATEGORY = "Science";

        public Book(string name) : base(name)
        {
            this.grades = new List<double>();
        }

        public void SetGrades(List<double> grades)
        {
            this.grades = grades;
        }

        public override void AddGrade(double grade)
        {
            this.grades.Add(grade);

            if (this.GradeAdded != null)
            {
                this.GradeAdded(this, new EventArgs());
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    this.AddGrade(90);
                    break;
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(70);
                    break;
                case 'D':
                    this.AddGrade(60);
                    break;
                default:
                    this.AddGrade(0);
                    break;
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public void ShowStatistic()
        {
            var statistics = this.GetStatistics();

            Console.WriteLine($"The average grade is {statistics.Average:N2}");
            Console.WriteLine($"The highest grade is {statistics.High:N2}");
            Console.WriteLine($"The lowest grade is {statistics.Low:N2}");
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();

            statistics.Average = this.GetAverageGrade();
            statistics.High = this.GetHighestGrade();
            statistics.Low = this.GetLowestGrade();

            return statistics;
        }

        public double GetHighestGrade()
        {
            var highest = 0.0;

            foreach (double grade in grades) {
                highest = Math.Max(highest, grade);
            }

            return highest;
        }

        public double GetLowestGrade()
        {
            var lowest = double.MaxValue;

            foreach (double grade in grades) {
                lowest = Math.Min(lowest, grade);
            }

            return lowest;
        }

        public double GetAverageGrade()
        {
            var sum = 0.0;

            foreach (double grade in grades) {
                sum += grade;
            }

            return sum / grades.Count;
        }

        public override string DoSomething()
        {
            return base.DoSomething() + "15";
        }
    }
}
