using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_Entities
{
    /// <summary>
    /// To create the INVOICE APPLICATION Entity
    /// Author:158162_Kingston Daniel
    /// DOC:12th Sep 2018
    /// </summary>
    
    [Serializable]
    public class Invoice
    {
        public int InvoiceNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }

        public double Amount { get; set; }

    }
}
