namespace LearningCSharp10.Tests;

public class Switch
{
    [Test]
    public void SwitchingOnTypes()
    {
        const int number = 5;

        var result = GetStringInterpretationOfObjectType(number);

        result.Should().Be("This is exact match");

        static string GetStringInterpretationOfObjectType<T>(T obj) where T : notnull
        {
            return obj switch
            {
                int intObj5 when intObj5 == 5 => "This is exact match",
                int intObj => $"This is int {intObj}",
                string stringObj => $"This is string {stringObj}",
                _ => obj.GetType().Name
            };
        }
    }
}