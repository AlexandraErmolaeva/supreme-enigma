
using ConsoleApp2;
{/* У нас есть программа для кассового аппарата, которая умеет считать цену плитки
для напольного покрытия. Наша фирма вышла на рынок других стран, поэтому
расчет стоимости складывается из факторов:
1.Коэффициента наценки для страны. 
Для каждой страны (Россия (1), Беларусь(1.1), Казахстан(1.2), Армения(1.3)) есть свой коэффициент для наценки.
2. Для оптового покупателя:
от 0шт до 500шт - 0% скидки, от 500шт до 1000шт - 20%, от 1000шт - 50%
----------------------------------------------------------------------
Чтобы начать вычисления, необходимо авторизоваться - всего есть 3 попытки.
логин:	пароль:
Админ    000
Иванова  111
Петрова	 222
Сергеева 333
Васильева 444	
----------------------------------------------------------------------
В кодах стран Казахстан и Армения есть буквы. 
Вводить можно и русские и английкие буквы (заглавные или нет без разницы)
*/
}

// Без энкодинга не считываются русские буквы с консоли
Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

var userInterface = new UserInterface();

// Проверка логина и пароля пользователя
var userAuthorization = new UserAuthorization();
int authorizationСounter = 1;
bool isUserAuthorize = false;

while (authorizationСounter <= userAuthorization.AllowableNumberOfAuthorizationAttempts)
{
    string login = userInterface.InputLogin();
    string password = userInterface.InputPassword();

    isUserAuthorize = userAuthorization.TryAuthorizeUser(login, password);
    if (isUserAuthorize)
    {
        userInterface.PrintSuccessfulAuthorization();
        break;
    }
    else
    {
        userInterface.PrintUnsuccessfulAuthorization();
        if(authorizationСounter == userAuthorization.AllowableNumberOfAuthorizationAttempts)
        {
            userInterface.PrintAuthorizationAttemptFailed();
        }
        authorizationСounter++;
    }
}

// Выполняем кассовые операции при успешной авторизации
while (isUserAuthorize)
{
    Console.WriteLine("Нажмите ENTER для обслуживания следующего покупателя...");
    Console.ReadKey();
    userInterface.PrintCountryCode();

    var countryCodeProcess = new CountryCodeProcess();

    bool isCountryCodeCorrect;
    string verifiedСountryСode;

    // Проверка кода страны
    do
    {
        var countryCode = userInterface.InputCountryCode();

        verifiedСountryСode = countryCodeProcess.DetectCountryCodeWithAnyLetter(countryCode); // Приводим код страны к англ. заглавной букве

        isCountryCodeCorrect = countryCodeProcess.CheckCountryCode(verifiedСountryСode); // Проверка правильности введения кода страны

        if (isCountryCodeCorrect)
        {
            userInterface.MessageAboutCorrectCode();
        }
        else
        {
            userInterface.IncorrectCodeMessage();
        }
    }
    while (isCountryCodeCorrect == false);

    var tileQuantity = userInterface.InputTileQuantity();
    var tilePrice = userInterface.InputTilePrice();

    var rate = countryCodeProcess.DeterminationOfCountryRate(verifiedСountryСode); // Определение ценового коэффициента по коду страны

    var calculationOfDiscounts = new CalculationOfDiscounts(tileQuantity, tilePrice, rate);

    var tilePriceWithRate = calculationOfDiscounts.PriceWithRate(); // Стоимость плитки с учетом коэффициента, шт
    var discountPersentage = calculationOfDiscounts.Persentage(); // Определение скидки для оптовых покупателей
    var tilePaymentAmount = calculationOfDiscounts.PaymentAmount(tilePriceWithRate, discountPersentage); // Итоговая цена покупки
    var tilePriceWithoutDiscont = tilePrice * tileQuantity; // Цена без учета скидки и коэффициента

    var resultAmountToPay = userInterface.PrintTotalAmount(tilePriceWithoutDiscont, tilePriceWithRate, tilePaymentAmount, discountPersentage);
    Console.WriteLine(resultAmountToPay);
}
