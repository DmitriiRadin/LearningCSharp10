namespace LearningCSharp10.Tests;

public class Indices
{
    [Test]
    public void ThrowExceptionIfIndexIsOutOfRange()
    {
        var action = () =>
        {
            var array = Array.Empty<int>();
            var result = array[^2];
        };

        action.Should().Throw<IndexOutOfRangeException>();
    }

    [Test]
    public void ReturnMeaningfulResultIfIndexCorrect()
    {
        var array = new[] { 1, 2, 3, 4, 5 };

        array[^2].Should().Be(4);
    }
}