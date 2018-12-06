using System;

namespace Epam.Task3.MyString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyString mystr1 = new MyString("bumblebee");
            MyString mystr2 = new MyString("Bumblebee");
            Console.WriteLine(mystr1.IndexOf('l'));
            Console.WriteLine(mystr1 > mystr2);

            var mystr3 = mystr1 + mystr2;
            mystr3[0] = 'k';
            for (int i = 0; i < mystr2.Length; i++)
            {
                Console.WriteLine(mystr3[i]);
            }
        }
    }
}
