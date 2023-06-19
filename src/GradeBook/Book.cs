using System.Collections.Generic;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook{
        void AddGrade(double grade);
        statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book :NamedObject,  IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
             
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
       
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded!= null)
                {
                    GradeAdded(this , new EventArgs());
                }
                writer.Dispose();
            }
        }

        public override statistics GetStatistics()
        {
            var grades = new List<double>();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                
                var num = reader.ReadLine();
                if(num != null)
                {
                   var grade = double.Parse(num);
                   grades.Add(grade);
                }
            }
            Console.WriteLine(grades);
            var result = new statistics(grades);
            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(String name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
    
        // Add a valid grade else thow exception
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade < 100)
            {
                grades.Add(grade);
                if(GradeAdded!= null)
                {
                    GradeAdded(this,new EventArgs());
                }
            }

            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            

        }

        public override event GradeAddedDelegate GradeAdded;

        // Methods to check value and reference types
        public int CheckType()
        {
            var x = 10;
            Console.WriteLine($"The actual number is {x}");
            return x;
        }

        public int AssignNumByvalue(int y)
        {
            var x = y;
            Console.WriteLine($"The number assigned through value is {x}");
            return x;
        }

        public int AssignNumByRef(ref int y)
        {
            var x = y;
            Console.WriteLine($"The number assigned through reference is {x}");
            return x;
        }

        // Method to get statistics on entered grades
        public override statistics GetStatistics()
        {   
            var result = new statistics(grades);
            return result;

        }

        private List<double> grades;
       
        public const string CATEGORY = "Science";
    }
}