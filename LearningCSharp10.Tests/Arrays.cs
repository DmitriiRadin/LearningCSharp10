namespace LearningCSharp10.Tests;

public class Arrays
{
    [Test]
    public void InvokeMethodWithSimplifiedArrayInitialization()
    {
        int[] numbers = { 1, 2, 3 };

        SomeMethod(numbers);
        SomeMethod(new[] { 1, 2, 3 });

        static void SomeMethod(IEnumerable<int> numbers)
        {
            numbers.Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }
    }
}