using System;
using System.Collections.Generic;
using System.Linq;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(string S)
    {
        Dictionary<string, int[]> billstore = new Dictionary<string, int[]>();
        char character = (char)10;
        var billrow = S.Split(character);

        foreach (var item in billrow)
        {
            var billrowdata = item.Split(',');
            int callduration = (int)TimeSpan.Parse(billrowdata[0]).TotalSeconds;
            int callprice = 0;

            // calc call price
            if (callduration > 300)
            {
                callprice = callduration / 60 * 150;
                if (callduration % 60 != 0)
                {
                    callprice += 150;
                }
            }
            else
            {
                callprice = callduration * 3;
            }

            // add price and duration to store
            if (billstore.ContainsKey(billrowdata[1]))
            {
                billstore[billrowdata[1]][0] += callduration;
                billstore[billrowdata[1]][1] += callprice;
            }
            else
            {
                billstore.Add(
                    billrowdata[1],
                    new int[] { callduration, callprice });
            }
        }

        //find largest
        int max = 0;
        int totalprice = 0;
        List<string> promotionNumbers = new List<string>();

        foreach (var item in billstore)
        {
            var callprice = item.Value[1];

            //calc total bill
            totalprice += item.Value[1];

            // promotion check
            if (callprice > max)
            {
                max = callprice;
                promotionNumbers.Clear();

            }
            if (callprice == max)
            {
                promotionNumbers.Add(item.Key);
            }
        }

        //calc promotion favorit
        Dictionary<string, int> promotionFav = new Dictionary<string, int>();
        foreach (var phoneNum in promotionNumbers)
        {
            int phoneSum = 0;
            foreach (char c in phoneNum)
            {
                if (Char.IsDigit(c))
                {
                    phoneSum += c;
                }
            }
            promotionFav.Add(phoneNum, phoneSum);
        }

        //aplly promotion discount
        int promotionDiscount = billstore[
                                    promotionFav.First(x => x.Value == promotionFav.Values.Min()).Key]
                                    [1];
        return (totalprice - promotionDiscount);
    }
}