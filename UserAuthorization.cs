
namespace ConsoleApp2
{
    internal class UserAuthorization
    {
        // Чтобы авторизоваться, индекс логина должен быть равен индексу пароля 
        public string[] LoginList = { "Админ", "Иванова", "Петрова", "Сергеева", "Васильева"};
        public string[] PasswordList = { "000", "111", "222", "333", "444"};
        public int AllowableNumberOfAuthorizationAttempts = 3;

        // Авторизация пользователя
        public bool TryAuthorizeUser(string login, string password)
        {
            int index = 0;
            while (index < LoginList.Length && index < PasswordList.Length)
            {
                string loginByCurrentIndex = LoginList[index];
                bool loginMatched = loginByCurrentIndex == login;

                string passwordByCurrentIndex = PasswordList[index];
                bool passwordMatched = passwordByCurrentIndex == password;

                bool isUserAuthorize = loginMatched && passwordMatched;
                if (isUserAuthorize)
                {
                    return true;
                }
                else
                {
                    index++;
                    continue;
                }
            }
            return false;
        }
    }
}
