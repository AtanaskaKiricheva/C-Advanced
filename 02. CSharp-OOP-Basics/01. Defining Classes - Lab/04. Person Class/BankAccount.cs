namespace BankAccount
{
    public class BankAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public decimal Deposit(decimal amount)
        {
            return this.Balance += amount;
        }
        public decimal Withdraw(decimal amount)
        {
            return this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance:f2}";
        }
    }
}