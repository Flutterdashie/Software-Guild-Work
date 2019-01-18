using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return $"{a}{b}{b}{a}";
        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word) {
            string firstHalf = container.Substring(0, 2);
            string lastHalf = container.Substring(2, 2);
            return $"{firstHalf}{word}{lastHalf}";
        }

        public string MultipleEndings(string str)
        {
            string ending = str.Substring(str.Length - 2);
            return $"{ending}{ending}{ending}";
        }

        public string FirstHalf(string str)
        {
            return str.Substring(0, str.Length / 2);

        }

        public string TrimOne(string str)
        {
            return str.Substring(1, str.Length - 2);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return $"{b}{a}{b}";
            }
            else
            {
                return $"{a}{b}{a}";
            }
        }

        public string RotateLeft2(string str)
        {
            string result = str + str.Substring(0, 2);
            result = result.Substring(2, str.Length);
            return result;
        }

        public string RotateRight2(string str)
        {
            string result = str.Substring(str.Length - 2, 2) + str;
            result = result.Substring(0, str.Length);
            return result;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            } else
            {
                return str.Substring(str.Length - 1, 1);
            }
        }

        public string MiddleTwo(string str)
        {
            return str.Substring(str.Length / 2 - 1, 2);
        }

        public bool EndsWithLy(string str)
        {
            return (str.EndsWith("ly"));
        }

        public string FrontAndBack(string str, int n)
        {
            throw new NotImplementedException();
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
