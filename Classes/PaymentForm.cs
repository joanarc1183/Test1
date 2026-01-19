// PaymentForm.cs
// This file is written and maintained by the developer

partial class PaymentForm
{
    // Partial method implementation
    partial void ValidatePayment(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        if (amount > 1000)
        {
            Console.WriteLine("Large payment detected.");
        }
    }
}
