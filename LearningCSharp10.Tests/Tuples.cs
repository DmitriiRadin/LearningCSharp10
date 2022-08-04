namespace LearningCSharp10.Tests;

public class Tuples
{
    [Test]
    public void CreateTupleType()
    {
        var (name, age) = (Name: "Bob", Age: 23);

        name.Should().Be("Bob");
        age.Should().Be(23);
    }

    [Test]
    public void ReturnTupleTypeFromFunction()
    {
        var (name, age) = GetUser();

        name.Should().Be("Bob");
        age.Should().Be(23);

        static (string Name, int Age) GetUser()
        {
            return ("Bob", 23);
        }
    }

    [Test]
    public void CompareTuplesByUnderlyingData()
    {
        var t1 = ("one", 1);
        var t2 = ("one", 1);

        (t1 == t2).Should().BeTrue();
    }
}