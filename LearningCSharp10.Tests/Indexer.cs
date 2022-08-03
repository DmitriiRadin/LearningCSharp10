namespace LearningCSharp10.Tests;

public class Indexer
{
    [Test]
    public void GetAndSetValueByIndexCorrectly()
    {
        var sentence = new Sentence("Hello world from Dima");

        sentence[0].Should().Be("Hello");
        sentence[3] = "Aleksey";

        sentence[3].Should().Be("Aleksey");
    }

    private class Sentence
    {
        private readonly string[] _words;

        public Sentence(string sentence)
        {
            _words = sentence.Split(" ");
        }

        public string this[int wordNumber]
        {
            get => _words[wordNumber];
            set => _words[wordNumber] = value;
        }
    }
}