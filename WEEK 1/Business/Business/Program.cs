using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace businessApplication
{

    internal class Program
    {

        static void Main(string[] args)
        {
            int size = 700;
            int usercount = 0;

            string name, password, role;
            string[] userName = new string[size];
            string[] userpassword = new string[size];
            string[] userrole = new string[size];
            string[] feedback = new string[size];
            string adminName = "haseeb";
            string adminPaswoord = "Haseeb12";
            int Psize = 1000;
            int Productcount = 0;
            string[] Pname = new string[size];
            int[] Pquantity = new int[size];
            int[] PPrice = new int[size];
            int sellCount = 0;
            string[] Sell_Product = new string[size];
            int[] Sell_quantity = new int[size];
            string[] feedack = new string[size];
            string path;
            int number12 = 0;
            int number = 0;
            //Read_data(userName, userpassword, userrole,ref usercount);
             //Read_dataproduct(Pname, PPrice, Pquantity, ref Productcount);

            string option = "1";
            while (option != "0")
            {
                uperHeader();
                option = menu();
                if (option == "1")
                {
                    SignInLogo();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t\t\t\t\tEnter the name: ");
                    name = Console.ReadLine();
                    Console.Write("\t\t\t\t\tEnter the password: ");
                    password = Console.ReadLine();

                    if (name == adminName && password == adminPaswoord)
                    {
                        string adminOption = "1";
                        while (adminOption != "0")
                        {
                            adminOption = adminmenuInterface();
                            if (adminOption == "1")
                            {
                                ViewCustomer(usercount, userName, userpassword, userrole); // Display customer information
                            }
                            else if (adminOption == "2")
                            {
                                ViewEmployee(usercount, userName, userpassword, userrole); // Display employee information
                            }
                            else if (adminOption == "3")
                            {
                                 RemoveCustomer(ref usercount, userName, userpassword, userrole); // Remove customer
                            }
                            else if (adminOption == "4")
                            {
                                  RemoveEmployee(ref usercount, userName, userpassword, userrole); // Remove employee
                            }
                            else if (adminOption == "5")
                            {
                                addProduct(Pname, Pquantity, PPrice, ref Productcount); // Add product
                            }
                            else if (adminOption == "6")
                            {
                                ViewProduct(Pname, Pquantity, PPrice, Productcount); // Display product information
                            }
                            else if (adminOption == "7")
                            {
                                UpdateProduct(Pname, Pquantity, PPrice, Productcount, Psize); // Update product information
                            }
                            else if (adminOption == "8")
                            {
                                DeleteProduct(Pname, Pquantity, PPrice, ref Productcount, Psize); // Delete product
                            }
                            else if (adminOption == "9")
                            {
                                view_Feedback(userName, userrole, usercount, feedback); // View user feedback
                            }
                            else
                            {
                                break;
                            }
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        role = signin(name, password, userName, userpassword, userrole, ref usercount);

                        if (role == "EMPLOYEE")
                        {
                            for (int i = 0; i < usercount; i++)
                            {
                                if (userName[i] == name && userpassword[i] == password)
                                {
                                    number = i;
                                }
                            }

                            // int number = GetEmployeeIndex(name, password);
                            string employeeOption = "1";
                            while (employeeOption != "0")
                            {
                                employeeOption = employeemenuInterface();
                                if (employeeOption == "1")
                                {
                                    Reset_Password_Employee(userpassword, number); // Reset employee password
                                }
                                else if (employeeOption == "2")
                                {
                                    ViewCustomer(usercount, userName, userpassword, userrole); // View customer information
                                }
                                else if (employeeOption == "3")
                                {
                                     RemoveCustomer(ref usercount, userName, userpassword, userrole); // Remove customer
                                }
                                else if (employeeOption == "4")
                                {
                                    addProduct(Pname, Pquantity, PPrice, ref Productcount); // Add product

                                }
                                else if (employeeOption == "5")
                                {
                                    ViewProduct(Pname, Pquantity, PPrice, Productcount); // View product information
                                }
                                else if (employeeOption == "6")
                                {
                                    UpdateProduct(Pname, Pquantity, PPrice, Productcount, Psize); // Update product information
                                }
                                else if (employeeOption == "7")
                                {
                                    DeleteProduct(Pname, Pquantity, PPrice, ref Productcount, Psize); // Delete product
                                }
                                else if (employeeOption == "8")
                                {
                                    view_Feedback(userName, userrole, usercount, feedback); // View user feedback
                                }
                                else
                                {
                                    break;
                                }
                                Console.ReadKey();
                            }
                        }
                        else if (role == "CUSTOMER")
                        {


                            int bycount = 0;                 // Counter for the number of items bought
                            int[] byQuantity = new int[100];   // Array to store quantity of items bought
                            float[] UserBill = new float[100]; // Array to store user bills
                            string[] byProduct = new string[100]; // Array to store bought products
                            for (int i = 0; i < usercount; i++)
                            {
                                if (userName[i] == name && userpassword[i] == password)
                                {
                                    number12 = i;
                                }
                            }
                            string customerOption = "1";
                            while (customerOption != "0")
                            {

                                customerOption = Userinterface();
                                if (customerOption == "1")
                                {
                                    Reset_Password_Customer(userpassword, number12); // Reset customer password
                                }
                                else if (customerOption == "2")
                                {
                                    ViewProduct(Pname, Pquantity, PPrice, Productcount); // View product information
                                }
                                else if (customerOption == "3")
                                {
                                    BuyProduct(Pname, Pquantity, PPrice, Productcount, UserBill, byProduct, byQuantity, ref bycount, number12, Sell_Product, Sell_quantity, ref sellCount); // Buy a product
                                }
                                else if (customerOption == "4")
                                {
                                    view_BuyProduct(byProduct, byQuantity, bycount); // View bought products
                                }
                                else if (customerOption == "5")
                                {
                                    GenerateBill(byProduct, byQuantity, bycount, UserBill, number12); // Generate user bill
                                }
                                else if (customerOption == "6")
                                {
                                    CustomerFeedback(feedback, number12); // Provide customer feedback
                                }
                                else if (customerOption == "7")
                                {
                                    helpline(); // Display helpline information
                                }
                                else
                                {
                                    break;
                                }
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\tSorry, Please enter valid information");
                            Console.ReadKey();
                        }
                    }
                }
                else if (option == "2")
                {
                    signUpLogo();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t\t\t\t\tEnter the name: ");
                    name = Console.ReadLine();

                    if (!(CheckName(name)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tEnter valid input");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("\t\t\t\t\tEnter the password(at least 6 characters): ");
                    password = Console.ReadLine();

                    if (!(Check_Password(password)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\t\tPlease enter valid Password..");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("\t\t\t\t\tEnter the role (Employee/Customer): ");
                    role = Console.ReadLine();
                    //ToUpper(ref role);

                    if (role == "CUSTOMER" || role == "EMPLOYEE")
                    {
                        bool check = signup(name, password, role, userName, userpassword, userrole, ref usercount, size);
                        if (check)
                        {
                            Console.WriteLine("\t\t\tRegistered successfully");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\tSorry, Please enter valid information.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\t\tPlease enter correct information..");
                        Console.ReadKey();

                    }
                }
                else if(option == "3")
                {
                    //Store_dataProducts(Pname, PPrice, Pquantity, Productcount);
                    //Store_Data(userName, userpassword, userrole, usercount);
                    Console.WriteLine("Thanks for Visiting..");
                    Console.ReadKey();
                }

            }


        }
        static void color1(int colorCode)
        {
            Console.ForegroundColor = (ConsoleColor)colorCode;
        }
        static string signin(string name, string password, string[] userName, string[] userpassword, string[] userrole, ref int usercount)
        {
            for (int i = 0; i < usercount; i++)
            {
                if (userName[i] == name && userpassword[i] == password)
                {
                    return userrole[i];
                }
            }
            return "undefined";
        }
        static bool signup(string name, string password, string role, string[] userName, string[] userpassword, string[] userrole, ref int usercount, int size)
        {
            if (name == "haseeb" && password == "Haseeb12")
            {
                return false;
            }

            if (size == usercount)
            {
                return false;
            }

            for (int i = 0; i < usercount; i++)
            {
                if (userName[i] == name && userpassword[i] == password)
                {
                    return false;
                }
            }

            userName[usercount] = name;
            userpassword[usercount] = password;
            userrole[usercount] = role;
            usercount++;

            return true;
        }
        static string menu()
        {
            // Display the header and menu options
            uperHeader();

            // Set text color to bright cyan (color code 3)
            color1(3);

            // Prompt user with menu options
            string option;
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t\t1)  Sign in "); // Option for signing in
            Console.WriteLine("\t\t\t\t2)  Sign up "); // Option for signing up
            Console.WriteLine("\t\t\t\t0)  Logout ");
            Console.WriteLine("\t\t\t\tEnter your option.");

            // Get user input for menu option
            option = Console.ReadLine();

            // Reset text color to default (color code 7)
            color1(7);

            // Return the user's menu option
            return option;
        }
        static string adminmenuInterface()
        {
            // Display upper header and admin logo
            uperHeader();
            AdminLogo();

            // Prompt user with admin menu options
            string option;
            color1(3);
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t  1)   View Customer: ");      // Option to view customer information
            Console.WriteLine("\t\t\t\t\t  2)   View Employee : ");     // Option to view employee information
            Console.WriteLine("\t\t\t\t\t  3)   Remove Customer:    "); // Option to remove customer
            Console.WriteLine("\t\t\t\t\t  4)   Remove Employee: ");    // Option to remove employee
            Console.WriteLine("\t\t\t\t\t  5)   Add Product");          // Option to add a new product
            Console.WriteLine("\t\t\t\t\t  6)   View Product ");        // Option to view product information
            Console.WriteLine("\t\t\t\t\t  7)   Update Product ");      // Option to update product information
            Console.WriteLine("\t\t\t\t\t  8)   Delete Product     ");  // Option to delete a product
            Console.WriteLine("\t\t\t\t\t  9)   View Feedback     ");   // Option to view customer feedback
            Console.WriteLine("\t\t\t\t\t  0)    Log  Out         ");   // Option to log out
            Console.Write("\t\t\t\t\t    Enter your option: ");
            option = Console.ReadLine();

            // Return the selected option
            return option;
        }
        static string employeemenuInterface()
        {
            uperHeader();
            EmployeeLogo();
            string option;
            color1(3);
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t  1)   Reset  Password: "); // Option to reset password
            Console.WriteLine("\t\t\t\t\t  2)   View Customer: ");   // Option to view customer information
            Console.WriteLine("\t\t\t\t\t  3)   Remove Customer:    "); // Option to remove customer
            Console.WriteLine("\t\t\t\t\t  5)   Add Product");        // Option to add a new product
            Console.WriteLine("\t\t\t\t\t  6)   View Product ");      // Option to view product information
            Console.WriteLine("\t\t\t\t\t  7)   Update Product ");    // Option to update product information
            Console.WriteLine("\t\t\t\t\t  8)   Delete Product     "); // Option to delete a product
            Console.WriteLine("\t\t\t\t\t  9)   View Feedback     ");  // Option to view customer feedback
            Console.WriteLine("\t\t\t\t\t  0)    Log  Out         ");  // Option to log out
            Console.Write("\t\t\t\t\t    Enter your option: ");
            option = Console.ReadLine();
            color1(7);
            return option;
        }
        static string Userinterface()
        {
            // Display upper header and user logo
            uperHeader();
            UserLogo();

            // Set text color to bright cyan (color code 3)
            color1(3);

            // Prompt user with user menu options
            string option;
            Console.WriteLine("\t\t\t\t1)    Reset  Password");      // Option to reset password
            Console.WriteLine("\t\t\t\t2)    View Product");         // Option to view available products
            Console.WriteLine("\t\t\t\t3)    Buy Product   ");       // Option to buy a product
            Console.WriteLine("\t\t\t\t4)    View BuyProduct");      // Option to view purchased products
            Console.WriteLine("\t\t\t\t5)    Generate bill ");       // Option to generate a bill
            Console.WriteLine("\t\t\t\t6)    Customer  Feedback ");  // Option to provide feedback
            Console.WriteLine("\t\t\t\t7)    Helpline ");            // Option to access helpline
            Console.WriteLine("\t\t\t\t0)    Logout         ");      // Option to log out
            Console.Write("\t\t\t\t     Enter the option..");

            // Get user input for menu option
            option = Console.ReadLine();

            // Return the selected option
            return option;
        }

        static void uperHeader()
        {
            Console.Clear();
            color1(9);

            Console.WriteLine("\t\t\t_____________________________________________________________________________________");
            Console.WriteLine("\t\t\t-------------------------------------------------------------------------------------");
            color1(9);
            Console.WriteLine("\t\t\t /$$$$$$$$                /$$      /$$      /$$$$$$      /$$$$$$$       /$$$$$$$$  ");
            Console.WriteLine("\t\t\t|_____ $$                | $$$    /$$$     /$$__  $$    | $$__  $$     |__  $$__/  ");
            Console.WriteLine("\t\t\t     /$$/                | $$$$  /$$$$    | $$  \\ $$    | $$  \\ $$        | $$     ");
            Console.WriteLine("\t\t\t    /$$/      /$$$$$$    | $$ $$/$$ $$    | $$$$$$$$    | $$$$$$$/        | $$     ");
            Console.WriteLine("\t\t\t   /$$/      |______/    | $$  $$$| $$    | $$__  $$    | $$__  $$        | $$     ");
            Console.WriteLine("\t\t\t  /$$/                   | $$\\  $ | $$    | $$  | $$    | $$  \\ $$        | $$     ");
            Console.WriteLine("\t\t\t /$$$$$$$$               | $$ \\/  | $$    | $$  | $$    | $$  | $$        | $$     ");
            Console.WriteLine("\t\t\t|________/               |__/     |__/    |__/  |__/    |__/  |__/        |__/     ");
            color1(9);
            Console.WriteLine("\t\t\t-------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t_____________________________________________________________________________________");
            color1(7);

            Console.WriteLine("\n");
        }



        static void AdminLogo()
        {
            color1(14);
            Console.WriteLine("              _           _                                      ");
            Console.WriteLine("     /\\      | |         (_)                                    ");
            Console.WriteLine("    /  \\   __| |_ __ ___  _ _ __     _ __ ___   ___ _ __  _   _ ");
            Console.WriteLine("   / /\\ \\ / _` | '_ ` _ \\| | '_ \\   | '_ ` _ \\ / _ \\ '_ \\| | | |");
            Console.WriteLine("  / ____ \\ (_| | | | | | | | | | |  | | | | | |  __/ | | | |_| |");
            Console.WriteLine(" /_/    \\_\\__,_|_| |_| |_|_|_| |_|  |_| |_| |_|\\___|_| |_|\\__,_|");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                                                                 ");
        }
        static void EmployeeLogo()
        {
            color1(14);
            Console.WriteLine("                       _                                                      ");
            Console.WriteLine("                      | |                                                     ");
            Console.WriteLine("   ___ _ __ ___  _ __ | | ___  _   _  ___  ___    _ __ ___   ___ _ __  _   _ ");
            Console.WriteLine("  / _ \\ '_ ` _ \\| '_ \\| |/ _ \\| | | |/ _ \\/ _ \\  | '_ ` _ \\ / _ \\ '_ \\| | | |");
            Console.WriteLine(" |  __/ | | | | | |_) | | (_) | |_| |  __/  __/  | | | | | |  __/ | | | |_| |");
            Console.WriteLine("  \\___|_| |_| |_| .__/|_|\\___/ \\__, |\\___|\\___|  |_| |_| |_|\\___|_| |_|\\__,_|");
            Console.WriteLine("                | |             __/ |                                         ");
            Console.WriteLine("                |_|            |___/                                          ");
        }
        static void UserLogo()
        {
            color1(14);
            Console.WriteLine("                 _                                                          ");
            Console.WriteLine("                | |                                                         ");
            Console.WriteLine("   ___ _   _ ___| |_ ___  _ __ ___   ___ _ __   _ __ ___   ___ _ __  _   _ ");
            Console.WriteLine("  / __| | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__| | '_ ` _ \\ / _ \\ '_ \\| | | |");
            Console.WriteLine(" | (__| |_| \\__ \\ || (_) | | | | | |  __/ |    | | | | | |  __/ | | | |_| |");
            Console.WriteLine("  \\___|\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|    |_| |_| |_|\\___|_| |_|\\__,_|");
            Console.WriteLine("                                                                            ");
            Console.WriteLine("                                                                            ");
        }
        static void SignInLogo()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("         _                _     ");
            Console.WriteLine("   _____(_)___ _____     (_)___ ");
            Console.WriteLine("  / ___/ / __ `/ __ \\   / / __ \\");
            Console.WriteLine(" (__  ) / /_/ / / / /  / / / / /");
            Console.WriteLine("/____/_/\\__, /_/ /_/  /_/_/ /_/ ");
            Console.WriteLine("       /____/                   ");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        static void signUpLogo()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("         _                          ");
            Console.WriteLine("   _____(_)___ _____     __  ______");
            Console.WriteLine("  / ___/ / __ `/ __ \\   / / / / __ \\");
            Console.WriteLine(" (__  ) / /_/ / / / /  / /_/ / /_/ /");
            Console.WriteLine("/____/_/\\__, /_/ /_/   \\__,_/ .___/ ");
            Console.WriteLine("       /____/              /_/      ");

            Console.WriteLine("");
        }
        static void logo_Reset_Password()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("    ____                 __                                                     __");
            Console.WriteLine("   / __ \\___  ________  / /_     ____  ____ ____________      ______  _________/ /");
            Console.WriteLine("  / /_/ / _ \\/ ___/ _ \\/ __/    / __ \\/ __ `/ ___/ ___/ | /| / / __ \\/ ___/ __  / ");
            Console.WriteLine(" / _, _/  __/(__  )  __/ /_     / /_/ / /_/ (__  |__  )| |/ |/ / /_/ / /  / /_/ /  ");
            Console.WriteLine("/_/ |_|\\___/____/\\___/\\__/    / .___/\\__,_/____/____/ |__/|__ /\\____/_/   \\__,_/   ");
            Console.WriteLine("                             /_/                                                  ");
            color1(7);
        }
        static void Add_product_logo()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("    ___       __    __     ____                 __           __ ");
            Console.WriteLine("   /   | ____/ /___/ /    / __ \\_________  ____/ /_  _______/ /_");
            Console.WriteLine("  / /| |/ __  / __  /    / /_/ / ___/ __ \\/ __  / / / / ___/ __/");
            Console.WriteLine(" / ___ / /_/ / /_/ /    / ____/ /  / /_/ / /_/ / /_/ / /__/ /_  ");
            Console.WriteLine("/_/  |_\\__,_/\\__,_/    /_/   /_/   \\____/\\__,_/\\__,_/\\___/\\__/  ");
            color1(7);
            Console.WriteLine();
        }
        static void Remove_Customer_Logo()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("    ____                                    ______           __                           ");
            Console.WriteLine("   / __ \\___  ____ ___  ____ _   _____     / ____/_  _______/ /_____  ____ ___  ___  _____");
            Console.WriteLine("  / /_/ / _ \\/ __ `__ \\/ __ \\ | / / _ \\   / /   / / / / ___/ __/ __ \\/ __ `__ \\/ _ \\/ ___/");
            Console.WriteLine(" / _, _/  __/ / / / / / /_/ / |/ /  __/  / /___/ /_/ (__  ) /_/ /_/ / / / / / /  __/ /    ");
            Console.WriteLine("/_/ |_|\\___/_/ /_/ /_/\\____/|___/\\___/   \\____/\\__,_/____/\\__/\\____/_/ /_/ /_/\\___/_/     ");
            color1(7);
            Console.WriteLine();
        }
        static void Remove_Employee_Logo()
        {
            uperHeader();
            color1(14);
            Console.WriteLine("    ____                                      ______                __                    ");
            Console.WriteLine("   / __ \\___  ____ ___  ____ _   _____       / ____/___ ___  ____  / /___  __  _____  ___ ");
            Console.WriteLine("  / /_/ / _ \\/ __ `__ \\/ __ \\ | / / _ \\     / __/ / __ `__ \\/ __ \\/ / __ \\/ / / / _ \\/ _ \\");
            Console.WriteLine(" / _, _/  __/ / / / / / /_/ / |/ /  __/    / /___/ / / / / / /_/ / / /_/ / /_/ /  __/  __/");
            Console.WriteLine("/_/ |_|\\___/_/ /_/ /_/\\____/|___/\\___/    /_____/_/ /_/ /_/ .___/_/\\____/\\__, /\\___/\\___/ ");
            Console.WriteLine("                                                         /_/            /____/            ");
            color1(7);
            Console.WriteLine();
        }
        static bool Crash(string value)
        {
            // this function is for integers ..
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] < '0' || value[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static bool Check_Password(string password)
        {
            // this is validation for check password
            int option = 1;
            for (int i = 0; i < password.Count(); i++)
            {
                if (!((password[i] >= 'a' && password[i] <= 'z') || (password[i] >= 'A' && password[i] <= 'Z') || (password[i] >= '0' && password[i] <= '9') || (password[i] == '@')))
                {
                    option--;
                }
            }
            if ((option < 1) || (password.Count() < 6 || password[0] == '\0'))

            {
                return false;
            }
            return true;
        }
        static bool CheckName(string name)
        {
            // validation for check name
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || (name[i] >= '0' && name[i] <= '9') || (name[i] == '@')))
                {
                    count++;
                    break;
                }
            }
            if (name.Count() < 4 || count >= 1 || name[0] == '\0')
            {
                return false;
            }
            return true;
        }
        static bool CheckNameProduct(string name)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z')))
                {
                    count++;
                    break;
                }
            }
            if (name.Count() < 4 || count >= 1 || name[0] == '\0')
            {
                return false;
            }
            return true;
        }
        /*void ToUpper(ref string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                    input = input.Remove(i, 1).Insert(i, ((char)(input[i] - 32)).ToString());
            }
        }*/

        static void helpline()
        {
            color1(2);
            Console.WriteLine("  Help Menu");
            color1(7);
            color1(9);
            Console.WriteLine("-------------------->>>");

            Console.WriteLine("\n");
            color1(8);
            color1(7);
            color1(4);
            Console.WriteLine("  --->IF you need any other help kindly contact us:");
            color1(7);
            color1(6);
            Console.WriteLine("   Name              Haseeb Afzal  ");
            Console.WriteLine("   Gmail             haseebafzal@gmail.com");
            Console.WriteLine("   Contact Number    0309-2428802");
            color1(7);
        }
       
        static void ViewCustomer(int usercount, string[] userName, string[] userpassword, string[] userrole)
        {
            uperHeader();
            Console.WriteLine("------------------------------------------------------------------------------------"); // Header line
            Console.WriteLine("No\tCustomer Name\t\t\tCustomer Password");                                              // Table header
            Console.WriteLine("------------------------------------------------------------------------------------"); // Separator line

            int no = 1;
            for (int i = 0; i <= usercount; i++)
            {
                if (userrole[i] == "EMPLOYEE" || string.IsNullOrEmpty(userrole[i]))
                {
                    continue;
                }
                else if (userrole[i] == "CUSTOMER")
                {
                    Console.WriteLine($"{no})\t{userName[i]}\t\t\t\t{userpassword[i]}\n");
                    no++;
                }
            }

            Console.WriteLine("------------------------------------------------------------------------------------"); // Footer line
        }
        static void ViewEmployee(int usercount, string[] userName, string[] userpassword, string[] userrole)
        {
            Console.Clear(); // Clear the console screen
            uperHeader();
            color1(12);
            Console.WriteLine("------------------------------------------------------------------------------------"); // Header line

            Console.WriteLine("No\tEmployee Name\t\t\tEmployee Password"); // Table header

            Console.WriteLine("------------------------------------------------------------------------------------"); // Separator line

            color1(3);
            int nu = 1;
            for (int i = 0; i <= usercount; i++)
            {
                if (userrole[i] == "CUSTOMER")
                {
                    continue; // Skip customers
                }
                else if (userrole[i] == "EMPLOYEE")
                {
                    // Print employee information
                    Console.WriteLine($"{nu})\t{userName[i]}\t\t\t\t{userpassword[i]}\n");
                    nu++;
                }
            }

            Console.WriteLine("------------------------------------------------------------------------------------"); // Separator line
        }
        static void RemoveCustomer(ref int usercount, string[] userName, string[] userpassword, string[] userrole)
        {
            // Display the "Remove Customer" logo
            Remove_Customer_Logo();

            // View the list of customers before removal
            ViewCustomer(usercount, userName, userpassword, userrole);

            color1(14);
            int num = -1;
            string name;

            // Prompt user to enter the name of the customer to be deleted
            Console.Write("Enter the name of the Customer you want to delete: ");
            name = Console.ReadLine();

            // Iterate through user data to find the customer to be removed
            for (int i = 0; i < usercount; i++)
            {
                if (name == userName[i])
                {
                    // Mark the customer for removal by emptying their information
                    userName[i] = "";
                    userpassword[i] = "";
                    num = i;
                    break;
                }
            }

            // Check if the customer was found and marked for removal
            if (num != -1)
            {
                color1(13);

                // Display a success message
                Console.WriteLine("Customer removed successfully..");

                usercount--;
                // Decrement the user count and shift remaining entries to fill the gap
                for (int i = num; i < usercount; i++)
                {
                    userName[i] = userName[i + 1];
                    userpassword[i] = userpassword[i + 1];
                    userrole[i] = userrole[i + 1];
                }

                // Clear the information of the last user
                userName[usercount ] = "";
                userpassword[usercount ] = "";
                userrole[usercount] = "";

                // Wait for user input before continuing
                Console.ReadKey();
            }
            else
            {
                // Display a message if the customer is not present in the list
                Console.WriteLine("This Customer is not present in our list..");

                // Wait for user input before continuing
                Console.ReadKey();
            }
        }

        static void RemoveEmployee(ref int  usercount, string[] userName, string[] userpassword, string[] userrole)
        {
            // Display the "Remove Employee" logo
            Remove_Employee_Logo();

            // View the list of employees before removal
            ViewEmployee(usercount, userName, userpassword, userrole);

            Console.ForegroundColor = ConsoleColor.Yellow;
            int num = -1;
            string name1;

            // Prompt user to enter the name of the employee to be deleted
            Console.Write("Enter the name of Employee you want to delete: ");
            name1 = Console.ReadLine();

            // Loop through the array of employee names to find the one to delete
            for (int i = 0; i < usercount; i++)
            {
                if (name1 == userName[i])
                {
                    userName[i] = "";
                    userpassword[i] = "";
                    num = i;
                    break;
                }
            }

            // Check if the employee was found and removed
            if (num != -1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Employee removed successfully..");
                usercount--;

                // Shift the elements in the arrays to fill the gap left by the removed employee
                for (int i = num; i < usercount; i++)
                {
                    userName[i] = userName[i + 1];
                    userpassword[i] = userpassword[i + 1];
                    userrole[i] = userrole[i + 1];
                }

                userName[usercount ] = "";
                userpassword[usercount ] = "";
                userrole[usercount] = "";

                // Pause the program to show the user the result
                Console.ReadKey();
            }
            else
            {
                color1(13);
                Console.WriteLine("This Employee is not present in our Mall..");
                // Pause the program to show the user the result
                Console.ReadKey();
            }
        }
        static void addProduct(string[] Pname, int[] Pquantity, int[] PPrice, ref int Productcount)
        {
            int option = 1;
            while (option != 0)
            {
                Add_product_logo();

                color1(3);
                string quantity;
                string price;

                Console.WriteLine("Enter the product name: ");
                Pname[Productcount] = Console.ReadLine();
                if (!CheckNameProduct(Pname[Productcount]))
                {
                    color1(4);
                    Console.WriteLine("\t\t\t\tEnter valid input");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Enter the product price: ");
                price = Console.ReadLine();
                if (Crash(price))
                {
                    PPrice[Productcount] = int.Parse(price);
                }
                else
                {
                    Console.WriteLine("Enter input in digits..");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("Enter the product quantity: ");
                quantity = Console.ReadLine();
                if (Crash(quantity))
                {
                    Pquantity[Productcount] = int.Parse(quantity);
                }
                else
                {
                    Console.WriteLine("Enter input in digits..");
                    Console.ReadKey();
                    continue;
                }

                Productcount++;

                Console.WriteLine("Press 1 to add product and 0 to exit..");
                option = int.Parse(Console.ReadLine());
            }

        }
        static void ViewProduct(string[] Pname, int[] Pquantity, int[] PPrice, int Productcount)
        {
            Console.Clear(); // Clear the console screen

            color1(3);
            Console.WriteLine("The products are........");

            color1(9);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("S.No   Product Name\t\t\tProduct Price\t\t\tProduct Quantity");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            color1(3);
            for (int i = 0; i < Productcount; i++)
            {
                if (string.IsNullOrEmpty(Pname[i]))
                {
                    continue;
                }

                Console.WriteLine($"{i + 1})   {Pname[i]}\t\t\t\t{PPrice[i]}\t\t\t\t{Pquantity[i]}");
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            color1(7);
        }
        static void UpdateProduct(string[] Pname, int[] Pquantity, int[] PPrice, int Productcount, int Psize)
        {
            uperHeader();
            ViewProduct(Pname, Pquantity, PPrice, Productcount);

        start:
            int num = 0;
            string number;
            Console.WriteLine("Enter the product number for UPDATE");
            number = Console.ReadLine();
            if (Crash(number))
            {
                num = int.Parse(number);
            }
            else
            {
                Console.WriteLine("Enter input in digits..");
                Console.ReadKey();
                goto start;
            }

            num--;
            if (Productcount > num)
            {
                Console.WriteLine($" . {Pname[num]}\t\t\t\t{PPrice[num]}\t\t\t\t{Pquantity[num]}\n");

                Console.WriteLine("Update the product name: ");
                Pname[num] = Console.ReadLine();
                Console.WriteLine("Update the product price: ");
                PPrice[num] = int.Parse(Console.ReadLine());
                Console.WriteLine("Update the product quantity: ");
                Pquantity[num] = int.Parse(Console.ReadLine());
                Console.WriteLine("Product Updated successfully...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("So much Products are not Present...");
                Console.ReadKey();
            }
        }
        static void DeleteProduct(string[] Pname, int[] Pquantity, int[] PPrice, ref int Productcount, int Psize)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.WriteLine(" A D M I N    M E N U -->>  D E L E T E     P R O D U C T");
            Console.WriteLine("\n\n");
            ViewProduct(Pname, Pquantity, PPrice, Productcount);
            Console.WriteLine("\n");

            int num = 0;
            string number;
            Console.WriteLine("Enter the product number for delete..\n");
            number = Console.ReadLine();

            if (Crash(number))
            {
                num = int.Parse(number);
            }
            else
            {
                Console.WriteLine("Enter input in digits..");
                Console.ReadKey();
                return; // Exit the function if input is not a digit
            }

            if (num < 1 || num > Productcount)
            {
                Console.WriteLine("Invalid product number.");
                return; // Exit the function if the product number is out of range
            }

            num--; // Adjusting index to match array indexing
            Console.WriteLine($" . {Pname[num]}\t\t\t{PPrice[num]}\t\t\t{Pquantity[num]}\n");

            // Shift array elements to remove the deleted product
            for (int i = num; i < Productcount - 1; i++)
            {
                Pname[i] = Pname[i + 1];
                PPrice[i] = PPrice[i + 1];
                Pquantity[i] = Pquantity[i + 1];
            }

            // Update the last element since it's a duplicate now
            Pname[Productcount - 1] = "";
            PPrice[Productcount - 1] = 0;
            Pquantity[Productcount - 1] = 0;

            Productcount--;

            Console.WriteLine("Product deleted successfully..");
        }
        static void view_Feedback(string[] userName, string[] userrole, int usercount, string[] feedback)
        {
            uperHeader();
            color1(12);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("                  List of Feedback");
            Console.WriteLine("--------------------------------------------------------");
            color1(7);
            color1(10);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("No.\tCustomer Names\t\tCustomer Feedback");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            color1(7);
            color1(6);

            bool hasFeedback = false;

            for (int i = 0; i < usercount; i++)
            {
                if (string.IsNullOrEmpty(feedback[i]))
                {
                    color1(4);
                    feedback[i] = "No Feedback Yet.";
                    color1(7);
                }
                else
                {
                    hasFeedback = true;
                    Console.WriteLine($"{i + 1})\t{userName[i]}\t\t{feedback[i]}");
                }
            }

            if (!hasFeedback)
            {
                color1(4);
                Console.WriteLine("No feedback yet.");
                color1(7);
            }

            Console.WriteLine();
            color1(10);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
            color1(7);
        }
        static void Reset_Password_Employee(string[] userpassword, int number)
        {
            string option = "1";
            logo_Reset_Password();

            while (option == "1")
            {
                color1(12);
                string password;
                string new_Password;
                color1(6);

                Console.WriteLine();
                Console.Write("Enter your previous password: ");
                password = Console.ReadLine();

                if (password == userpassword[number])
                {
                    Console.Write("Enter your new Password (at least 6 Characters): ");
                    new_Password = Console.ReadLine();

                    if (!Check_Password(new_Password))
                    {
                        color1(4);
                        Console.WriteLine("Please enter a correct password...");
                        Console.ReadKey();
                    }
                    else
                    {
                        color1(10);
                        userpassword[number] = new_Password;
                        option = "0";
                        Console.WriteLine("Password updated successfully.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Your previous password does not match.");
                    Console.Write("Press 1 to retry or 0 to go back: ");
                    option = Console.ReadLine();
                }
            }
        }
        static void Reset_Password_Customer(string[] userpassword, int number12)
        {
            string option = "1";
            logo_Reset_Password();

            while (option == "1")
            {
                string password;
                string new_Password;

                Console.WriteLine();
                Console.Write("Enter your previous password: ");
                password = Console.ReadLine();

                if (password == userpassword[number12])
                {
                    Console.Write("Enter your new Password (at least 8 Characters): ");
                    new_Password = Console.ReadLine();

                    if (!Check_Password(new_Password))
                    {
                        color1(4);
                        Console.WriteLine("Please Enter correct  Password...");
                        Console.ReadKey();
                    }
                    else
                    {
                        color1(10);
                        userpassword[number12] = new_Password;
                        option = "0";
                        Console.WriteLine("Password updated successfully.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Your previous password does not match.");
                    Console.Write("Press 1 to retry or 0 to go back: ");
                    option = Console.ReadLine();
                }
            }
        }
        static void BuyProduct(string[] Pname, int[] Pquantity, int[] PPrice, int Productcount, float[] UserBill, string[] byProduct, int[] byQuantity, ref int bycount, int number12, string[] Sell_Product, int[] Sell_quantity, ref int sellCount)
        {
            string option = "1";
            Console.Clear();
            string productName;
            int quantity;
            float BILL = 0.0f;

            while (option == "1")
            {
                ViewProduct(Pname, Pquantity, PPrice, Productcount);

                Console.Write("Enter the product you want to buy: ");
                productName = Console.ReadLine();
                int productIndex = -1;
                for (int i = 0; i <= Productcount; i++)
                {
                    if (Pname[i] == productName)
                    {
                        productIndex = i;
                        break;
                    }

                }

                // int productIndex = Array.IndexOf(Pname, productName);

                if (productIndex != -1 && Pquantity[productIndex] > 0)
                {
                    Console.Write("Enter the quantity of product you want to buy: ");
                    quantity = int.Parse(Console.ReadLine());
                    if (quantity > 0 && quantity <= Pquantity[productIndex])
                    {
                        BILL = PPrice[productIndex] * quantity;
                        UserBill[number12] += BILL;
                        Pquantity[productIndex] -= quantity;
                        byProduct[bycount] = productName;
                        byQuantity[bycount] = quantity;
                        Sell_Product[sellCount] = productName;
                        Sell_quantity[sellCount] = quantity;
                        sellCount++;
                        bycount++;
                        Console.WriteLine($"\n{quantity} {productName}(s) added to your cart successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity or not enough stock available.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product selection or out of stock.");
                }

                Console.WriteLine("\nEnter 1 to add product in cart or 0 to go back.");
                option = Console.ReadLine();
            }

        }
        static void view_BuyProduct(string[] byProduct, int[] byQuantity, int bycount)
        {
            Console.WriteLine("The products are........");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("S.No\tProduct Name\t\tProduct quantity");
            Console.WriteLine("-------------------------------------------------------------------------------");

            for (int i = 0; i < bycount; i++)
            {
                if (string.IsNullOrEmpty(byProduct[i]))
                {
                    continue;
                }

                Console.WriteLine($"{i + 1})   {byProduct[i]}\t\t\t\t{byQuantity[i]}\n");
            }

            Console.WriteLine("-------------------------------------------------------------------------------");
        }
        static void GenerateBill(string[] byProduct, int[] byQuantity, int bycount, float[] UserBill, int number12)
        {
            view_BuyProduct(byProduct, byQuantity, bycount);
            Console.WriteLine("\n\n");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"The bill is {UserBill[number12]}");
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
        static void CustomerFeedback(string[] feedback, int number12)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please give your feedback:");
            string customerFeedback = Console.ReadLine();
            Console.WriteLine("Thank you for your response");
            feedback[number12] = customerFeedback;
            Console.ReadKey();
        }
        

    }
}
