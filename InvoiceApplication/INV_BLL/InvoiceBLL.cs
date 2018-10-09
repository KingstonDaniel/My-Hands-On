using System;
using INV_Entities;
using INV_Exceptions;
using INV_DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace INV_BLL
{

    /// <summary>
    /// To create the Validation method and to invoke the operations from DAL
    /// Author:158162_Kingston Daniel
    /// DOC:12th Sep 2018
    /// </summary>


    public class InvoiceBLL
    {
        InvoiceDAL operationsObj;
        static List<Invoice> iList = new List<Invoice>();

        public bool ValidateInvoice(Invoice newInvoice)
        {
            bool isValidInvoice = true;
            StringBuilder sbINVError = new StringBuilder();

            if (newInvoice.CustomerName.ToString().Equals(string.Empty))
            {
                isValidInvoice = false;
                sbINVError.Append("Customer Name cannot be blank " + Environment.NewLine);
            }

            if (newInvoice.InvoiceNo.ToString().Length != 6)
            {
                isValidInvoice = false;
                sbINVError.Append("Invoice No has to be 6 digits " + Environment.NewLine);
            }

            if (newInvoice.ProductName.ToString() != "Food Products" & newInvoice.ProductName.ToString() != "Groceries" & newInvoice.ProductName.ToString() != "Electronic Items" & newInvoice.ProductName.ToString() != "Games")
            {
                isValidInvoice = false;
                sbINVError.Append("Product Name should be Food Products,Groceries,Electronic Items,Games" + Environment.NewLine);
            }

            if (newInvoice.InvoiceDate <= DateTime.Now)
            {
                isValidInvoice = false;
                sbINVError.Append("Invoice Date cannot be less than current Date " + Environment.NewLine);
            }

            if (!isValidInvoice)
            {
                throw new InvoiceException(sbINVError.ToString());
            }

            return isValidInvoice;
        }


        public bool AddInvoiceBLL(Invoice invoice)
        {
            InvoiceDAL invoiceOperations = new InvoiceDAL();

            bool isAdded = false;
            try
            {
                isAdded = invoiceOperations.AddInvoiceDAL(invoice);
                if (isAdded == false)
                {
                    throw new InvoiceException("Invoice Details not Added");
                }
            }
            catch (InvoiceException i)
            {
                throw i;
            }

            return isAdded;
        }

        public List<Invoice> DisplayInvoiceBLL()
        {
            InvoiceDAL invoiceOperations = new InvoiceDAL();
            try
            {
                iList = invoiceOperations.DisplayInvoiceDAL();
                if (iList.Count <= 0)
                {
                    throw new InvoiceException("No Records Found!!!");

                }
            }
            catch (InvoiceException i)
            {
                throw i;
            }
            return iList;
        }

        public bool DeleteInvoiceBLL(int InvoiceNo)
        {
            bool isDeleted = false;

            try
            {
                operationsObj = new InvoiceDAL();
                isDeleted = operationsObj.DeleteInvoiceDAL(InvoiceNo);
                if (!isDeleted) throw new InvoiceException("Invoice Could not be deleted");
            }
            catch (InvoiceException ex) { throw ex; }
            return isDeleted;
        }

        public void SerializeInvoiceBLL()
        {
            try
            {
                InvoiceDAL dalobj = new InvoiceDAL();
                dalobj.SerializeInvoice();
            }
            catch (InvoiceException i)
            { throw i; }

            catch (IOException i)
            { throw i; }
        }


        public List<Invoice> DeserializeInvoiceBLL()
        {
            List<Invoice> iList = new List<Invoice>();
            try
            {
                InvoiceDAL dalobj = new InvoiceDAL();

                iList = dalobj.DeserializeInvoice();
                if (iList.Count <= 0) throw new InvoiceException("No Records Found in File");

            }

            catch (InvoiceException i)
            { throw i; }

            catch (IOException i)
            { throw i; }

            return iList;
        }
         
    }
}
