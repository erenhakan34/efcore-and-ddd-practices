namespace Infrastructure.Utils
{
    public static class CitizenNumberValidator
    {
        public static bool ValidateCitizenNumber(string citizenNumber) 
        {
            bool returnvalue = false;
            if (citizenNumber.Length == 11)
            {
                long ATCNumber, BTCNumber, parsedCitizenNumber;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                parsedCitizenNumber = long.Parse(citizenNumber);

                ATCNumber = parsedCitizenNumber / 100;
                BTCNumber = parsedCitizenNumber / 100;

                C1 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C2 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C3 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C4 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C5 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C6 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C7 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C8 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                C9 = ATCNumber % 10; ATCNumber = ATCNumber / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNumber * 100) + (Q1 * 10) + Q2 == parsedCitizenNumber);
            }

            return returnvalue;
        }
    }
}
