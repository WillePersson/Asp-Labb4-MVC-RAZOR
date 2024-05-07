namespace ASP_LABB4_MVC_RAZOR.Models
{
    public class BookLoanViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
