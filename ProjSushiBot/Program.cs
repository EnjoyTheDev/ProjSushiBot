using System;
using Newtonsoft.Json;
using ProjSushiBot.Customer;
using ProjSushiBot.Logger;
using ProjSushiBot.Sushi;

namespace project
{
  class Program
  {
    static void Main(string[] args)
    {
      Logger logger = new Logger();
      logger.StartLog();
      logger.Debug();
      MailSender mailSender = new MailSender();

      string json = @"{

            'name': [ 'Nigiri', 'Sashimi', 'Maki', 'Uramaki', 'Temaki', 'Hokigai', 'Kanpachi' ],

            'quantity': [ 25, 14, 33, 12, 27, 11, 23 ],

                            }";
      Sushi sushi = JsonConvert.DeserializeObject<Sushi>(json/*File.ReadAllText("sushidata.json")*/);

      logger.Info("Deserialize");

      Customer customer = new Customer();
      Console.WriteLine("\n Hello. Sushi chatbot at your service!");
      Console.WriteLine("\n What's you name?");
      customer.Name = Console.ReadLine();

      Console.WriteLine("\n Sushi that are available:");
      int counter = sushi.name.Length;
      logger.Info("input sushi list");

      for (int i = 0; i < counter; i++)
      {
        Console.WriteLine($"{i + 1}.{sushi.name[i]}. Left:{sushi.quantity[i]}");
      }

      Console.WriteLine($"\n Enter the number of sushi you wish, {customer.Name}?");
      customer.Number = int.Parse(Console.ReadLine());

      Console.WriteLine("How many?");
      logger.Info("Order");

      int count;
      count = int.Parse(Console.ReadLine());
      while (count > sushi.quantity[customer.Number - 1])
      {
        Console.WriteLine("\n You're trying to order more than we have. Enter a smaller number, please");
        count = int.Parse(Console.ReadLine());
      }

      sushi.quantity[customer.Number - 1] -= count;
      logger.Info("Enter your email");
      Console.WriteLine("\n Enter your email");
      customer.Email = Console.ReadLine();

      logger.Info("Entering the delivery address");
      Console.WriteLine("\n What's the delivery address?");
      customer.Address = Console.ReadLine();

      logger.Info("Email send");
      mailSender.SendMail(customer.Email, "Order completed");
      System.Threading.Thread.Sleep(2000);
      mailSender.SendMail(customer.Email, "Order delivering");
      System.Threading.Thread.Sleep(9000);

      mailSender.SendMail(customer.Email, "Order delivered");
      System.Threading.Thread.Sleep(7000);
      mailSender.SendMail(customer.Email, "Order paid for");
      logger.Info("Completion of the program");

      Console.WriteLine("Thank you for using our service!");

      Console.Read();
    }
  }
}