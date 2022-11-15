using CoinJarServices;

namespace CoinJar
{
    public class Program
    {
        public static void Main()
        {
            var _service = new CoinJarService();
            var input = "";
            while (input != "4")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Hello, would you like to :");
                Console.ResetColor();
                Console.WriteLine("(1) Add a Coin?  ");
                Console.WriteLine("(2) View total amount of Coins?");
                Console.WriteLine("(3) Clear the Jar of all coins?");
                Console.WriteLine("(4) Exit?");
                Console.ResetColor();
                var userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Please Enter the amount of you coin?");
                    Console.ResetColor();
                    var amount = Convert.ToInt32(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Please Enter the volume of ${amount}");
                    Console.ResetColor();
                    var volume = Convert.ToInt32(Console.ReadLine());

                    _service.AddCoin(new CoinService
                    {
                        Amount = amount,
                        Volume = volume
                    });                           
                }

                if (userInput == "2")
                {
                    var totalAmount = _service.GetVolume();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"The total amount in the jar is ${totalAmount}");
                    Console.ResetColor();
                }

                if(userInput == "3")
                {
                    _service.Reset();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"All your coins have been sucessfully removed :)");
                    Console.ResetColor();
                }

                if(userInput == "4")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Hope you enjoyed the game. Bye!");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}

