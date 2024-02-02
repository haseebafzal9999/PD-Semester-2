using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            student[] s2 = new student[2];
            int value = 1;
            while(value !=0)
            {
                Console.Clear();    
            string option = menu();

            if(option=="1")
            {

                    input(s2);
                
            }
            else if(option=="2")
            {
              ShowStudent(s2);
            }
            else if(option=="3")
            {
              Aggregate(s2);
            }
            else
                {
                    Console.WriteLine("ENTER VALID INPUT");
                }
            Console.ReadKey();
            }

           


        }
        static string menu()
        {
            string option;
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Show Students.");
            Console.WriteLine("3. Calcluate Aggregate.");
           /* Console.WriteLine("4. Top Students.");*/
            Console.WriteLine("Enter the option :");
            option = Console.ReadLine();
            return option;
        }
        static void input(student[] s2)
        {
            //student[] s2= new student[2];
            for(int i = 0; i < 2; i++)
            {
                s2[i] = AddStudent();
            }
        }
        static student AddStudent()
        {
            student s1=new student();
           
                Console.WriteLine("Enter the name of student: ");
                s1.Name = Console.ReadLine();
                Console.WriteLine("Enter the Matric Marks of student: ");
                s1.Matricmarks = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Fsc marks of student: ");
                s1.Fscmarks = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Ecat Marks of student: ");
                s1.Ecatmarks = float.Parse(Console.ReadLine());
               return s1;
            
              
        }
        static void ShowStudent(student[] s2)
        {
            for(int i = 0;i<2;i++)
            {
                Console.WriteLine( s2[i].Name + "\t" + s2[i].Matricmarks + "\t" + s2[i].Fscmarks + "\t" +s2[i].Ecatmarks);

            }
        }
        static void Aggregate(student[] s2)
        {

          for(int i=0; i<s2.Length;i++)
            {
                float aggregate = (s2[i].Fscmarks * s2[i].Matricmarks * s2[i].Ecatmarks) / 100;
                Console.WriteLine(s2[i].Name+"   "+ aggregate);
            }
        }
      

    }
}
