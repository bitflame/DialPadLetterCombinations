using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialPadLetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] digits = new [] { '2', '3'  };
            var letters = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            Dictionary<Char, Char[]> lettersMap = new Dictionary<Char, char[]>();
            lettersMap.Add('1', null);
            lettersMap.Add('2', new[] { 'a', 'b', 'c'});
            lettersMap.Add('3', new[] { 'd', 'e', 'f' });
            lettersMap.Add('4', new[] { 'g', 'h', 'i' });
            lettersMap.Add('5', new[] { 'j', 'k', 'l' });
            lettersMap.Add('6', new[] { 'm', 'n', 'o' });
            lettersMap.Add('7', new[] { 'p', 'q', 'r', 's' });
            lettersMap.Add('8', new[] { 't', 'u', 'v' });
            lettersMap.Add('9', new[] { 'w', 'x', 'y', 'z' });
            lettersMap.Add('0', null);
            StringBuilder sb = new StringBuilder();
            List<String> result = new List<String> ();
            LetterCombinationsFunction(digits, sb, lettersMap, result);
            foreach (String r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
        private static void LetterCombinationsFunction(Char [] digits, StringBuilder sb, 
            Dictionary<Char, Char[]> lettersMap, List<String> result)
        {
            if (sb.Length == digits.Count())
            {
                result.Add(sb.ToString());
                return;
            }
            foreach (var d in digits)
            {
                lettersMap.TryGetValue(d, out Char[] values);
                foreach (var v in values)
                {
                    sb.Append(v);
                    LetterCombinationsFunction(digits, sb, lettersMap, result);
                    sb.Remove(sb.Length-1, 1);
                }
            }
        }
        //private static void testFunc(int[] digits, StringBuilder sb, 
        //    Dictionary<int, string> result, Dictionary<int,string>visited)
        //{
        //    Char[] two = new Char[] { 'a', 'b', 'c' };
        //    Char [] three = new Char[] { 'd', 'e', 'f' };
        //    if visited.ContainsKey()
          
        //        //
        //        //Each collection is the result of concatenation of each original 
        //        // string with the characters of the new node. IF the original collection is a
        //        // Dictionary, we can go through it and append the new character to what is in each node
        //        result.Add(sb.ToString());
        //        testFunc(digits, sb);
            
        //}
        private static void dfsFunction(Dictionary<Int32, Char[]> dialerPad, int [] digits, Char[] result)
        {
            Dictionary<int, Char[]> visited = new Dictionary<int, Char[]>();
            foreach (var digit in digits)
            {
                if (visited.ContainsKey(digit))
                    continue;
                dialerPad.TryGetValue(digit, out char[] letters);
                visited.Add(digit, letters);
                foreach (Char l in letters)
                {
                  StringBuilder sb = new StringBuilder(l, result[digit]);//I need to save this to result somehow
                  dfsFunction(dialerPad, digits, result);
                }
                
                
            }
        }
    }
}
