namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public BankAccount()
        {
            this.Id = id;
            this.Balance = balance;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

    }
}