using System.Diagnostics;

namespace LearningCSharp10.Tests;

public class Deconstructors
{
    private class Rectangle
    {
        public float Width { get; init; }
        public float Height { get; init; }

        public void Deconstruct(out float width, out float height)
        {
            width = Width;
            height = Height;
        }
    }

    [Test]
    public void DeconstructElementProperly()
    {
        var rectangle = new Rectangle
        {
            Width = 10,
            Height = 20
        };

        var (width, height) = rectangle;

        width.Should().Be(10);
        height.Should().Be(20);
    }

    [Test]
    public void DeconstructElementViaExtensionMethodProperly()
    {
        var rectangle = new RectangleWithoutDeconstructMethod
        {
            Width = 10,
            Height = 20
        };

        var (width, height) = rectangle;

        width.Should().Be(10);
        height.Should().Be(20);
    }
}

public class RectangleWithoutDeconstructMethod
{
    public float Width { get; init; }
    public float Height { get; init; }
}

public static class RectangleWithoutDeconstructMethodExtensions
{
    public static void Deconstruct(this RectangleWithoutDeconstructMethod obj,
        out float width,
        out float height)
    {
        width = obj.Width;
        height = obj.Height;
    }
}