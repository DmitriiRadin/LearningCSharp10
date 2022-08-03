namespace LearningCSharp10.Tests;

public class RefLocals
{
    [Test]
    public void ChangeArrayElementByRef()
    {
        var numbers = new[] { 1, 2, 3, 4 };

        ref var numberRef = ref numbers[2];

        numberRef = 5;

        numbers.Should().BeEquivalentTo(new[] { 1, 2, 5, 4 });
    }

    private static string _refReturnsStaticVariable = "Old value";

    private static ref string GetStaticVariable() => ref _refReturnsStaticVariable;

    [Test]
    public void RefReturns()
    {
        ref var staticVariable = ref GetStaticVariable();
        staticVariable = "5";

        staticVariable.Should().Be(_refReturnsStaticVariable);
    }
}