using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CholatesDispenser
{
    public class dispenser
    {
        //int red , green , blue ,sliver ,crimson ,purpule , pink;
        public Dictionary<string, int> choclates = new Dictionary<string, int>();
        public dispenser(int count) {
            choclates["red"] = count;
            choclates["blue"] = count;
            choclates["green"] = count;
            choclates["sliver"] = count;
            choclates["crimson"] = count;
            choclates["purpule"] = count;
            choclates["pink"] = count;
        }

        public void addCholates(string color, int count)
        {
            choclates[color] += count;
        }

        public Dictionary<string, int> removeCholates(int count)
        {
            Dictionary<string, int> result  = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> kp in choclates)
            {
                choclates[kp.Key] = kp.Value - count;
                result[kp.Key] = (choclates[kp.Key] > count ? count : kp.Value);
            }  
            return choclates;
        }

        public Dictionary<string, int> dispenseCholates(int count) {

            Dictionary<string, int> new_chocolate = new Dictionary<string, int>();

            while (count > 0) {
                foreach (KeyValuePair<string, int> i in choclates) {
                    if (i.Value > 0)
                    {
                        choclates[i.Key] = i.Value - 1;
                        new_chocolate[i.Key] = new_chocolate.GetValueOrDefault(i.Key, 0) + 1;
                        count--;
                    }
                    if (count == 0)
                        break;
                }
            }
            return new_chocolate;
        }

        public int dispenseChocolateOfColor(int count, string color) {

            choclates[color] -= count;
            return count;
        }

        public int[] noOfCholcolate()
        {
            int[] result = new int[7];
            int count = 0;
            foreach (KeyValuePair<string, int> kp in choclates) {
                result[count] = kp.Value;
                count++;
            }

            return result;
        }

        public string[] sortCholcoateBasedOnCount()
        {
            string[] result = new string[7];
            int count = 0;
            foreach(KeyValuePair <string,int> i in choclates.OrderBy(x => x.Value))
            {
                result[count] = i.Key;
                count++;
            }
            return result;  
        }


        public void chageChocolateColorAllxCount(int number ,string color,string finalColor ) {
            choclates[color] -= number;
            choclates[finalColor] += number;
        }

        public void chageChocolateColorAllOfxCount( string color, string finalColor)
        {
            int count = choclates[color] ;
            choclates[color] = 0;
            choclates[finalColor] += count;
        }

        public void freshPick(string color, int count) {
            choclates[color] -= (choclates[color] > count ? count: choclates[color] );
            Console.WriteLine($"the chocolate {color} --> {(choclates[color] > count ? count : choclates[color])} has been dispensed.");
        }

        public Dictionary<string , int> dispenseRainbowChocolates(int count) {
            Dictionary<string ,int> result = new Dictionary<string ,int>();

            while (count > 0)
            {
                foreach (KeyValuePair<string, int> i in choclates.OrderBy(x => x.Value))
                {
                    choclates[i.Key] -= (choclates[i.Key] > 3 ? 3 : choclates[i.Key]);
                    result[i.Key] += (choclates[i.Key] > 3 ? 3 : choclates[i.Key]);
                    count -= (choclates[i.Key] > 3 ? 3 : choclates[i.Key]);
                }
                if (count == 0) break;
            }

            return result;
        }

    }
}