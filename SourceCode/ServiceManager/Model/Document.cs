using System;
using System.Collections.Generic;

namespace WebClientProject.Model
{
    public class Document
    {
        public string Code { get; set; }
        public int? ParentDocumentId { get; set; }
        public string FinancialYear { get; set; }
        public DateTime DocumentDate { get; set; }
        public string Description { get; set; }
        public List<DocumentDetails> DocumentDetails { get; set; }
    }
}