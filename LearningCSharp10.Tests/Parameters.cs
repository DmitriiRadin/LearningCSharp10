namespace LearningCSharp10.Tests;

public class Parameters
{
    [Test]
    public void ChangeValueOfPrimitiveReferenceParameter()
    {
        var actual = 15;

        ChangeValue(ref actual);

        actual.Should().Be(10);

        static void ChangeValue(ref int parameter) => parameter -= 5;
    }
}