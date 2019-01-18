using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string result = "";
            for(int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }

        public string FrontTimes(string str, int n)
        {
            string frontPiece;
            string result = "";
            if(str.Length < 4)
            {
                frontPiece = str;
            } else
            {
                frontPiece = str.Substring(0, 3);
            }
            for (int i = 0; i < n; i++)
            {
                result += frontPiece;
            }
            return result;
            }

        public int CountXX(string str)
        {
            throw new NotImplementedException();
        }

        public bool DoubleX(string str)
        {
            int firstXIndex = str.IndexOf('x');
            if (firstXIndex == str.Length - 1)
            {
                return false;
            }
            else
            {
                return (str.ToCharArray()[firstXIndex + 1] == 'x');
            }
        }

        public string EveryOther(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i +=2)
            {
                result += str.ToCharArray()[i];
            }
            return result;
        }

        public string StringSplosion(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += str.Substring(0, i + 1);
            }
            return result;
        }

        public int CountLast2(string str)
        {
            throw new NotImplementedException();
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            foreach(int i in numbers)
            {
                if(i==9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < numbers.Length && i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            string writtenNumbers = "";
            foreach (int i in numbers)
            {
                writtenNumbers += i.ToString();
            }
            return (writtenNumbers.IndexOf("123") != -1);
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}
