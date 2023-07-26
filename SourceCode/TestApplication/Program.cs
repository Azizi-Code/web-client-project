using WebClientProject.Model;
using System;
using System.Collections.Generic;
using WebClientProject;

namespace TestApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            var webClientService = new WebClientService();
            //login
            var loginResult = webClientService.Login(new Login
            {
                UserName = "UserName",
                Password = "Password"
            });
            var token = loginResult.Data; //loginResult.Data is token

            //send a document
            webClientService.SendDocument(new Document
            {
                Description = "Description",
                DocumentDate = DateTime.Now,
                DocumentDetails = new List<DocumentDetails>
                {
                    new()
                    {
                        Creditor = 1,
                        Debtor = 2,
                        Description = "Description",
                        HeadLineCode = 3
                    }
                },
                FinancialYear = "FinancialYear",
                ParentDocumentId = 1,
                Code = string.Empty
            }, token);

            //delete a document
            webClientService.DeleteDocument("DocumentId", token);
        }
    }
}