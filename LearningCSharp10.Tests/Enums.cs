namespace LearningCSharp10.Tests;

public class Enums
{
    [Test]
    public void FlagEnumHasValueAfterAddingThisValueIntoVariable()
    {
        const BorderSides sides = BorderSides.Bottom | BorderSides.Left;

        sides.HasFlag(BorderSides.Bottom).Should().BeTrue();
    }

    [Flags]
    private enum BorderSides
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8
    }
}