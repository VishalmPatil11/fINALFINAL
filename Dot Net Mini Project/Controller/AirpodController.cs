using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot_Net_Mini_Project.Controller
{
    class AirpodController
    {
        //Fetch Airpod Data
        public static void FetchAirpodData(MyDbContext myDbContext, User user)
        {           
            MyDbContext myDbContext1 = new MyDbContext();
            
            Console.WriteLine("AirpodID |    AirpodName   | Quantity |     Price");
            foreach (var item in myDbContext1.airpods)
            {
                Console.WriteLine(item.AirpodId+ "             " + item.AirpodName + "        " + item.Quantity + "         " + item.Price);
            }
        }

        //Add Airod Data
        public static void AddAirpodData(MyDbContext myDbContext, User user)
        {
            try
            {
                Airpod airpod = new Airpod();
                validateAirpodName();
                void validateAirpodName()
                {
                    Console.Write("Please Enter the airpodName: ");
                    airpod.AirpodName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(airpod.AirpodName) || airpod.AirpodName.All(char.IsDigit))
                    {
                        Console.WriteLine("Please enter valid airpodName");
                        validateAirpodName();
                    }
                }
                try
                {
                    Console.Write("Please Enter the Quantity: ");
                    airpod.Quantity = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Quantity should be in Number");
                    Console.WriteLine(e.Message);
                }

                Console.Write("Please Enter Price: ");
                airpod.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("please enter the userId: ");
                airpod.UserId = Convert.ToInt32(Console.ReadLine());

                myDbContext.airpods.Add(airpod);
                myDbContext.SaveChanges();

                Console.WriteLine("Product added sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
        }

        //Update Airpod data
        public static void UpdateAirpodData(MyDbContext myDbContext, User user)
        {

            try
            {
                Console.WriteLine("Enter AirpodId: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Updated Price: ");
                var priceUpdated = Convert.ToDecimal(Console.ReadLine());

                Airpod airpod = myDbContext.airpods.Find(id);
                airpod.Price = priceUpdated;
                myDbContext.airpods.Update(airpod);

                Console.WriteLine(myDbContext.SaveChanges());

                Console.WriteLine("Product updated sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); 
            }
        }

        //Remove Airpod
        public static void RemoveAirpodData(MyDbContext myDbContext, User user)
        {
            try
            {
                Airpod airpod = new Airpod();

                Console.Write("Enter AirpodId: ");
                airpod.AirpodId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter the UserId: ");
                airpod.UserId = Convert.ToInt32(Console.ReadLine());

                var removeProductData = myDbContext.airpods.First(x => x.AirpodId == airpod.AirpodId);

                myDbContext.airpods.Remove(removeProductData);

                myDbContext.SaveChanges();
                Console.WriteLine("product removed sucessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
