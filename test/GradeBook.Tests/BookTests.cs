using Gradebook;

namespace GradeBook.Tests;

public class BookTests
{

    [Fact]
    public void CheckStatistics()
    {
        var book2 = new InMemoryBook("Adityas Book");
        book2.AddGrade(55);
        book2.AddGrade(65);
        book2.AddGrade(75);
        

        var res = book2.GetStatistics();
        var lowest = res.low;
        var highest = res.high;
        var average = res.Average;
        var letterGrade = res.Letter;


        Assert.Equal(55,lowest,1);
        Assert.Equal(75,highest,1);
        Assert.Equal(65,average,1);
        Assert.Equal('D',letterGrade);

    }
}