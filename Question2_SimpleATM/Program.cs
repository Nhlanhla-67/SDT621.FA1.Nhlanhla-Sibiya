
namespace Question2_SimpleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== CTU SIMPLE ATM SYSTEM =====");
            Console.WriteLine("HI WHAT IS YOUR NAME?");
            Console.Write("> ");
            string customerName = Console.ReadLine();

            Console.WriteLine($"\nWELCOME {customerName.ToUpper()}!");
            
            Console.Write("Enter account balance: ");
            double accountBalance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            double withdrawalAmount = Convert.ToDouble(Console.ReadLine());

            // Check if the user has enough money to withdraw
            if (withdrawalAmount <= accountBalance)
            {
                accountBalance -= withdrawalAmount;
                Console.WriteLine("\nWithdrawal successful!");
                Console.WriteLine($"Updated Balance: {accountBalance:F2}");
                Console.WriteLine($"Transaction Time: {DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}");
            }
            else
            {
                Console.WriteLine("\nInsufficient funds for this transaction.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}