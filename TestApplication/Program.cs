using ServiceManager;
using ServiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            MyServiceManager sm = new MyServiceManager();
            //login
            var loginResult = sm.Login(new Login
            {
                UserName = "test",
                Password = "123"
            });
            //send document
            sm.SendDocument(new Document
            {
                Description = "",
                DocDate = DateTime.Now,
                DocDetails = new List<DocumentDetails>{new DocumentDetails
                {
                    Creditor=12,
                    Debtor=12,
                    Description="",
                    HeadLineCode=12
                }},
                FinancialYear = "",
                ParentDocId = 13,
                VillageCode = ""
            },loginResult.Data);//loginResult.Data is token
            //delete document
            sm.DeleteDocument("document id", loginResult.Data);
        }
    }
}
