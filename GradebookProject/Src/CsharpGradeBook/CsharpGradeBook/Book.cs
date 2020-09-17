using System;
using System.Collections.Generic;

namespace GradeBook

{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : NamedObject //Book inherits namedObject
    {
        public Book(string name) : base(name)  //Constructor to initialize the List, i.e the grades
        {
            grades = new List<double>();
            Name = name;
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics() //The method that performs all implicit computations
        {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue; //This sets highest grade to the smallest possible floating point precision value
            result.Low = double.MaxValue; //This alsos sets the lowest grade to the highest possible floating point precision value


            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High); //math.Max returns the max of two paramaters passed to it
                result.Low = Math.Min(grade, result.Low); //math.Min returns the min of two parameter values passed to it

                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 70.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 50.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 45.0:
                    result.Letter = 'D';
                    break;

                case var d when d >= 40.0:
                    result.Letter = 'E';
                    break;

                case var d when d < 40.0:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }


            public void AddGrade(char letter)
            {
                grades.Add(letter);
            }


            public void AddGrade(double Score)
            {
                if (Score <= 100 && Score >= 0)
                {
                    grades.Add(Score);
                    if(GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(Score)}!, Please Enter a valid Score between '0' to '100'!!\n");
                }
            }
            
        private List<double> grades;
       
    }
}
