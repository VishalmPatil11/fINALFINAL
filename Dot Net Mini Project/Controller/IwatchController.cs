using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot_Net_Mini_Project.Controller
{
    class IwatchController
    {
        //Fetch Iwatch Data
        public static void FetchIwatchData(MyDbContext myDbContext, User user)
        {

            Console.WriteLine(user.UserName + "        " + user.Category);
            MyDbContext myDbContext1 = new MyDbContext();

            Console.WriteLine("IwatchId |    IwatchName   | Quantity |     Price");
            
            foreach (var item in myDbContext1.iwatches)
            {                
                Console.WriteLine(item.IwatchId + "             " + item.IwatchName + "        " + item.Quantity + "         " + item.Price);
            }
        }

        //Add Iwatch Data
        public static void AddIwatchData(MyDbContext myDbContext, User user)
        {
            try
            {
                Iwatch iwatch = new Iwatch();

                Console.Write("Please Enter the IwatchName: ");
                iwatch.IwatchName = Console.ReadLine();

                Console.Write("Please Enter the Quantity: ");
                iwatch.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter Price: ");
                iwatch.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("please enter the userId: ");
                iwatch.UserId = Convert.ToInt32(Console.ReadLine());

                myDbContext.iwatches.Add(iwatch);
                myDbContext.SaveChanges();

                Console.WriteLine("Product added sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); 
            }
        }

        //Update Iwatch Data
        public static void UpdateIwatchData(MyDbContext myDbContext, User user)
        {
            try
            {
                Console.WriteLine("Enter IwatchId: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Updated Price: ");
                var priceUpdated = Convert.ToDecimal(Console.ReadLine());

                Iwatch iwatch = myDbContext.iwatches.Find(id);
                iwatch.Price = priceUpdated;
                myDbContext.iwatches.Update(iwatch);

                Console.WriteLine(myDbContext.SaveChanges());

                Console.WriteLine("Product updated sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        //Remove Iwatch Data
        public static void RemoveIwatchData(MyDbContext myDbContext, User user)
        {
            try
            {
                Iwatch iwatch = new Iwatch();

                Console.Write("Enter IwatchId: ");
                iwatch.IwatchId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter the UserId: ");
                iwatch.UserId = Convert.ToInt32(Console.ReadLine());

                var removeProductData = myDbContext.iwatches.First(x => x.IwatchId == iwatch.IwatchId);

                myDbContext.iwatches.Remove(removeProductData);

                myDbContext.SaveChanges();

                Console.WriteLine("product removed sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }

        }        
    }
}

