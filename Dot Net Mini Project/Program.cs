using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using Dot_Net_Mini_Project.Controller;


namespace Dot_Net_Mini_Project
{
    class Program
    {

        static void Main(string[] args)
        {            
            bool flag = true;

            while (flag)
            {
                Console.Title = "Inventory Management System";
                Console.ForegroundColor = ConsoleColor.Cyan;

                string title = @"

  ___                 _                  __  __                                       _     ___         _             
 |_ _|_ ___ _____ _ _| |_ ___ _ _ _  _  |  \/  |__ _ _ _  __ _ __ _ ___ _ __  ___ _ _| |_  / __|_  _ __| |_ ___ _ __  
  | || ' \ V / -_) ' \  _/ _ \ '_| || | | |\/| / _` | ' \/ _` / _` / -_) '  \/ -_) ' \  _| \__ \ || (_-<  _/ -_) '  \ 
 |___|_||_\_/\___|_||_\__\___/_|  \_, | |_|  |_\__,_|_||_\__,_\__, \___|_|_|_\___|_||_\__| |___/\_, /__/\__\___|_|_|_|
                                  |__/                        |___/                             |__/                  

";

                Console.WriteLine(title);
                Console.ResetColor();

                //Admin Added 
                //var myDbContext1 = new MyDbContext();

                /*Admin Added to database*/

                //Controller myController = new Controller();
                //User user = new User() { UserName = "vishal", Email = "vishalmil@cyb.com", Password = "1234", Category = "Products", Role = "Admin" };
                //ctx.users.Add(user);
                //Console.WriteLine(ctx.SaveChanges());

                Console.WriteLine("Enter Choice: ");
                Console.WriteLine("\n     1:Admin      2:User      3:Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                Console.Write("Enter your choice : ");
                var choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");


                switch (choice)
                {
                    case 1:

                        if (choice == 1)
                        {
                            LoginController.AdminLogin();
                        }
                        else Console.WriteLine("Please give right options");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        break;
                    case 2:
                        if (choice == 2)
                        {
                            LoginController.UserLogin();
                        }
                        else Console.WriteLine("Please give right options");
                        Console.WriteLine
                        ("----------------------------------------------------------------------------------------------------------------------");
                        break;
                    case 3:
                        flag = false;
                        Console.WriteLine("Exited Successfully...");
                        Console.WriteLine
                        ("----------------------------------------------------------------------------------------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Choice");
                        Console.WriteLine
                        ("----------------------------------------------------------------------------------------------------------------------");
                        break;
                }
            }
        }
    }
}