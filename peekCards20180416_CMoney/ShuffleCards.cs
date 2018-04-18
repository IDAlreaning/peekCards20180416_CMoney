using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peekCards20180416_CMoney
{
    class ShuffleCards : Cards
    {
        string outputContent;

        public string[] cardsForm = new string[4] { "黑桃", "紅心", "方塊", "梅花" };
        public string[] cardsNumber = new string[13] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "J", "Q", "K" };


        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < listCards.Count; i++)
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
            bool IsCardNotEmpty = listCards.Count != 0 ? true : false;

            if (!IsCardNotEmpty)
            {
                Console.WriteLine("=== 牌數不夠，故發新牌 ===");
                Console.WriteLine();
                newCards();
            }

            for (int i = listCards.Count - 1; i >= 0; i--)
            {
                    Console.WriteLine($"你拿到的卡牌是: {cardsForm[listCards[i] / 13]},{cardsNumber[listCards[i] % 13]}");
                    outputContent += $"{cardsForm[listCards[i] / 13]},{cardsNumber[listCards[i] % 13]}\r\n";
                    listCards.Remove(listCards[i]);
                    break;
            }
        }
        public void peekCard()
        {
            Console.Write("Peek哪一張: ");
            int inputPeek = int.Parse(Console.ReadLine());

            Console.WriteLine($"你拿到的卡牌是: {cardsForm[listCards[inputPeek - 1] / 13]},{cardsNumber[listCards[inputPeek - 1] % 13]}");

        }

        public void ExportPassedCard(string directoryPath)
        {
            File.WriteAllText(directoryPath + "\\PassedCard_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".csv", outputContent);
        }

        public void ExportRemainCards(string directoryPath)
        {
            string remainCards = "";
            for (int i = 0; i < listCards.Count; i++)
            {
                if (listCards[i] != -1)
                {
                    remainCards += $"{cardsForm[listCards[i] / 13]},{cardsNumber[listCards[i] % 13]}\r\n";
                }
            }
            File.WriteAllText(directoryPath + "\\RemainCards_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".csv", remainCards);

        }
    }
}
