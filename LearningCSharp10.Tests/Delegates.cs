namespace LearningCSharp10.Tests;

public class Delegates
{
    private delegate int Transformer(int x);

    private static int Square(int x) => x * x;

    [Test]
    public void AssignMethodToDelegate()
    {
        Transformer transformer = Square;

        transformer(2).Should().Be(4);
    }

    private class CubeTransformer
    {
        private readonly int _pow;

        public CubeTransformer()
        {
            _pow = 3;
        }

        public int Transform(int number)
        {
            var result = number;

            for (var i = 1; i < _pow; i++)
            {
                result *= number;
            }

            return result;
        }
    }

    [Test]
    public void AssignMethodOfClassWithCapturedVariableToDelegate()
    {
        var cubeTransformer = new CubeTransformer();

        Transformer transformer = cubeTransformer.Transform;

        transformer(2).Should().Be(8);
    }

    [Test]
    public void AssignMulticastDelegate()
    {
        Transformer transformer = Square;
        transformer += new CubeTransformer().Transform;

        transformer(2).Should().Be(8);
    }

    private delegate T Transformer<T>(T arg);

    public class NumbersStore
    {
        public List<int> Numbers { get; init; } = new();
    }

    [Test]
    public void AssignGenericMethodToDelegate()
    {
        var originalNumberStore = new NumbersStore
        {
            Numbers = new List<int>
            {
                1, 2, 3, 4
            }
        };

        Transformer<NumbersStore> numberStoreTransform = TransformNumberStore;

        var actualNumberStore = numberStoreTransform(originalNumberStore);

        actualNumberStore.Numbers.Should().BeEquivalentTo(new List<int> { 1, 4, 9, 16 });

        static NumbersStore TransformNumberStore(NumbersStore numbersStore) =>
            new()
            {
                Numbers = numbersStore.Numbers
                    .Select(p => p * p)
                    .ToList()
            };
    }
}