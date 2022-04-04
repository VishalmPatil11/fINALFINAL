using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dot_Net_Mini_Project.Controller
{
    class AdminController
    {
        private const string SecurityKey = "ComplexKeyHere_12121";

        //Fetch Users Details
        public static void FetchUsers()
        {

            MyDbContext myDbContext = new MyDbContext();
            
            Console.WriteLine("UserId |    UserName       |            Email          |         Password       |    Category     | Role");
            
            foreach (var item in myDbContext.users)
            {
                Console.WriteLine(item.UserId + "           " + item.UserName + "              " + item.Email + "               " + item.Password + "              " + item.Category + "           " + item.Role);
            }
        }

        

        //Add User
        public static void AddUser()
        {
            MyDbContext myDbContext = new MyDbContext();
            User user = new User();

            validateName();
            void validateName()
            {
                Console.WriteLine("Please Enter the FirstName");
                user.UserName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user.UserName) || user.UserName.All(char.IsDigit))
                {
                    Console.WriteLine("Please enter valid name");
                    validateName();
                }
            }
            
            validateEmail();
            void validateEmail()
            {
                Console.WriteLine("Please Enter the Email Id");
                user.Email = Console.ReadLine();

                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

                if (!Regex.IsMatch(user.Email, pattern))
                {
                    Console.WriteLine("Please enter a valid Email Id.");
                    validateEmail();
                }
            }

            validatePassword();
            void validatePassword()
            {
                string password = "";
                Console.WriteLine("Please Enter the Password");
                Console.ForegroundColor = ConsoleColor.Black;
                user.Password = EncryptPlainTextToCipherText(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 8)
                {
                    Console.WriteLine("\n Please enter password with length.");
                    validatePassword();
                }
            }

            validateCategory();
            void validateCategory()
            {
                Console.WriteLine("Please Enter the Category");
                user.Category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user.Category) || user.Category.All(char.IsDigit))
                {
                    Console.WriteLine("Please enter valid Category Name");
                    validateCategory();
                }
            }
                        
            validateRole();
            void validateRole()
            {
                Console.WriteLine("Please Enter the Role");
                user.Role = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user.Role) || user.Role.All(char.IsDigit))
                {
                    Console.WriteLine("Please enter valid Role Name");
                    validateRole();
                }
            }
            
            myDbContext.users.Add(user);
            myDbContext.SaveChanges();

            Console.WriteLine("User added sucessfully");

        }

        //Remove User 
        public static void RemoveUser()
        {
            try
            {

                MyDbContext myDbContext = new MyDbContext();
                User user = new User();

                Console.Write("Enter userId: ");
                user.UserId = Convert.ToInt32(Console.ReadLine());

                var removeUserData = myDbContext.users.First(x => x.UserId == user.UserId);

                myDbContext.users.Remove(removeUserData);


                myDbContext.users.Remove(user);
                myDbContext.SaveChanges();

                Console.WriteLine("User removed sucessfully");
            }
            catch (Exception e) 
            {

                Console.WriteLine(e);
            }

        }

        //Fetch User Id and Category
        public static void FetchUserId()
        {

            MyDbContext myDbContext = new MyDbContext();

            Console.WriteLine("UserId  |     UserName   |     Category");

            foreach (var item in myDbContext.users)
            {
                Console.WriteLine(item.UserId + "           |     " + item.UserName + "     |     " + item.Category);
            }
        }

        //Password Emcription method
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

        //This method is used to convert the Encrypted/Un-Readable Text back to readable  format.
        public static string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }

    
}
