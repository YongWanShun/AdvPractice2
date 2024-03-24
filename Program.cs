using System;
namespace AdvPractice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XAXBKernel xaxb = new XAXBKernel();
            xaxb.SetLuckyNumber("123");
            Console.WriteLine("{0} is legal? {1}", "1234", XAXBKernel.IsLegal("1234"));
            Console.WriteLine("{0} is legal? {1}", "123", XAXBKernel.IsLegal("123"));
            Console.WriteLine("{0}: {1}", "566", XAXBKernel.IsLegal("566") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "787", XAXBKernel.IsLegal("787") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "770", XAXBKernel.IsLegal("770") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "079", XAXBKernel.IsLegal("079") ? "legal" : "illegal");
            string result1 = xaxb.GetResult("124");
            Console.WriteLine("{0} {1}: {2}", xaxb.GetLuckyNumber(), "124", result1);
            string result2 = xaxb.GetResult("123");
            Console.WriteLine("{0} {1}: {2}", xaxb.GetLuckyNumber(), "123", result2);
            Console.WriteLine("{0} gameover: {1}", "125", xaxb.IsGameover("125"));
            Console.WriteLine("{0} gameover: {1}", "123", xaxb.IsGameover("123"));
        }
        

        
        }

    public class XAXBKernel
    {
        private string luckyNum;
        
        //隨機產生三個數字
        public XAXBKernel()
        {
            
        }

        public bool SetLuckyNumber(String newLuckyNum)
        {
            if (IsLegal(newLuckyNum))
            {
                luckyNum = newLuckyNum;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetLuckyNumber()
        {
            return luckyNum;
        }

        //檢查輸入的數字是否正確
        public static bool IsLegal(string userNumber)
        {
            if (userNumber.Length != 3)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < userNumber.Length; j++)
                {
                    if (userNumber[i] == userNumber[j])
                        return false;
                }
            }
            return true;
        }

        /*判斷 XAXB
        public static string CompareXAXB(string data1, string data2)
        {
            int aCount = 0;
            int bCount = 0;

            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] == data2[i])
                {
                    aCount++;
                }
                else if (data2.Contains(data1[i]))
                {
                    bCount++;
                }
            }
            return $"{aCount}A{bCount}B";
        }
        */
        public string GetResult(string userNumber)
        {
            int aCount = 0;
            int bCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (userNumber[i] == luckyNum[i])
                {
                    aCount++;
                }
                else if (luckyNum.Contains(userNumber[i]))
                {
                    bCount++;
                }
            }
            return $"{aCount}A{bCount}B";
        }

        public bool IsGameover(String userNumber)
        {
            if (GetResult(userNumber) == "3A0B")
            {
                return true;
            }
            return false;
        }
    }
}