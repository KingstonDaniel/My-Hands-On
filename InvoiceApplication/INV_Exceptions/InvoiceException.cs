using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_Exceptions
{

    /// <summary>
    /// Exception Class to catch the Exceptions occuring in Invoice Application
    /// Author:158162_Kingston Daniel
    /// DOC:12th Sep 2018
    /// </summary>
    
    public class InvoiceException : ApplicationException
    {
        public InvoiceException() : base() { }

        public InvoiceException(string ErrorMessage) : base(ErrorMessage) { }



    }
}
