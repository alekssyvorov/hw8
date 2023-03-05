using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hw8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string myStr = "Містер Дурслі завмер. Його охопив жах. Він озирнувся на тих шептунів, наче хотів їм щось сказати, проте передумав.\r\n\r\nВін перебіг вулицю, поспіхом піднявся до кабінету, гукнув секретарці не турбувати його, схопив телефон і почав набирати свій домашній номер, аж раптом зупинився. Поклав слухавку й замислено погладив вуса. Та ні, яка дурниця. Виходить Поттер — не таке вже й рідкісне прізвище. Є безліч людей, які мають не тільки це прізвище, а й сина на ім'я Гаррі. Так міркуючи, Дурслі вже навіть не знав, чи його племінника справді звуть Гаррі. Він його ніколи й не бачив. Може, то Гарві. Або Гарольд. Не варто хвилювати місіс Дурслі, вона й так дратується на саму згадку про сестру. Він їй не докоряв: якби така сестра була в нього… А все ж оті люди в мантіях…\r\n\r\nТепер Дурслі було значно важче зосередитися на свердлах і, виходячи о п'ятій пополудні з будинку, він був такий неуважний, що наскочив на когось біля самих дверей.";
            #region
            
            Console.WriteLine($"Count sentence = {CounterSentense(myStr)}");
            #endregion

            string[] sentences = myStr.Split(new char[] { '.', '!', '?', '…' });

            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].Trim();
                if (sentence.Length > 0)
                {
                    char firstChar = sentence[0];
                    if (char.IsUpper(firstChar))
                    {
                        char lowerFirstChar = char.ToLower(firstChar);
                        sentences[i] = lowerFirstChar + sentence.Substring(1);
                    }
                }
            }

            string newMyStr = string.Join(" ", sentences);
            string[] words = newMyStr.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-', '—', '(', ')', '«', '»' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> masNameLastname = new List<string>();
            
            foreach (var item in words)
            {
                if (char.IsUpper(item[0]))
                    masNameLastname.Add(item);
            }

            HashSet<string> hs1 = new HashSet<string>();
            foreach (var item in masNameLastname)
                hs1.Add(item);

            
            string newString = string.Empty;
            foreach (var item in hs1)
            {
                newString += item + " ";
            }

            string[] resultMas = newString.Trim().Split();

            Console.WriteLine($"Количество уникальных слов: {resultMas.Length}");
            Console.WriteLine("Уникальные слова: ");
            for (int i = 0; i < resultMas.Length; i++)
            {
                Console.Write(resultMas[i] + " ");
            }


            //Второй вариант, но мы не учили ни лябда выражения, ни Where, ни Distinct

            //var myWords = words.Where(word => char.IsUpper(word[0])).Distinct().ToArray();

            //Console.WriteLine($"Количество уникальных слов: {myWords.Length}");
            //Console.Write("Уникальные слова: ");
            //foreach (string word in myWords)
            //{
            //    Console.Write(word + " ");
            //}
            //Console.WriteLine();
            Console.ReadLine();
        }


        static int CounterSentense(string myStr)
        {
            int count = 0;
            for (int i = 0; i < myStr.Length; i++)
            {
                if (myStr[i].ToString() == "." || myStr[i].ToString() == "…")
                    count++;
            }
            return count;
        }
    }
}
