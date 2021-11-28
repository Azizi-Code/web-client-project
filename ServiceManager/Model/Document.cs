using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ServiceManager.Model
{
    public class Document
    {
        public string VillageCode { get; set; }
        public int? ParentDocId { get; set; }
        public string FinancialYear { get; set; }
        public DateTime DocDate { get; set; }
        public string Description { get; set; }
        public List<DocumentDetails> DocDetails { get; set; }

    }

}
