﻿using System;

namespace ASP_LABB4_MVC_RAZOR.Models
{
    public class Loan
    {
        public int LoanId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
    }
}

