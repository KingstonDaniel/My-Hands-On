using System;
using INV_Entities;
using INV_Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace INV_DAL
{

    /// <summary>
    /// To create the methods for performing operations on Invoice Application
    /// Author:158162_Kingston Daniel
    /// DOC:12th Sep 2018
    /// </summary>


    public class InvoiceDAL
    {
        static List<Invoice> invoiceList = new List<Invoice>();

        public bool AddInvoiceDAL(Invoice newInvoice)
        {
            bool isInvoiceAdded = false;

            try
            {
                invoiceList.Add(newInvoice);
                isInvoiceAdded = true;
            }
            catch (InvoiceException)
            {
                throw;
            }
            return isInvoiceAdded;
        }

        public List<Invoice> DisplayInvoiceDAL()
        {
            return invoiceList;
        }

        public bool DeleteInvoiceDAL(int invNo)
        {
            bool isInvDeleted = false;
            Invoice invToDelete = new Invoice();
            try
            {
                invToDelete = invoiceList.Find(inv => inv.InvoiceNo == invNo);
                invoiceList.Remove(invToDelete);
                isInvDeleted = true;
            }
            catch (InvoiceException)
            {
                throw;
            }
            return isInvDeleted;

        }

        public void SerializeInvoice()
        {
            FileStream fs = new FileStream(@"D:\Invoice.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, invoiceList);
            fs.Close();
        }

        public List<Invoice> DeserializeInvoice()
        {
            FileStream fs = new FileStream(@"D:\Invoice.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Invoice> deserializedList = new List<Invoice>();
            deserializedList = (List<Invoice>)formatter.Deserialize(fs);
            return deserializedList;
        }
    }
}
