using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return (aSmile == bSmile);
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            return (!isWeekday) || isVacation;
        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;
            if (a == b)
            {
                sum *= 2;
            }
            return sum;
        }
        
        public int Diff21(int n)
        {
            int absDiff = Math.Abs(n - 21);
            if (n > 21)
            {
                absDiff *= 2;
            }
            return absDiff;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool badHour = (hour < 7 || hour > 20);
            return badHour && isTalking;
        }
        
        public bool Makes10(int a, int b)
        {
            return (a == 10 || b == 10 || a + b == 10);
        }
        
        public bool NearHundred(int n)
        {
            return (Math.Abs(n - 100) <= 10);
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool aNeg = (a < 0);
            bool bNeg = (b < 0);
            if (negative)
            {
                return aNeg && bNeg;
            }
            return aNeg ^ bNeg;
        }
        
        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return "not " + s;
            }
            if (s.Substring(0,3) == "not")
            {
                return s;
            }
            return "not " + s;
        }
        
        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }
        
        public string FrontBack(string str)
        {
            throw new NotImplementedException();
        }
        
        public string Front3(string str)
        {
            string frontPiece;
            string result = "";
            if (str.Length < 4)
            {
                frontPiece = str;
            }
            else
            {
                frontPiece = str.Substring(0, 3);
            }
            for (int i = 0; i < 3; i++)
            {
                result += frontPiece;
            }
            return result;
        }
        
        public string BackAround(string str)
        {
            string lastChar = str.Substring(str.Length - 1, 1);
            return lastChar + str + lastChar;
        }

        public bool Multiple3or5(int number)
        {
            return (number % 3 == 0) || (number % 5 == 0);
        }
        
        public bool StartHi(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            throw new NotImplementedException();
        }
        
        public bool Between10and20(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool SoAlone(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public string RemoveDel(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IxStart(string str)
        {
            throw new NotImplementedException();
        }
        
        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }
        
        public int Max(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool GotE(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EndUp(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EveryNth(string str, int n)
        {
            throw new NotImplementedException();
        }
    }
}
