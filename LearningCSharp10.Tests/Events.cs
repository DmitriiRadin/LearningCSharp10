namespace LearningCSharp10.Tests;

public class Events
{
    private delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    private class ItemStore
    {
        public event PriceChangedHandler PriceChanged = null!;

        public void ChangePrice(decimal oldPrice, decimal newPrice)
        {
            PriceChanged?.Invoke(oldPrice, newPrice);
        }
    }

    [Test]
    public void Method()
    {
        var itemStore = new ItemStore();

        itemStore.PriceChanged += OnPriceChanged;

        var isInvoked = false;

        itemStore.ChangePrice(10, 20);

        isInvoked.Should().BeTrue();

        void OnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            isInvoked = true;
            oldPrice.Should().Be(10);
            newPrice.Should().Be(20);
        }
    }
}