namespace DesignPatterns.CreationalPatterns.Factory
{
    public class TitaniumCreditCard : CreditCard
    {
        private int _creditLimit;
        private int _annualCharge;

        public TitaniumCreditCard(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType => "Titanium";
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