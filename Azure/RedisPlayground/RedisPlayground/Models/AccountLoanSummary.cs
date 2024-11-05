using System.Text.Json.Serialization;

namespace RedisPlayground.Models;

public class AccountLoanSummary
{
    public decimal? PrincipalAmount { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? TotalLateFeeAmount { get; set; }
    public decimal? TotalNSFFeeAmount { get; set; }
    public decimal? PerDiem { get; set; }
    public decimal? PayOffAmount { get; set; }
    public decimal? APRRate { get; set; }
    public DateTime? CurrentMaturityDate { get; set; }
    public int? NumberOfPaymentsRemaining { get; set; }
    public decimal? InsuranceAmountDelinquent { get; set; }
    public DateTime? PastDueSinceDate { get; set; }
    public decimal? AmountToRoll { get; set; }
    public int? NumberOfPaymentsMade { get; set; }
    public DateTime? NextPaymentDueDate { get; set; }
    public decimal? PastDueAmount { get; set; }
    public int NumberOfDaysPastDue { get; set; }
    public decimal TotalAmountDue { get; set; }
    public decimal NextAmountDue { get; set; }
    public decimal AmountDueNow { get; set; }
    public DateTime? StatusChangeEffectiveDate { get; set; }
    public int? StatusReasonCode { get; set; }
    public string StatusReasonDescription { get; set; }
    public string ReportLot { get; set; }
    public DateTime? SaleDate { get; set; }
    public decimal? PaymentAmount { get; set; }
    public decimal? OriginalLoanBalance { get; set; }
    public short? TotalNumberOfPayments { get; set; }
    [JsonConverter(typeof(NullConverter))]
    public short? PaymentDueDayOne { get; set; }
    [JsonConverter(typeof(NullConverter))]
    public short? PaymentDueDayTwo { get; set; }
    public DateTime? OriginalMaturityDate { get; set; }
    public string PaymentFrequencyName { get; set; }
    public decimal? OriginalAPR { get; set; }
    public char AccountStatusKey { get; set; }
    public bool IsDisplayReason { get; set; }
    public int CurrentPoolNumber { get; set; }
}
