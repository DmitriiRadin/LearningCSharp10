namespace LearningCSharp10.Tests;

public class ValueTypesVsReferenceTypes
{
    [Test]
    public void Struct_Are_Copied()
    {
        var originalPoint = new PointStruct
        {
            X = 5,
            Y = 6
        };

        var copiedPoint = originalPoint;

        originalPoint.X = 10;

        copiedPoint.X.Should().Be(5);
    }

    [Test]
    public void Classes_Are_Referenced()
    {
        var originalPoint = new PointClass
        {
            X = 5,
            Y = 6
        };

        var copiedPoint = originalPoint;

        originalPoint.X = 10;

        copiedPoint.X.Should().Be(10);
    }

    private struct PointStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    private class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}