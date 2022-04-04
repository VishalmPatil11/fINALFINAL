using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot_Net_Mini_Project.Controller
{
    class IphoneController
    {
        
        //Fetch Iphone Data
        public static void FetchIphoneData(MyDbContext myDbContext, User user)
        {
            Console.WriteLine("IphoneId |    IphoneName   | Quantity |     Price");
            
            foreach (var item in myDbContext.iphones)
            {                
                Console.WriteLine(item.IphoneId + "             " + item.IphoneName + "        " + item.Quantity + "         " + item.Price);
            }
        }

        //Add Iphone data
        public static void AddIphoneData(MyDbContext myDbContext, User user)
        {
            try
            {

                Iphone iphone = new Iphone();

                Console.Write("Please Enter the IphoneName: ");
                iphone.IphoneName = Console.ReadLine();

                Console.Write("Please Enter the Quantity: ");
                iphone.Quantity = Convert.ToInt32(Console.ReadLine());


                Console.Write("Please Enter Price: ");
                iphone.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("please enter the userId: ");
                iphone.UserId = Convert.ToInt32(Console.ReadLine());

                myDbContext.iphones.Add(iphone);
                myDbContext.SaveChanges();

                Console.WriteLine("Product added sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e); 
            }
        }

        //Update Iphone Data
        public static void UpdateIphoneData(MyDbContext myDbContext, User user)
        {
            try
            {
                Console.WriteLine("Enter IphoneId: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Updated Price: ");
                var priceUpdated = Convert.ToDecimal(Console.ReadLine());

                Iphone iphone = myDbContext.iphones.Find(id);
                iphone.Price = priceUpdated;
                myDbContext.iphones.Update(iphone);

                Console.WriteLine(myDbContext.SaveChanges());

                Console.WriteLine("Product updated sucessfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        //Remove Iphone Data
        public static void RemoveIphoneData(MyDbContext myDbContext, User user)
        {
            try
            {
                Iphone iphone = new Iphone();

                Console.Write("Enter IphoneId: ");
                iphone.IphoneId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please Enter the UserId: ");
                iphone.UserId = Convert.ToInt32(Console.ReadLine());


                var removeProductData = myDbContext.iphones.First(x => x.IphoneId == iphone.IphoneId);

                myDbContext.iphones.Remove(removeProductData);

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
