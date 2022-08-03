namespace LearningCSharp10.Tests;

public class ConstantInterpolatedStrings
{
    [Test]
    public void InterpolateConstantStrings()
    {
        const string greeting = "Hello";
        const string message = $"{greeting}, world";

        message.Should().Be("Hello, world");
    }
}