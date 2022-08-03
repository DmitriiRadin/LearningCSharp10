namespace LearningCSharp10.Tests;

public class Generics
{
    [Test]
    public void CheckCovariantParameters()
    {
        var myStack = new MyStack<Bear>();

        IMyPushable<Animal> bears = myStack;

        (bears.GetType().GetGenericArguments()[0] == typeof(Bear))
            .Should()
            .BeTrue();
    }

    private interface IMyPushable<out T>
    {
    }

    private class MyStack<T> : IMyPushable<T>
    {
    }

    private class Animal
    {
    }

    private class Bear : Animal
    {
    }
}