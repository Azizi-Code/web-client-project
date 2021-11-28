using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceManager.Model
{
    public class DocumentDetails
    {
        public int HeadLineCode { get; set; }
        public float Debtor { get; set; }
        public float Creditor { get; set; }
        public string Description { get; set; }
    }
}
