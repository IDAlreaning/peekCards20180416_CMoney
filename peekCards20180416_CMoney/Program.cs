using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace peekCards20180416_CMoney
{
    class Program
    {

        static void Main(string[] args)
        {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).ToString() + "\\Export";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            ShuffleCards cardNum = new ShuffleCards();
            cardNum.newCards();
            int input;

            do
            {
                Console.Write("Options: 1)remain cards, 2)get card, 3)發四張牌, 4)Peek, 5) -1)Quit: ");
                  input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:// 發剩下的牌(有花色和數字)
                        Console.WriteLine($"剩下的牌有: {cardNum.listCards.Count}張");
                        Console.WriteLine(cardNum.ToString());
                        break;
                    case 2:// 隨機給使用者的牌(有花色和數字)
                        cardNum.getCard();
                        break;
                    case 3:// 隨機給使用者的牌(有花色和數字)
                        for (int i = 0; i < 4; i++)
                        { cardNum.getCard(); }
                        break;
                    case 4:
                        cardNum.peekCard();
                        break;
                    case 5:
                        cardNum.ExportPassedCard(directoryPath);

                        cardNum.ExportRemainCards(directoryPath);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("--------------------------------------------------------");

            } while (input != -1);
            Console.WriteLine("程式結束");



            Console.ReadKey();
        }
    }
}
