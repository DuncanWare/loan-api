namespace YouLendApi.Models
{
    public class LoanFile
    {
        public long Id { get; set; }
        public string BorrowerName { get; set; }
        public int RepaymentAmount { get; set; }
        public int FundingAmount { get; set; }
    }
}