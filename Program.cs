using System.Diagnostics;


class Lab2
{
    static void Main()
    {
        Console.Clear();
        UserName.TestNameCreationWithCorrectInput();
        UserName.TestNameCreationWithIncorrectInput();
        CVVCode.TestCCVCodeCreationWithCorrectInput();
        CVVCode.TestCCVCodeCreationWithIncorrectInput();
        ExpirationDate.TestExpDateCreationWithCorrectInput();
        ExpirationDate.TestExpDateCreationWithIncorrectInput();
        CreditCardNumber.TestCreditCardNumberCreationWithCorrectInput();
        CreditCardNumber.TestCreditCardNumberCreationWithIncorrectInput();
        CreditCard.TestCreditCardCreationWithCorrectInput();
        CreditCard.TestCreditCardCreationWithIncorrectInput();
        User.TestUserCreationWithCorrectInput();
        User.TestUserCreationWithIncorrectInput();
        DriverProgram();


    }

    static void DriverProgram()
    {
        Thread.Sleep(3000);
        Console.Clear();

        User TheUser = new User();
        UserName TheUserName = new UserName();
        CreditCard TheCreditCard = new CreditCard();

        Console.WriteLine("Hello Dear User, this program will let you create an User for this e-commerce store");
        Console.WriteLine("\nLet's start off by your name, enter ONLY ALPHABETIC LETTERS");
        Console.WriteLine("\nPlease write your FIRST NAME below:");
        string firstname = Console.ReadLine();
        Console.WriteLine("\nNow, if you wish, input your MIDDLE NAME below:");
        string middlename = Console.ReadLine();
        Console.WriteLine("\nNow, please enter your LAST NAME");
        string lastname = Console.ReadLine();

        Console.WriteLine("\nLet me analyze your information");
        Thread.Sleep(3000);
        TheUserName = UserName.CreateName(firstname, lastname, middlename);

        if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
        {
            Console.Clear();
            Console.WriteLine("Empty input detected");
            Environment.Exit(-1);
        }
        if(TheUserName == null)
        {
            Environment.Exit(-1);
        }

        Console.Clear();

        Console.WriteLine("Well done, now let's establish your credit card information");
        Console.WriteLine("\nLet's start off with you credit card number");
        Console.WriteLine("\nWrite 4 numbers, a space, 4 numbers, a space, 4 numbers, a space, 4 numbers. i.e 0000 0000 0000 000");
        string creditcardnumber = Console.ReadLine();
        Console.WriteLine("\nNow, enter the expiration date, first the month, then a forward slash '/', followed by the day using numbers. use 1 number for the month and 2 for the day. i.e 5/21 , 4/16 ");
        string expirationdate = Console.ReadLine();
        Console.WriteLine("\nFinally, enter the CVV code at the back of your card. It's a 3 digit number");
        string cvvcode = Console.ReadLine();

        Console.WriteLine("\nLet me analyze your information");
        Thread.Sleep(3000);
        TheCreditCard= CreditCard.CreateCreditCard(creditcardnumber, expirationdate, cvvcode);

         if (string.IsNullOrEmpty(creditcardnumber) || string.IsNullOrEmpty(expirationdate) || string.IsNullOrEmpty(cvvcode))
        {
            Console.Clear();
            Console.WriteLine("Empty input detected");
            Environment.Exit(-1);
        }
        if(TheCreditCard == null)
        {
            Environment.Exit(-1);
        }

        TheUser = User.Create(TheUserName, TheCreditCard);

        Console.Clear();

        Console.WriteLine("\nCongratulations user, your information has been saved succesfully!");
        Console.WriteLine($"Your name is {firstname} {middlename} {lastname}");
        Console.WriteLine($"Your credit card number is {creditcardnumber}, it's expiration date is {expirationdate}, and it's cvv code is {cvvcode}");    

    }

    //User Class

    class User
    {
        public UserName _Name { get; set; }
        public CreditCard _CreditCard { get; set; }

        //Create method for User

        public static User? Create(UserName userName, CreditCard creditCard)
        {

            if(userName == null || creditCard == null)
            {
                return null;
            }
            else
            {
                User user = new User();
                user._Name = userName;
                user._CreditCard = creditCard;

                return user;
            }

        }

        //Test method for correct input

        public static void TestUserCreationWithCorrectInput()
        {
            User MyUser = new User();
            UserName MyUserName = UserName.CreateName("Carlos","Blanco","Felipe");
            CreditCard MyCreditCard = CreditCard.CreateCreditCard("3333 3333 3333 3333", "9/23", "999");
            MyUser = User.Create(MyUserName, MyCreditCard);
            Debug.Assert(MyUser._Name.FirstName == "Carlos");
            Debug.Assert(MyUser._Name.LastName == "Blanco");
            Debug.Assert(MyUserName.Middlename == "Felipe");
            Debug.Assert(MyUser._CreditCard._CreditCardNumber.InputCreditCardNumber == "3333 3333 3333 3333");
            Debug.Assert(MyUser._CreditCard._ExpirationDate.Month == 9);
            Debug.Assert(MyUser._CreditCard._ExpirationDate.Day == 23);
            Debug.Assert(MyUser._CreditCard._CVVCode.CreditCardCVV == "999");
            Console.WriteLine("Final tests passed!");

        }

        //Test method for incorrect input

        public static void TestUserCreationWithIncorrectInput()
        {
            User MyIncorrectUser = new User();
            UserName MyIncorrectUserName = UserName.CreateName("@","Blanco","Felipe");
            CreditCard MyIncorrectCreditCard = CreditCard.CreateCreditCard("33 3333 3333 3333", "9/2", "999");
            MyIncorrectUser = User.Create(MyIncorrectUserName, MyIncorrectCreditCard);
            Debug.Assert(MyIncorrectUser == null);
            MyIncorrectUserName = UserName.CreateName("lll","Blanco","Fipe");
            MyIncorrectCreditCard = CreditCard.CreateCreditCard("33 3333 3333 3333", "2", "@@99");
            MyIncorrectUser = User.Create(MyIncorrectUserName, MyIncorrectCreditCard);
            Debug.Assert(MyIncorrectUser == null);
            Console.WriteLine("Final tests passed!");
        }



    }

    //UserName Class

    class UserName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }

        //Create Method

        public static UserName? CreateName(string firstname, string lastname, string? middlename)
        {
            bool ValidOrNot = true;

            foreach (char a in firstname)
            {
                if ('A' > a || a > 'Z' && a < 'a' || a > 'z')
                {
                    ValidOrNot = false;
                }

            }

            foreach (char a in lastname)
            {
                if ('A' > a || a > 'Z' && a < 'a' || a > 'z')
                {
                    ValidOrNot = false;

                }

            }

            if (middlename != null)
            {
                foreach (char a in middlename)
                {
                    if ('A' > a || a > 'Z' && a < 'a' || a > 'z')
                    {
                        ValidOrNot = false;

                    }

                }

            }

            if (ValidOrNot)
            {
                UserName Name = new UserName();
                Name.FirstName = firstname;
                Name.LastName = lastname;
                Name.Middlename = middlename;

                return Name;

            }
            else
            {
                Console.WriteLine("Invalid input detected");
                return null;

            }

        }
        //Test method for correct input

        public static void TestNameCreationWithCorrectInput()
        {
            UserName? name = new UserName();
            name = UserName.CreateName("Carlos", "Blanco", null);
            Debug.Assert(name.FirstName == "Carlos");
            Debug.Assert(name.LastName == "Blanco");
            Debug.Assert(name.Middlename == null);
            Console.WriteLine("All tests passed!");

        }

        //Test method for incorrect input

        public static void TestNameCreationWithIncorrectInput()
        {
            UserName? invalidname = new UserName();
            invalidname = UserName.CreateName("@", "Blan8", "esk_");
            Debug.Assert(invalidname == null);
            Console.WriteLine("All tests passed!");
        }

    }

    //Credit Card class

    class CreditCard
    {
        public CreditCardNumber _CreditCardNumber { get; set; }
        public ExpirationDate _ExpirationDate { get; set; }
        public CVVCode _CVVCode { get; set; }

        //Credit Card creator method

        public static CreditCard CreateCreditCard(string creditcardnumber, string expirationdate, string cvvcode)
        {

            if (creditcardnumber == null || expirationdate == null || cvvcode == null)
            {
                return null;
            }
            else
            {

                CreditCard NewCreditCard = new CreditCard();

                NewCreditCard._CreditCardNumber = CreditCardNumber.CreateCreditCardNumber(creditcardnumber);
                NewCreditCard._ExpirationDate = ExpirationDate.CreateExpirationDate(expirationdate);
                NewCreditCard._CVVCode = CVVCode.CreateCVVCode(cvvcode);

                if(NewCreditCard._CreditCardNumber == null || NewCreditCard._ExpirationDate == null || NewCreditCard._CVVCode == null)
                {
                    return null;
                }
                else
                {

                return NewCreditCard;

                }


            }

        }

        //Test method for correct Credit Card (I couldn't do it, I needed to parse a string to a class object, and I don't know how to do that)

         public static void TestCreditCardCreationWithCorrectInput()
        {
            CreditCard MyCorrectCreditCard = new CreditCard();
            MyCorrectCreditCard = CreditCard.CreateCreditCard("1111 1111 1111 1111", "5/21", "333");
            Debug.Assert(MyCorrectCreditCard._CreditCardNumber.InputCreditCardNumber == "1111 1111 1111 1111");
            Debug.Assert(MyCorrectCreditCard._ExpirationDate.Day == 21);
            Debug.Assert(MyCorrectCreditCard._ExpirationDate.Month == 5);
            Debug.Assert(MyCorrectCreditCard._CVVCode.CreditCardCVV == "333");
            MyCorrectCreditCard = CreditCard.CreateCreditCard("8888 0000 8888 0000", "4/22", "765");
            Debug.Assert(MyCorrectCreditCard._CreditCardNumber.InputCreditCardNumber == "8888 0000 8888 0000");
            Debug.Assert(MyCorrectCreditCard._ExpirationDate.Day == 22);
            Debug.Assert(MyCorrectCreditCard._ExpirationDate.Month == 4);
            Debug.Assert(MyCorrectCreditCard._CVVCode.CreditCardCVV == "765");
            Console.WriteLine("All CreditCard Tests passsed!");
        }


        //Test method for incorrect Credit Card

        public static void TestCreditCardCreationWithIncorrectInput()
        {
            CreditCard MyIncorrectCreditCard = new CreditCard();
            MyIncorrectCreditCard = CreditCard.CreateCreditCard("4", "%", "&");
            Debug.Assert(MyIncorrectCreditCard == null);
            MyIncorrectCreditCard = CreditCard.CreateCreditCard("8888 0000 8888 0000", "4/22", "&");
            Debug.Assert(MyIncorrectCreditCard == null);
            Console.WriteLine("All CreditCard Tests passed!");

        }



    }

    //Credit Card Number Class

    class CreditCardNumber
    {
        public string InputCreditCardNumber { get; set; }

        //Create Method for Credit Card Number

        public static CreditCardNumber CreateCreditCardNumber(string creditcardnumber)
        {
            bool CreditCardNumberValidOrNot = true;

            //Checks if number has spaces

            if (creditcardnumber.Contains(" ") == false)
            {
                Console.WriteLine("Please Write your number with SPACES");
                CreditCardNumberValidOrNot = false;
                return null;
            }
            else
            {
                string[] splitcreditcard = creditcardnumber.Split(" ");

                //Checks there are 4 sections of numbers i.e 7777 7777 are just 2 number Sections

                if (splitcreditcard.Length != 4)
                {
                    Console.WriteLine("Please Write 4 NUMBER SECTIONS");
                    CreditCardNumberValidOrNot = false;
                    return null;
                }
                else
                {

                    //Checks there are 4 numbers per section i.e 777777 77777777 7777777 7777777 has 4 number SECTIONS, but more than 4 numbers per section
                    for (int i = 0; i < splitcreditcard.Length; i++)
                    {
                        if (splitcreditcard[i].Length != 4)
                        {
                            Console.WriteLine("Please Write 4 NUMBERS IN EACH SECTION");
                            CreditCardNumberValidOrNot = false;
                            return null;
                        }

                    }

                    int[] SplitCreditCardNumber = new int[4];

                    for (int i = 0; i < 4; i++)
                    {
                        try
                        {
                            SplitCreditCardNumber[i] = int.Parse(splitcreditcard[i]);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You have entered an unvalid character, please enter NUMBERS");
                            CreditCardNumberValidOrNot = false;
                            return null;
                        }

                    }

                    foreach (int a in SplitCreditCardNumber)
                    {

                        if (a < 0000 || a > 9999)
                        {
                            Console.WriteLine("You have entered an unvalid character, please enter NUMBERS");
                            CreditCardNumberValidOrNot = false;
                            return null;
                        }

                    }
                }

            }

            if (CreditCardNumberValidOrNot)
            {
                CreditCardNumber NewCreditCardNumber = new CreditCardNumber();
                NewCreditCardNumber.InputCreditCardNumber = creditcardnumber;

                return NewCreditCardNumber;

            }
            else
            {
                return null;
            }

        }

        //Test method for correct Credit Card Number

        public static void TestCreditCardNumberCreationWithCorrectInput()
        {
            CreditCardNumber MyCreditCardNumber = new CreditCardNumber();
            MyCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("5555 5555 5555 5555");
            Debug.Assert(MyCreditCardNumber.InputCreditCardNumber == "5555 5555 5555 5555");
            MyCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("1234 5678 9123 0978");
            Debug.Assert(MyCreditCardNumber.InputCreditCardNumber == "1234 5678 9123 0978");
            Console.WriteLine("All CreditCard Number Tests passed!");
        }

        //Test method for incorrect Expiration Dateinput

        public static void TestCreditCardNumberCreationWithIncorrectInput()
        {
            CreditCardNumber MyIncorrectCreditCardNumber = new CreditCardNumber();
            MyIncorrectCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("444444444 55557777 55559999 55550000");
            Debug.Assert(MyIncorrectCreditCardNumber == null);
            MyIncorrectCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("#$** (((? }}}} ||||");
            Debug.Assert(MyIncorrectCreditCardNumber == null);
            MyIncorrectCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("12345678991900000");
            Debug.Assert(MyIncorrectCreditCardNumber == null);
            MyIncorrectCreditCardNumber = CreditCardNumber.CreateCreditCardNumber("33 44 55 66");
            Debug.Assert(MyIncorrectCreditCardNumber == null);
            Console.WriteLine("All CreditCard Number Tests passed!");

        }


    }

    //Credit Card Expiration Date Class

    class ExpirationDate
    {
        public int Month { get; set; }
        public int Day { get; set; }

        //Create Method for Expiration Date (I made string parameters becuase that is the most likely user input format)

        public static ExpirationDate CreateExpirationDate(string MonthAndDay)
        {
            bool ExpirationDateValidOrNot = true;

            if(MonthAndDay.Contains("/") == false)
            {
                Console.WriteLine("Remember to input your date with a '/' character");
                ExpirationDateValidOrNot = false;
                return null;

            }

            string[] MonthAndDayStringArray = MonthAndDay.Split("/");
            int[] MonthAndDayIntArray = new int[2];

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    MonthAndDayIntArray[i] = int.Parse(MonthAndDayStringArray[i]);
                }

            }
            catch(Exception)
            {
                Console.WriteLine("string was not in the right format");
                ExpirationDateValidOrNot = false;
                return null;

            }

            int month = MonthAndDayIntArray[0];
            int day = MonthAndDayIntArray[1];

            if (month >= 1 && month <= 12)
            {
                ExpirationDateValidOrNot = true;
            }
            else
            {
                ExpirationDateValidOrNot = false;
            }

            if (day >= 1 && day <= 31)
            {
                ExpirationDateValidOrNot = true;
            }
            else
            {
                ExpirationDateValidOrNot = false;
            }

            if (ExpirationDateValidOrNot)
            {
                ExpirationDate expirationDate = new ExpirationDate();
                expirationDate.Month = month;
                expirationDate.Day = day;

                return expirationDate;
            }
            else
            {
                return null;
            }

        }

        //Test method for correct Expiration Date input

        public static void TestExpDateCreationWithCorrectInput()
        {
            ExpirationDate MyExpDate = new ExpirationDate();
            MyExpDate = ExpirationDate.CreateExpirationDate("3/27");
            Debug.Assert(MyExpDate.Month == 3);
            Debug.Assert(MyExpDate.Day == 27);
            MyExpDate = ExpirationDate.CreateExpirationDate("8/14");
            Debug.Assert(MyExpDate.Month == 8);
            Debug.Assert(MyExpDate.Day == 14);
            Console.WriteLine("All Exp. Dates Tests passed!");
        }

        //Test method for incorrect Expiration Dateinput

        public static void TestExpDateCreationWithIncorrectInput()
        {
            ExpirationDate MyIncorrectExpDate = new ExpirationDate();
            MyIncorrectExpDate = ExpirationDate.CreateExpirationDate("65/day");
            Debug.Assert(MyIncorrectExpDate == null);
            MyIncorrectExpDate = ExpirationDate.CreateExpirationDate("@/123456");
            Debug.Assert(MyIncorrectExpDate == null);
            Console.WriteLine("All Exp. Dates Tests passed!");
        }




    }

    //Credit Card CVV Class

    class CVVCode
    {
        public string CreditCardCVV { get; set; }

        //Create method for CVVCode

        public static CVVCode CreateCVVCode(string code)
        {
            bool CodeValidOrNot = true;
            int NumbersInCode = 0;

            foreach (char a in code)
            {
                NumbersInCode += 1;

                if (a < '0' || a > '9')
                {
                    CodeValidOrNot = false;
                }
            }

            if (CodeValidOrNot && NumbersInCode == 3)
            {
                CVVCode NewCode = new CVVCode();

                NewCode.CreditCardCVV = code;

                return NewCode;

            }
            else
            {
                return null;

            }

        }

        //Test method for correct CVV input

        public static void TestCCVCodeCreationWithCorrectInput()
        {
            CVVCode MyCode = new CVVCode();
            MyCode = CVVCode.CreateCVVCode("003");
            Debug.Assert(MyCode.CreditCardCVV == "003");
            MyCode = CVVCode.CreateCVVCode("569");
            Debug.Assert(MyCode.CreditCardCVV == "569");
            Console.WriteLine("All CVV tests passed!");

        }

        //Test method for incorrect CVV input

        public static void TestCCVCodeCreationWithIncorrectInput()
        {
            CVVCode MyIncorrectCode = new CVVCode();
            MyIncorrectCode = CVVCode.CreateCVVCode("@00");
            Debug.Assert(MyIncorrectCode == null);
            MyIncorrectCode = CVVCode.CreateCVVCode("3333333");
            Debug.Assert(MyIncorrectCode == null);
            Console.WriteLine("All CVV tests passed!");
        }

    }

}


