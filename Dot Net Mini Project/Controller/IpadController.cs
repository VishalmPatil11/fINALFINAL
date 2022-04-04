using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot_Net_Mini_Project.Controller
{
    class IpadController
    {
        //Fetch Ipad Data
        public static void FetchIpadData(MyDbContext myDbContext, User user)
        {

            //Console.WriteLine(user.UserName + "        " + user.Category);
            MyDbContext myDbContext1 = new MyDbContext();
            Console.WriteLine("IpadId |    IpadName   | Quantity |     Price");
                        
            foreach (var item in myDbContext1.ipads)
            {
                Console.WriteLine(item.IpadId + "           " + item.IpadName + "        " + item.Quantity + "         " + item.Price);
            }
        }

        //Add Ipad data 
        public static void AddIpadData(MyDbContext myDbContext, User user)
        {
            try
            {
                Ipad ipad = new Ipad();
                validateName();
                void validateName()
                {
                    Console.Write("Please Enter the IpadName: ");
                    ipad.IpadName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(user.UserName) || user.UserName.All(char.IsDigit))
                    {
                        Console.WriteLine("Please enter valid name");
                        validateName();
                    }
                }
                
                Console.Write("Please Enter the Quantity: ");
                ipad.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter Price: ");
                ipad.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("please enter the userId: ");
                ipad.UserId = Convert.ToInt32(Console.ReadLine());

                myDbContext.ipads.Add(ipad);
                myDbContext.SaveChanges();

                Console.WriteLine("Product added sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); 
            }
        }

        //Update Ipad Data
        public static void UpdateIpadData(MyDbContext myDbContext, User user)
        {
            try
            {
                Console.WriteLine("Enter IpadId: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Updated Price: ");
                var priceUpdated = Convert.ToDecimal(Console.ReadLine());

                Ipad ipad = myDbContext.ipads.Find(id);
                ipad.Price = priceUpdated;
                myDbContext.ipads.Update(ipad);

                Console.WriteLine(myDbContext.SaveChanges());

                Console.WriteLine("Product updated sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
        }

        //Remove Ipad Data
        public static void RemoveIpadData(MyDbContext myDbContext, User user)
        {
            try
            {
                Ipad ipad = new Ipad();

                Console.Write("Enter IpadId: ");
                ipad.IpadId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter the UserId: ");
                ipad.UserId = Convert.ToInt32(Console.ReadLine());

                var removeProductData = myDbContext.ipads.First(x => x.IpadId == ipad.IpadId);

                myDbContext.ipads.Remove(removeProductData);

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
