using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class Dealer
    {
        public int handValue { get; set; }
        public int handCount { get; set; }
        Random random = new Random();

        public bool isMakeMove()
        {
            if (handValue <= 15)
            {
                return true;
            }
            else if (handValue > 15 && handValue < 18)
            {
                int rand = random.Next(1, 2);
                if(rand == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (handValue >= 18)
            {
                int rand = random.Next(1, 4);
                if (rand == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
