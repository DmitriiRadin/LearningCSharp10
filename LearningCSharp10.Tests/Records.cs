namespace LearningCSharp10.Tests;

public class Records
{
    private record Point(int X, int Y)
    {
        public int Z { get; init; }
    }

    [Test]
    public void ComparisonOfRecords()
    {
        var firstPoint = new Point(5, 6);
        var secondPoint = new Point(5, 6);

        (firstPoint == secondPoint).Should().BeTrue();
    }

    [Test]
    public void MutationOfRecords()
    {
        var point = new Point(5, 6)
        {
            Z = 7
        };

        var updatedPoint = point with { X = 3, Y = 5, Z = 4 };

        updatedPoint.Should().Be(new Point(3, 5) { Z = 4 });
    }
}