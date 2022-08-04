namespace LearningCSharp10.Tests;

public class Ranges
{
    private readonly int[] _numbers = { 1, 2, 3, 4, 5 };

    [Test]
    public void ThrowExceptionOnOutOfRange()
    {
        var action = () =>
        {
            var slice = _numbers[3..7];
        };

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void ReturnCorrectSlice()
    {
        _numbers[2..4]
            .Should()
            .BeEquivalentTo(new[] { 3, 4 });
    }
}