using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class User
    {
        public int Id { get; set; }
        string username { get; set; }
        int balance { get; set; }
        int blackjacks { get; set; }
    }
}
