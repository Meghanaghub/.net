using Gradebook;

namespace GradeBook.Tests;

public delegate string writeLogDelegate(string logMessage);

public class TypeTests
{
    int count = 0;

    [Fact]
    public void WriteLodDelegateCanPointToMethod()
    {
        writeLogDelegate log = IncrementMessage;
        log += ReturnMessage;
        log += IncrementMessage;

        var result = log("Hello");
        Assert.Equal("Hello",result);
        Assert.Equal(2,count);
    }

    string IncrementMessage(string Message)
    {
        count++;
        return Message;
    }
    
    string ReturnMessage(string Message)
    {
        return Message;
    }
    
    [Fact]

    public void CheckValueType()
    {
        var book1 = new InMemoryBook(" ");
        var expected_num = book1.CheckType();
        var actual_num = book1.AssignNumByvalue(10);

        Assert.Equal(expected_num,actual_num);
    }

    public void CheckRefType()
    {
        var book1 = new InMemoryBook(" ");
        var expected_num = book1.CheckType();
        var y = 20;
        var actual_num = book1.AssignNumByRef(ref y);

        Assert.Equal(expected_num,actual_num);
    }

}