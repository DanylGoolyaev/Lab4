using System;

namespace Laba4_task4
{
    public enum LicenseType
    {
        Trial = 0,
        Pro,
        Ultimate
    }
    public class ApplicationLicense
    {
        public LicenseType License
        {
            get;
            private set;
        } = LicenseType.Trial;

        private const string ProKey = "8N67H-M3CY9-QT7C4-2TR7M-TXYCV";
        private const string UltimateKey = "6P99N-YF42M-TPGBG-9VMJP-YKHCF";

        public LicenseType ChangeLicense(string key)
        {
            if (key == ProKey)
                AllowPro();
            else if (key == UltimateKey)
                AllowUltimate();
            else
                AllowTrial();

            return License;
        }

        private void AllowUltimate()
        {
            License = LicenseType.Ultimate;
        }
        private void AllowTrial()
        {
            License = LicenseType.Trial;
        }
        private void AllowPro()
        {
            License = LicenseType.Pro;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var license = new ApplicationLicense();

            Console.WriteLine("Введите ключ для доступа к версии Pro или Ultimate, или нажмите Enter, чтобы продолжить в бесплатной версии");
            license.ChangeLicense(Console.ReadLine());

            Console.WriteLine($"Ваша лицензия: {license.License}");

            Console.WriteLine("Доступные операции:");
            Console.WriteLine(@"Сложение - '+' (Trial+)");
            Console.WriteLine(@"Умножение - '*' (Pro+)");
            Console.WriteLine(@"Возведение в степень - '^' (Ultimate+)");
            Console.WriteLine();

            Console.WriteLine("Введите первый аргумент");
            double firstArgument = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите знак операции");
            char operation = Console.ReadLine()[0];

            Console.WriteLine("Введите второй аргумент");
            double secondArgument = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Ваша лицензия: {license.License}");
            switch (operation)
            {
                case '+':
                    Console.WriteLine("Операция сложения доступна");
                    Console.WriteLine($"Ответ: {firstArgument + secondArgument}");
                    break;

                case '*':
                    if (license.License >= LicenseType.Pro)
                    {
                        Console.WriteLine("Операция умножения доступна");
                        Console.WriteLine($"Ответ: {firstArgument * secondArgument}");
                    }
                    else
                        Console.WriteLine("В вашей версии продукта отсутствует доступ к функции умножения");

                    break;

                case '^':
                    if (license.License >= LicenseType.Ultimate)
                    {
                        Console.WriteLine("Операция возведения в степень доступна");
                        Console.WriteLine($"Ответ: {Math.Pow(firstArgument, secondArgument)}");
                    }
                    else
                        Console.WriteLine("В вашей версии продукта отсутствует доступ к функции возведение в степень");

                    break;
            }

            Console.ReadLine();
        }
    }
}