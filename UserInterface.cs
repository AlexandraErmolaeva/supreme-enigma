namespace ConsoleApp2
{
    internal class UserInterface
    {
        public string InputLogin()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            return login;
        }

        public string InputPassword()
        {
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();
            return password;
        }

        public void PrintSuccessfulAuthorization()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вы успешно авторизованы");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintUnsuccessfulAuthorization()
        {
            Console.WriteLine("Логин или пароль введен неверно!");
        }

        public void PrintAuthorizationAttemptFailed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы исчерпали количество попыток авторизации. Обратитесь к администратору");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintCountryCode()
        {
            Console.WriteLine("=================================\n" +
                              "Код для страны - покупателя:\n" +
                              "Россия:    001  || Беларусь:  002\n" +
                              "Казахстан: 003K || Армения:  004A\n" +
                              "================================= ");
        }

        public string InputCountryCode()
        {
            Console.WriteLine("Введите код страны:");
            var countryCode = Console.ReadLine();
            return countryCode;
        }

        public void MessageAboutCorrectCode()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Код введен верно");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void IncorrectCodeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы ввели неверный код!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public int InputTileQuantity()
        {
            Console.Write("Введите количество плитки, шт:  ");
            var tileQuantity = Convert.ToInt32(Console.ReadLine());
            return tileQuantity;
        }

        public int InputTilePrice()
        {
            Console.Write("Введите цену плитку, руб:  ");
            var tilePrice = Convert.ToInt32(Console.ReadLine());
            return tilePrice;
        }

        public string PrintTotalAmount(decimal tilePriceWithoutDiscont, decimal tilePriceWithRate, decimal tilePaymentAmount, decimal discountPersentage)
        {
            string info = String.Format
                         ("=================================\n" +
                          $"Первоначальная стоимость покупки     : {tilePriceWithoutDiscont:C}\n" +
                          $"Цена с коэффициентом, шт             : {tilePriceWithRate:C}\n" +
                          $"Процент скидки                       : {discountPersentage:P}\n" +
                          $"СУММА К ОПЛАТЕ                       : {tilePaymentAmount:C}\n");
            return info;
        }
    }
}
