namespace Gradebook
{

    public class statistics
    {

        public double Average;
        public double low;
        public double high;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';


                    case var d when d >= 80:
                        return 'B';


                    case var d when d >= 70:
                        return 'C';


                    case var d when d >= 60:
                        return 'D';


                    default:
                        return 'F';

                }

            }
        }

        public statistics(List<double> grades)
        {
            high = grades.Max();
            low = grades.Min();
            Average = grades.Average();

        }
    }
}