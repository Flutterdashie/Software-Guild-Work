using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            return ((numbers[0] == 6) || (numbers[numbers.Length - 1] == 6));
        }

        public bool SameFirstLast(int[] numbers)
        {
            if(numbers.Length < 1)
            {
                return false;
            }
            return numbers[0] == numbers[numbers.Length - 1];
        }
        public int[] MakePi(int n)
        {
            int[] piArray = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9 };
            int[] result = new int[n];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = piArray[i];
            }
            //I originally was going to have it parse Math.PI into a bunch of ints, but this works for now.

            return result;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public int Sum(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Reverse(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] HigherWins(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}
