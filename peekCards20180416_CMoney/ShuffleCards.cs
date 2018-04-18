using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peekCards20180416_CMoney
{
    class ShuffleCards : Cards
    {
        public string[] cardsForm = new string[4] { "黑桃", "紅心", "方塊", "梅花" };
        public string[] cardsNumber = new string[13] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "J", "Q", "K" };


        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < 52; i++)
            {
                if (listCards[i] != -1)
                {
                    temp += String.Format($"{cardsForm[listCards[i] / 13]},{cardsNumber[listCards[i] % 13]}\t");
                }
            }
            return temp;
        }

        public void getCard()
        {
            bool IsCardNotEmpty = counter != 0 ? true : false;

            if (!IsCardNotEmpty)
            {
                Console.WriteLine("=== 牌數不夠，故發新牌 ===");
                Console.WriteLine();
                newCards();
            }

            for (int i = 0; i < 52; i++)
            {
                if (listCards[i] != -1)
                {
                    Console.WriteLine($"你拿到的卡牌是: {cardsForm[listCards[i] / 13]},{cardsNumber[listCards[i] % 13]}");
                    listCards[i] = -1;
                    counter--;
                    break;
                }
            }
        }
        public void peekCard()
        {
            Console.Write("Peek哪一張: ");
            int inputPeek = int.Parse(Console.ReadLine());

            Console.WriteLine($"你拿到的卡牌是: {cardsForm[listCards[inputPeek] / 13]},{cardsNumber[listCards[inputPeek - 1] % 13]}");

        }
    }
}
