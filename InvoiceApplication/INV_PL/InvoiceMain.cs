using System;
using INV_Entities;
using INV_Exceptions;
using INV_BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace INV_PL
{

    /// <summary>
    /// Console Application to Manage the Invoice Application
    /// Author:158162_Kingston Daniel
    /// DOC:12th Sep 2018
    /// </summary>


    class InvoiceMain
    {
        static InvoiceBLL objValidation;

        public static void AddInvoicePL()
        {
            try
            {
                objValidation = new InvoiceBLL();
                Invoice objInvoice = new Invoice();

                Console.WriteLine("Enter Invoice No :");
                objInvoice.InvoiceNo = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Invoice Date :");
                objInvoice.InvoiceDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Customer Name :");
                objInvoice.CustomerName = Console.ReadLine();

                Console.WriteLine("Enter Product Name :");
                objInvoice.ProductName = Console.ReadLine();

                Console.WriteLine("Enter Amount :");
                objInvoice.Amount = Int32.Parse(Console.ReadLine());

                objValidation.ValidateInvoice(objInvoice); 


                if (objValidation.AddInvoiceBLL(objInvoice))
                    Console.WriteLine("Invoice Record added successfully");


            }
            catch (InvoiceException i)
            {
                Console.WriteLine("Error occurred " + i.Message);
            }
        }

        public static void DisplayInvoicePL()
        {
            try
            {
                objValidation = new InvoiceBLL();
                INV_BLL.InvoiceBLL bllobj = new InvoiceBLL();
                List<Invoice> iList = new List<Invoice>();

                iList = bllobj.DisplayInvoiceBLL();
                Console.WriteLine("Invoice Details");
                Console.WriteLine("=================");

                foreach (Invoice i in iList)
                {
                    Console.WriteLine("Invoice No :{0}\n Invoice Date :{1} \n Customer Name :{2}  \n Product Name : {3} \n Amount : {4}", i.InvoiceNo, i.InvoiceDate, i.CustomerName, i.ProductName, i.Amount);
                }
            }
            catch (InvoiceException i)
            {
                Console.WriteLine(i.Message);
            }
        }


        public static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("************INVOICE APPLICATION*************");
            Console.WriteLine("1.  To Add Invoice Details  - Press 1,");
            Console.WriteLine("2.  To Display All Invoices - Press 2,");
            Console.WriteLine("3.  To Delete an Invoice    - Press 3,");
            Console.WriteLine("4.  To Serialize Data       - Press 4,");
            Console.WriteLine("5.  To Deserialize Data     - Press 5,");
            Console.WriteLine("6.  To Exit the Application - Press 6,");
            Console.WriteLine("*********************************************");
        }

       public static void Main(string[] args)
        {
            int userchoice;
            bool chkchoice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter Your Choice from the Menu");
                chkchoice = Int32.TryParse(Console.ReadLine(), out userchoice);
                if (!chkchoice)
                    Console.WriteLine("Enter a Valid Choice from the Menu");
                else
                    switch (userchoice)
                    {
                        case 1:
                            AddInvoicePL();
                            break;
                        case 2:
                            DisplayInvoicePL();
                            break;
                        case 3:
                            DeleteInvoice();
                            break;
                        case 4:
                            SerializeInvoice();
                            break;
                        case 5:
                            DeserializeInvoice();
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
            } while (userchoice != 8);

            Console.ReadKey();
        }


        private static void DeleteInvoice()
        {
            objValidation = new InvoiceBLL();
            try
            {
                Console.WriteLine("Enter Invoice No to be deleted:");
                int empId = Int32.Parse(Console.ReadLine());

                bool isDeleted = objValidation.DeleteInvoiceBLL(empId);
                if (isDeleted) Console.WriteLine("Record Deleted!! ");
            }
            catch (InvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void SerializeInvoice()
        {
            try
            {
                objValidation = new InvoiceBLL();
                objValidation.SerializeInvoiceBLL(); //Call the function
                Console.WriteLine("Invoice Record stored in File");
            }
            catch (InvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeserializeInvoice()
        {
            List<Invoice> iList = objValidation.DeserializeInvoiceBLL();
            objValidation = new InvoiceBLL();
            try
            {
                Console.WriteLine("Records from File:");
                foreach (Invoice inv in iList)
                {
                    Console.WriteLine("Invoice No: {0}", inv.InvoiceNo);
                    Console.WriteLine("Invoice Date: {0}", inv.InvoiceDate);
                    Console.WriteLine("Customer Name: {0}", inv.CustomerName);
                    Console.WriteLine("Product Name : {0}", inv.ProductName);
                    Console.WriteLine("Amount : {0}", inv.Amount);
                }
            }
            catch (InvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
