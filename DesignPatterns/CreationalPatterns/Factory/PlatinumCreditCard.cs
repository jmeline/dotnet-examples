namespace DesignPatterns.CreationalPatterns.Factory
{
    public class PlatinumCreditCard : CreditCard
    {
        private int _creditLimit;
        private int _annualCharge;

        public PlatinumCreditCard(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType => "Platinum";
        public override int CreditLimit
        {
            get => _creditLimit;
            set => _creditLimit = value;
        }
        public override int AnnualCharge 
        {
            get => _annualCharge;
            set => _annualCharge = value;
        }
    }
}