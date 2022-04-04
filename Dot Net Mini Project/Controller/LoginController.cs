using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dot_Net_Mini_Project;

namespace Dot_Net_Mini_Project.Controller
{
    class LoginController
    {
        //User Login
        private const string SecurityKey = "ComplexKeyHere_12121";
        public static void UserLogin()
        {
            MyDbContext myDbContext = new MyDbContext();

            Console.Write("\nEnter userName: ");
            var userName = Console.ReadLine().ToLower();

            Console.Write("Enter password: ");
            var password = Console.ReadLine().ToLower();

            Console.Write("Enter category: ");
            var category = Console.ReadLine();

            Console.Write("Enter Role: ");
            var role = Console.ReadLine();


            bool isfound = false;
            User user1 = null;
            foreach (User user in myDbContext.users)
            {
                if (user.UserName.Equals(userName) && AdminController.DecryptCipherTextToPlainText(user.Password).Equals(password) && user.Category.Equals(category) && user.Role.Equals(role))
                {
                    isfound = true;
                    user1 = user;
                    Console.WriteLine("login succesfully");
                    Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------");
                    break;
                }

            }
            if (isfound == false)
            {
                Console.WriteLine("Incorrect Credentials....");
            }

            if (user1 != null)
            {

                if (user1.Role == "User")
                {
                    Console.WriteLine("Well-Come to " + user1.Category + " Department " + user1.UserName + " your id is " + user1.UserId);
                    bool flag2 = true;
                    while (flag2)
                    {

                        Console.WriteLine("\n1:Fetch Product        2:Add Product       3:Update Product        4:Remove Product\n5:Exit");
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                        Console.Write("Enter your choice : ");
                        var choice2 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        switch (choice2)
                        {
                            case 1:

                                if (user1.Category == "Airpod")
                                {
                                    AirpodController.FetchAirpodData(myDbContext, user1);
                                }
                                else if (user1.Category == "Mobile")
                                {
                                    IphoneController.FetchIphoneData(myDbContext, user1);
                                }
                                else if (user1.Category == "Tablet")
                                {
                                    IpadController.FetchIpadData(myDbContext, user1);
                                }
                                else if (user1.Category == "Watch")
                                {
                                    IwatchController.FetchIwatchData(myDbContext, user1);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter valid category!");
                                }

                                break;
                            case 2:

                                if (user1.Category.Equals("Airpod"))
                                {
                                    AirpodController.AddAirpodData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Mobile"))
                                {
                                    IphoneController.AddIphoneData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Tablet"))
                                {
                                    IpadController.AddIpadData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Watch"))
                                {
                                    IwatchController.AddIwatchData(myDbContext, user1);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter valid category!");
                                }
                                break;
                            case 3:
                                if (user1.Category.Equals("Airpod"))
                                {
                                    AirpodController.FetchAirpodData(myDbContext, user1);
                                    AirpodController.UpdateAirpodData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Mobile"))
                                {
                                    IphoneController.FetchIphoneData(myDbContext, user1);
                                    IphoneController.UpdateIphoneData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Tablet"))
                                {
                                    IpadController.FetchIpadData(myDbContext, user1);
                                    IpadController.UpdateIpadData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Watch"))
                                {
                                    IwatchController.FetchIwatchData(myDbContext, user1);
                                    IwatchController.UpdateIwatchData(myDbContext, user1);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter valid category!");
                                }
                                break;
                            case 4:
                                if (user1.Category.Equals("Airpod"))
                                {
                                    AirpodController.FetchAirpodData(myDbContext, user1);
                                    AirpodController.RemoveAirpodData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Mobile"))
                                {
                                    IphoneController.FetchIphoneData(myDbContext, user1);
                                    IphoneController.RemoveIphoneData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Tablet"))
                                {
                                    IpadController.FetchIpadData(myDbContext, user1);
                                    IpadController.RemoveIpadData(myDbContext, user1);
                                }
                                else if (user1.Category.Equals("Watch"))
                                {
                                    IwatchController.FetchIwatchData(myDbContext, user1);
                                    IwatchController.RemoveIwatchData(myDbContext, user1);
                                }
                                else
                                {
                                    Console.WriteLine("Please enter valid category!");
                                }
                                break;
                            case 5:
                                flag2 = false;
                                Console.WriteLine("Exited Successfully...");
                                break;
                            default:
                                Console.WriteLine("Please Enter Valid Choice");
                                break;
                        }
                    }
                }
            }
        }

        //Admin Login
        public static void AdminLogin()
        {
            MyDbContext myDbContext = new MyDbContext();
            Console.Write("Enter userName: ");
            var userName = Console.ReadLine().ToLower();

            Console.Write("Enter password: ");
            var password = Console.ReadLine().ToLower();

            bool isFound = false;
            User user2 = null;

            foreach (User user in myDbContext.users)
            {
                if (user.UserName.Equals(userName) && user.Password.Equals(password))
                {
                    isFound = true;
                    user2 = user;
                    Console.WriteLine("Login successfull");

                    Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------");

                    break;
                }

            }

            if (isFound == false)
            {
                Console.WriteLine("Invalid credentials");
            }
            if (user2 != null)

            {

                if (user2.Role.Equals("Admin"))
                {
                    //Console.WriteLine("Well-Come Admin " + user2.Category + " Department " + user2.UserName + " your id is" + user2.UserId);
                    //Console.WriteLine("All user with id and Category ");
                    bool flag3 = true;
                    while (flag3)
                    {
                        Console.WriteLine("\n1:Fetch User     2:Add User      3:Remove User\n\n4:Fetch Product Data         5:Add Product       6:Update Product Data       7: Remove Product \n\n8:Exit");

                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        Console.Write("Enter your choice : ");
                        var choices = Convert.ToInt32(Console.ReadLine());

                        switch (choices)
                        {
                            case 1:
                                Console.WriteLine();
                                Console.WriteLine("Result-");
                                AdminController.FetchUsers();
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                break;
                            case 2:
                                Console.WriteLine();
                                AdminController.AddUser();
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                break;
                            case 3:
                                Console.WriteLine();
                                AdminController.RemoveUser();
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                break;
                            case 4:
                                bool flag4 = true;
                                while (flag4)
                                {
                                    Console.WriteLine("Fetch By Category\n1:Mobile\n2:Tablet\n3:Airpod\n4:Iwatch\n5:Exit");
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                                    var choices3 = Convert.ToInt32(Console.ReadLine());

                                    switch (choices3)
                                    {
                                        case 1:
                                            IphoneController.FetchIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;

                                        case 2:
                                            IpadController.FetchIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 3:
                                            AirpodController.FetchAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 4:
                                            IwatchController.FetchIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 5:
                                            flag4 = false;
                                            Console.WriteLine("Exited Sucessfully!");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        default:
                                            Console.WriteLine("Please Enter Valid Choice");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                    }
                                }
                                break;
                            case 5:
                                bool flag5 = true;

                                while (flag5)
                                {
                                    Console.WriteLine("Add By Category\n1:Mobile\n2:Tablet\n3:Airpod\n4:Iwatch\n5:Exit");
                                    AdminController.FetchUserId();
                                    var choice4 = Convert.ToInt32(Console.ReadLine());

                                    switch (choice4)
                                    {
                                        case 1:
                                            IphoneController.AddIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 2:
                                            IpadController.AddIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 3:
                                            AirpodController.AddAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 4:
                                            IwatchController.AddIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 5:
                                            flag5 = false;
                                            Console.WriteLine("Exited Sucessfully!");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        default:
                                            Console.WriteLine("Please Enter Valid Choice");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                    }
                                }
                                break;
                            case 6:
                                bool flag6 = true;

                                while (flag6)
                                {
                                    Console.WriteLine("Update By Category\n1:Mobile\n2:Tablet\n3:Airpod\n4:Iwatch\n5:Exit");
                                    var choice5 = Convert.ToInt32(Console.ReadLine());
                                    AdminController.FetchUserId();
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                    switch (choice5)
                                    {
                                        case 1:
                                            IphoneController.FetchIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IphoneController.UpdateIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 2:
                                            IpadController.FetchIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IpadController.UpdateIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 3:
                                            AirpodController.FetchAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            AirpodController.UpdateAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 4:
                                            IwatchController.FetchIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IwatchController.UpdateIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 5:
                                            flag6 = false;
                                            Console.WriteLine("Exited Sucessfully!");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        default:
                                            Console.WriteLine("Please Enter Valid Choice");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                    }
                                }
                                break;
                            case 7:
                                bool flag7 = true;

                                while (flag7)
                                {
                                    Console.WriteLine("Remove By Category\n1:Mobile\n2:Tablet\n3:Airpod\n4:Iwatch\n5:Exit");
                                    var choice6 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                                    switch (choice6)
                                    {
                                        case 1:
                                            IphoneController.FetchIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IphoneController.RemoveIphoneData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 2:
                                            IpadController.FetchIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IpadController.RemoveIpadData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 3:
                                            AirpodController.FetchAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            AirpodController.RemoveAirpodData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 4:
                                            IwatchController.FetchIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            IwatchController.RemoveIwatchData(myDbContext, user2);
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        case 5:
                                            flag7 = false;
                                            Console.WriteLine("Exited Sucessfully!");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                        default:
                                            Console.WriteLine("Please Enter Valid Choice");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            break;
                                    }
                                }
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                                break;
                            case 8:
                                flag3 = false;
                                Console.WriteLine("Exited Sucessfully!");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                break;
                            default:
                                Console.WriteLine("Please Enter Valid Choice");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                break;
                        }
                    }

                }
            }
        }

        //Password Encription
        public static string EncryptPlainTextToCipherText(string PlainText)
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

    }
}
