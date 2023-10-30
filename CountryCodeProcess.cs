namespace ConsoleApp2
{
    internal class CountryCodeProcess
    {
        const string LOWERCASE_ENGLISH_LETTER_K = "k", UPPERCASE_ENGLISH_LETTER_K = "K",
                     UPPERCASE_RUSSIAN_LETTER_K = "К", LOWERCASE_RUSSIAN_LETTER_K = "к";
        const string UPPERCASE_ENGLISH_LETTER_A = "A", LOWERCASE_ENGLISH_LETTER_A = "a",
                     UPPERCASE_RUSSIAN_LETTER_A = "А", LOWERCASE_RUSSIAN_LETTER_A = "а";

        // Приведение кода страны Казахстан/Армения к одной заглавной английской букве
        public string DetectCountryCodeWithAnyLetter(string countryCode)
        {
            const string KAZAKSTAN_CODE = "003";
            const string ARMENIYA_CODE = "004";

            bool countryCodeIsKazakstanCodeAndAnyLetterK =
                countryCode == (KAZAKSTAN_CODE + LOWERCASE_ENGLISH_LETTER_K) ||
                countryCode == (KAZAKSTAN_CODE + UPPERCASE_RUSSIAN_LETTER_K) ||
                countryCode == (KAZAKSTAN_CODE + LOWERCASE_RUSSIAN_LETTER_K);

            if (countryCodeIsKazakstanCodeAndAnyLetterK)
            {
                countryCode = KAZAKSTAN_CODE + UPPERCASE_ENGLISH_LETTER_K;
            }

            bool countryCodeIsArmeniyaCodeAndAnyLetterA =
                countryCode == (ARMENIYA_CODE + LOWERCASE_ENGLISH_LETTER_A) ||
                countryCode == (ARMENIYA_CODE + UPPERCASE_RUSSIAN_LETTER_A) ||
                countryCode == (ARMENIYA_CODE + LOWERCASE_RUSSIAN_LETTER_A);

            if (countryCodeIsArmeniyaCodeAndAnyLetterA)
            {
                countryCode = ARMENIYA_CODE + UPPERCASE_ENGLISH_LETTER_A;
            }
            return countryCode;
        }

        // Проверка правильности введения кода страны
        public bool CheckCountryCode(string verifiedСountryСode)
        {
            const string RUSSIA_CODE = "001", BELARUS_CODE = "002", KAZAKSTAN_CODE = "003" + UPPERCASE_ENGLISH_LETTER_K,
                         ARMENIYA_CODE = "004" + UPPERCASE_ENGLISH_LETTER_A;
            switch (verifiedСountryСode)
            {
                case RUSSIA_CODE:
                case BELARUS_CODE:
                case KAZAKSTAN_CODE:
                case ARMENIYA_CODE:
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        // Определение ценового коэффициента по коду страны
        public decimal DeterminationOfCountryRate(string verifiedСountryСode)
        {
            const string RUSSIA_CODE = "001", BELARUS_CODE = "002", KAZAKSTAN_CODE = "003" + UPPERCASE_ENGLISH_LETTER_K,
                         ARMENIYA_CODE = "004" + UPPERCASE_ENGLISH_LETTER_A;
            decimal rate;
            switch (verifiedСountryСode)
            {
                case RUSSIA_CODE:
                    {
                        const decimal RUSSIA_RATE = 1M;
                        return rate = RUSSIA_RATE;
                    }
                case BELARUS_CODE:
                    {
                        const decimal BELARUS_RATE = 1.1M;
                        return rate = BELARUS_RATE;
                    }
                case KAZAKSTAN_CODE:
                    {
                        const decimal KAZAKSTAN_RATE = 1.2M;
                        return rate = KAZAKSTAN_RATE;
                    }
                case ARMENIYA_CODE:
                    {
                        const decimal ARMENIYA_RATE = 1.3M;
                        return rate = ARMENIYA_RATE;
                    }
                default:
                    {
                        return rate = 0;
                    }
            }
        }
    }
}

