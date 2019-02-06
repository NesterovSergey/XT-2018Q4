using System;

namespace Epam.Task3.MyString
{
    public class MyString
    {
        public MyString()
        {
            this.Array = new char[0];
        }

        public MyString(string str)
        {
            this.Array = new char[str.Length];

            ////ToCharArray
            for (int i = 0; i < str.Length; i++)
            {
                this.Array[i] = str[i];
            }
        }

        public char[] Array { get; set; }

        public int Length => this.Array.Length;

        public char this[int id]
        {
            get
            {
                return this.Array[id];
            }

            set
            {
                this.Array[id] = value;
            }
        }

        public static bool operator >(MyString obj1, MyString obj2)
        {
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                sum1 += obj1.Array[i];
            }

            for (int i = 0; i < obj2.Array.Length; i++)
            {
                sum2 += obj2.Array[i];
            }

            if (sum1 > sum2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MyString operator +(MyString obj1, MyString obj2)
        {
            char[] newArray = new char[obj1.Array.Length + obj2.Array.Length];
            int counter = 0;

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                newArray[counter] = obj1.Array[i];
                counter++;
            }

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                newArray[i] = obj2.Array[i];
                counter++;
            }

            MyString tempObj = new MyString
            {
                Array = newArray
            };

            return tempObj;
        }

        public static bool operator <(MyString obj1, MyString obj2)
        {
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                sum1 += obj1.Array[i];
            }

            for (int i = 0; i < obj2.Array.Length; i++)
            {
                sum2 += obj2.Array[i];
            }

            if (sum1 > sum2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator ==(MyString obj1, MyString obj2)
        {
            if (obj1.Array.Length != obj2.Array.Length)
            {
                return false;
            }

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                if (obj1.Array[i] != obj2.Array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MyString obj1, MyString obj2)
        {
            if (obj1.Array.Length != obj2.Array.Length)
            {
                return true;
            }

            for (int i = 0; i < obj1.Array.Length; i++)
            {
                if (obj1.Array[i] != obj2.Array[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool Equals(MyString obj)
        {
            if (this.Array.Length != obj.Array.Length)
            {
                return false;
            }

            for (int i = 0; i < obj.Array.Length; i++)
            {
                if (this.Array[i] != obj.Array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public int IndexOf(char ch)
        {
            for (int i = 0; i < this.Array.Length; i++)
            {
                if (this.Array[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public string MyToString()
        {
            return this.Array.ToString();
        }
    }
}