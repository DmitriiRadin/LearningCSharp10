using System.Drawing;

namespace LearningCSharp10.Tests;

public class Patterns
{
    private enum Urgency
    {
        Minor,
        Normal,
        Critical
    };

    private record Task(string Title)
    {
        public string Description { get; init; } = "";
        public Urgency Urgency { get; init; } = Urgency.Normal;
        public DateTime? DeadLine { get; init; }
        public int? EstimatedHours { get; init; }
    }


    [Test]
    public void UsingOfSimplePattern()
    {
        object obj = new Task("My urgent task")
        {
            Urgency = Urgency.Critical,
            EstimatedHours = 8
        };

        if (obj is not string &&
            obj is Task
                {
                    Urgency: not Urgency.Normal and not Urgency.Minor,
                    DeadLine: null,
                    Description.Length: < 5,
                    EstimatedHours: 8
                }
                task
           )
        {
            obj = task with { DeadLine = DateTime.Today.AddDays(1) };
        }

        (obj as Task)!.DeadLine.Should().NotBeNull();
    }

    private enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall
    };

    private enum Daytime
    {
        Day,
        Night
    }

    [Test]
    public void TupleSwitch()
    {
        var averageTemperature = GetAverageCelsiusTemperature(Season.Summer, Daytime.Night);

        averageTemperature.Should().Be(22);

        static int GetAverageCelsiusTemperature(Season season, Daytime daytime) =>
            (season, daytime) switch
            {
                (Season.Spring, Daytime.Day) => 20,
                (Season.Spring, Daytime.Night) => 16,
                (Season.Summer, Daytime.Day) => 27,
                (Season.Summer, Daytime.Night) => 22,
                (Season.Fall, Daytime.Day) => 18,
                (Season.Fall, Daytime.Night) => 12,
                (Season.Winter, Daytime.Day) => 10,
                (Season.Winter, Daytime.Night) => -2,
                _ => throw new Exception("Unexpected combination")
            };
    }

    [Test]
    public void PropertyPatternWithTuple()
    {
        object obj = (X: 2, Y: 2);

        (obj is (int x, int y) && x == y).Should().BeTrue();
    }

    private record SimplePoint(int X, int Y);

    [Test]
    public void MixedSwitchAndPositionalArgument()
    {
        var targetPoint = new SimplePoint(1, 1);

        GetPointPayload(targetPoint).Should().Be(5);

        static int GetPointPayload(SimplePoint point) =>
            point switch
            {
                (2, 4) => 3,
                (1, 1) => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(point))
            };
    }

    [Test]
    public void PropertyPatternInSwitch()
    {
        ShouldAllow(new Uri("http://asdf:80")).Should().BeTrue();
        ShouldAllow(new Uri("https://asdf:21")).Should().BeFalse();

        static bool ShouldAllow(Uri uri) => uri switch
        {
            { Scheme: "http", Port: 80 } when !string.IsNullOrEmpty(uri.Host) => true,
            { Scheme: "https", Port: 443 and var port } => true,
            { Scheme: "ftp", Port: 21 } => true,
            { IsLoopback: true } => true,
            _ => false
        };
    }
}