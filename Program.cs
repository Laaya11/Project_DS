namespace Banking
{
    enum BankAccountType { checking, saving }
    class BankAccount
    {
        public string _name;
        public BankAccountType _type;
        public int _credit;

        public int Credit
        {
            get { return _credit; }
            set
            {
                if (value < 0)
                    _credit = 0;
                else
                    _credit = value;
            }
        }
        public BankAccount(string name, BankAccountType type, int credit)
        {
            _name = name;
            _type = type;
            Credit = credit;
        }
        public static BankAccount[] BankAccountsArray(int count)
        {
            BankAccount[] accounts = new BankAccount[count];
            for (int i = 0; i < count; i++)
            {
                string baname; BankAccountType batype; int bacredit;
                Console.WriteLine("Enter a Name = ");
                baname = Console.ReadLine();
                Console.WriteLine("Enter a Type number (1 = checking, 2 = saving) = ");
                batype = (BankAccountType)(Convert.ToInt32(Console.ReadLine())) - 1;
                Console.WriteLine("Enter a Credit = ");
                bacredit = Convert.ToInt32(Console.ReadLine());

                accounts[i] = new BankAccount(baname, batype, bacredit);
            }
            return accounts;
        }
        public string ToString()
        {
            return _name + "\n" + _type + "\n" + Convert.ToString(_credit);
        }
    }
    class Bank
    {
        public string _name;
        public BankAccount[] _accounts;

        public Bank(string name, int count)
        {
            _name = name;
            _accounts = new BankAccount[count];
            _accounts = BankAccount.BankAccountsArray(count);
        }
        public Bank(string name, BankAccount[] accounts)
        {
            _name = name;
            _accounts = accounts;
        }
        public string ToString()
        {
            string s = _name + "\n----------\n";
            for (int i = 0; i < _accounts.Length; i++)
            {
                s += _accounts[i].ToString() + "\n----------\n";
            }
            return s;
        }
        public BankAccount TopCreditBA()
        {
            int max = 0;
            int topcredit = 0;
            int i = 0;
            for (i = 0; i < _accounts.Length; i++)
            {
                if (_accounts[i].Credit > max)
                {
                    max = _accounts[i].Credit;
                    topcredit = i;
                }
            }
            return _accounts[i];
        }
        public int TopCredit()
        {
            int max = 0;
            for (int i = 0; i < _accounts.Length; i++)
            {
                if (_accounts[i].Credit > max)
                    max = _accounts[i].Credit;
            }
            return max;
        }
        public double CreditAvg()
        {
            double sum = 0;
            double avg = 0;
            for (int i = 0; i < _accounts.Length; i++)
                sum += _accounts[i].Credit;
            avg = sum / _accounts.Length;
            return avg;
        }
        public double CreditAvg(BankAccountType type)
        {
            double sum = 0;
            double avg = 0;
            for (int i = 0; i < _accounts.Length; i++)
                if (_accounts[i]._type == type)
                    sum += _accounts[i].Credit;
            avg = sum / _accounts.Length;
            return avg;
        }
    }
    class Program
    {
        static void Main()
        {
            BankAccount[] accounts1 = new BankAccount[2];
            accounts1 = BankAccount.BankAccountsArray(2);
            Bank sepah = new Bank("Sepah", accounts1);
            Console.WriteLine(sepah.ToString());

            Bank melat = new Bank("Melat", 2);
            Console.WriteLine(melat.ToString());

            BankAccount account1 = sepah.TopCreditBA();
            Console.WriteLine(account1.ToString());

            Console.WriteLine(melat.TopCredit());
            Console.WriteLine(melat.CreditAvg());

            BankAccountType type1 = (BankAccountType)1;
            Console.WriteLine(sepah.CreditAvg(type1));

            Console.ReadKey();
        }
    }
}