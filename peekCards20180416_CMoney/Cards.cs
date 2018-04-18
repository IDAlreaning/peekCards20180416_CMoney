using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peekCards20180416_CMoney
{
    public class Cards
    {
        //public int counter = 52;

        public List<int> listCards = new List<int>(52);

        public void newCards()
        {
            //counter = 52;
            listCards.Clear();
            for (int i = 0; i < 52; i++)
            {
                listCards.Add(i);
            }

            Random rnd = new Random();
            for (int i = 0; i < listCards.Count; i++)
            {
                int swap = rnd.Next(i, 52);
                int temp = listCards[i];
                listCards[i] = listCards[swap];
                listCards[swap] = temp;
            }
        }

    }
}
