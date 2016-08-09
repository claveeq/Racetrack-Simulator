using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrack_Simulator
{
    public class Bet
    {
        public int Amount;
        public int Eagle;
        public Guy Bettor;

        public string GetDescripion()
        {
            return Bettor.Name + " Bets " + Amount + " on Eagle " + Eagle;
        }
        public int PayOut(int Winner)
        {  
            if (Eagle == Winner) 
            {
                return Amount;
            } 
            else 
            {
                return -Amount;
            }

        }
    }
}
