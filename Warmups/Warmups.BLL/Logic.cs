using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            return (cigars >= 40) && (cigars <= 60 || isWeekend);
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else if(yourStyle >=8 || dateStyle >= 8)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60)
            {
                return (temp <= 90 || (temp <= 100 && isSummer));
            }
            else
            {
                return false;
            }
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            throw new NotImplementedException();
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if(sum >= 10 && sum <=19 )
            {
                return 20;
            }
            else
            {
                return sum;
            }
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            if (a + b == 6 || Math.Abs(a - b) == 6)
            {
                return true;
            }
            return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            throw new NotImplementedException();
        }
        
        public bool SpecialEleven(int n)
        {
            int mod11 = n % 11;
            return (mod11 == 0 || mod11 == 1);
        }
        
        public bool Mod20(int n)
        {
            int mod20 = n % 20;
            return (mod20 == 1 || mod20 == 2);
        }
        
        public bool Mod35(int n)
        {
            return (n % 3 == 0 ^ n % 5 == 0);
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            return (!isAsleep && (!(isMorning && !isMom)));
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            int sumAB = a + b;
            int sumBC = b + c;
            int sumAC = a + c;
            return (sumAB == c || sumBC == a || sumAC == b);
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool bTest = (b > a || bOk);
            return (c > b && bTest);
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int aLast = a % 10;
            int bLast = b % 10;
            int cLast = c % 10;
            int matchCount = 0;
            if (aLast == bLast)
            {
                matchCount++;
            }
            if (bLast == cLast)
            {
                matchCount++;
            }
            if(aLast == cLast)
            {
                matchCount++;
            }
            return (matchCount > 0);
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
