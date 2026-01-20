using System;

namespace Event
{
    // 1. Delegate definition (defines the signature of the event handler, what kind of methods can subscribe)
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    class Program
    {
        static void Main(string[] args)
        {
            // Simple Event:
                // - Custom delegate
                // - Lebih singkat
                // - Cocok untuk contoh dasar

            // Standard Event Pattern:
                // - EventArgs subclass
                // - EventHandler<T>
                // - Protected virtual On<EventName>()
                // - Dipakai di library & framework .NET

            // event keyword:
                // - Prevents external invocation
                // - Prevents delegate reassignment
                // - Allows only += and -= from outside


            // 1. SIMPLE EVENT (Custom Delegate)

            SimpleStock simpleStock = new SimpleStock("ABC");

            // SUbscribe to the event using +=
            simpleStock.PriceChanged += SimpleOnPriceChanged;

            simpleStock.Price = 100;
            simpleStock.Price = 120;      // Triggers the event

            // Unsubscribe using -=
            simpleStock.PriceChanged -= SimpleOnPriceChanged;


            // 2. Standard .NET Event Pattern

            StandardStock standardStock = new StandardStock("ABCDE");

            // Subscribe to the event
            standardStock.PriceChanged += StandardPriceChanged;
            
            standardStock.Price = 200;
            standardStock.Price = 250;  // Triggers the event


        }

        // Subscriber method for simple event
        static void SimpleOnPriceChanged(decimal oldPrice, decimal newPrice)
        {
            System.Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");
        }

        // Subscriber for standard event pattern
        static void StandardPriceChanged(object sender, PriceChangedEventArgs e)
        {
            System.Console.WriteLine($"[Standard] Price changed from {e.OldPrice} to {e.NewPrice}");
        }
    }

    // public class Broadcaster
    // {
    //     // 2. Event declaration
    //     public event PriceChangedHandler PriceChanged;      // 'PriceChanged' is an event
    // }
    

    // Broadcaster / Publisher
    public class SimpleStock
    {
        string symbol;
        decimal price;

        public SimpleStock(string symbol) => this.symbol = symbol;

        // Event declaration
        // Outside this class, only += and -= are allowed
        public event PriceChangedHandler PriceChanged;      

        public decimal Price
        {
            get => price;
            set
            {
                if(price == value) return;      // Exit if price hasn't changed

                decimal oldPrice = price;
                price = value;

                // Only invoke if there are subscribers
                if (PriceChanged != null)       // Check for null (no subscribers)
                {
                    PriceChanged(oldPrice, price);      // Fire the event (invokes the delegate)
                }
            }
        }
    }

    // EventArgs class for passing event data
    public class PriceChangedEventArgs : EventArgs
    {
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }

        public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
        {
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
    public class StandardStock
    {
        string symbol;
        decimal price;

        public StandardStock(string symbol)
        {
            this.symbol = symbol;
        }

        // Use built-in EventHandler<TEventArgs>
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        // Protected virtual method to raise the event
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            // Thread-safe invocation
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (price == value) return;

                decimal oldPrice = price;
                price = value;

                // Raise event through the On-method
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }
}