using System.ComponentModel.DataAnnotations;


namespace MundipaggApi.Dto
{
    public class CreateTransactionForm
    {
        [Required]
        public int AmountInCents { get; set; }
        [Required]
        public string CreditCardBrand { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public int ExpMonth { get; set; }
        [Required]
        public int ExpYear { get; set; }
        [Required]
        public int SecurityCode { get; set; }
        [Required]
        public string HolderName { get; set; }
        public int InstallmentCount { get; set; }
    }
}