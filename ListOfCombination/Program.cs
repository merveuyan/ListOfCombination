using System;
using System.Collections.Generic;
using System.IO;

namespace ListOfCombination
{
    class Program
    {
        private static int again;

        public static List<int> GetNumbers()
        {
            List<int> numList = new List<int>();
            string numStringNew = null;

            Console.WriteLine("Sayıları giriniz:");
            string numString = Console.ReadLine();

            GetNumberAgain:

            if (numStringNew != null)
            {
                numString = numStringNew;
            }

            string[] numbers = numString.Split(',');

            int number = 0;

            for (int p = 0; p < numbers.Length; p++)
            {
                if (int.TryParse(numbers[p], out number))
                {
                    if (number < 1 || number > 54)
                    {
                        Console.WriteLine("1 ile 54 arasında bir sayı giriniz");
                        numStringNew = Console.ReadLine();
                        goto GetNumberAgain;
                    }
                    numList.Add(number);
                }
                else
                {
                    RepeatOfNumber:
                    Console.WriteLine("{0}. elemanı ({1}) hatalı girdiniz, Lütfen tekrar giriniz.", p + 1, numbers[p]);
                    if (int.TryParse(Console.ReadLine(), out again))
                    {
                        numList.Add(again);
                    }
                    else
                    {
                        goto RepeatOfNumber;
                    }
                }
            }

            if (numList.Count < 6)
            {
                Console.WriteLine("Gireceğiniz değer 6'dan küçük olamaz.");
                numStringNew = Console.ReadLine();
                goto GetNumberAgain;
            }

            if (numList.Count > 54)
            {
                Console.WriteLine("Gireceğiniz değer 54'ten büyük olamaz.");
                numStringNew = Console.ReadLine();
                goto GetNumberAgain;
            }

            return numList;
        }

        public static List<string> CreateCombinations(List<int> numbers)
        {
            List<string> combinations = new List<string>();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        for (int l = k + 1; l < numbers.Count; l++)
                        {
                            for (int m = l + 1; m < numbers.Count; m++)
                            {
                                for (int n = m + 1; n < numbers.Count; n++)
                                {
                                    List<int> combination = new List<int>();
                                    combination.Add(numbers[i]);
                                    combination.Add(numbers[j]);
                                    combination.Add(numbers[k]);
                                    combination.Add(numbers[l]);
                                    combination.Add(numbers[m]);
                                    combination.Add(numbers[n]);
                                    combinations.Add(string.Join(",", combination));
                                }
                            }
                        }
                    }
                }
            }
            return combinations;
        }

        private static void PrintToFile0(List<string> combinations)
        {
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            string filePath = @"C:\metinbelgesi.txt";

            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            StreamWriter sw = new StreamWriter(fs);

            // Dosyaya ekleyeceğimiz yazıyı WriteLine() metodu ile yazacağız.
            sw.WriteLine();

            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Flush();

            //İşimiz bitince kullandığımız nesneleri iade ettik.
            sw.Close();
            fs.Close();
        }

        static void Main(string[] args)
        {
            var numbers = GetNumbers();

            var combinations = CreateCombinations(numbers);

            // Dosyaya yazdırmanın çok daha pratik yolu:
            var fileName = "kombinasyonlar.txt";
            var filePath = Path.Combine(@"c:\", fileName);
            File.WriteAllLines(filePath, combinations);

            Console.WriteLine($"{combinations.Count} adet kombinasyon üretildi ve");
            Console.WriteLine($"{filePath} adresine kaydedildi. bakabilirsiniz.");

            Console.Read();
        }
    }
}