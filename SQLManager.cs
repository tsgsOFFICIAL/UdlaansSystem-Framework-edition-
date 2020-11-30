﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdlaansSystem
{
    class SQLManager
    {
        #region EXPORT

        #region CREATING NEW LOANS AND LOANERS

        public static void CreateLoaner(string uniLogin, string name, string phone, int isStudent)
        {
            ObjectLoaner addLoaner = new ObjectLoaner(uniLogin, name, phone, isStudent);
            ExportSQLConnections.CreateLoaner(addLoaner.UNILogin, addLoaner.Name, addLoaner.Phone, addLoaner.IsStudent);
        }

        public static void CreateLoan(string uniLogin, string qrId, DateTime startDate, DateTime endDate)
        {
            ObjectLoan addLoan = new ObjectLoan(uniLogin, qrId, startDate, endDate);
            ExportSQLConnections.CreateLoan(addLoan.UNILogin, addLoan.QRID, addLoan.StartDate, addLoan.EndDate);
        }

        #endregion

        #region CHECKING FOR EXISTING DATA

        public static bool CheckUniLogin(string uniLogin)
        {
            bool uniLoginExists = ExportSQLConnections.CheckDatabaseForLogin(uniLogin);
            return uniLoginExists;
        }

        public static bool CheckLoanTableForQRID(string qrId)
        {
            bool pcInStock = ExportSQLConnections.CheckLoanTableForQR(qrId);

            return pcInStock;
        }

        public static bool CheckPCTableForQRID(string qrId)
        {
            bool pcInStock = ExportSQLConnections.CheckPCTableForQR(qrId); 

            return pcInStock;
        }

        public static string GetActiveStudentLoanInfo(string uniLogin)
        {
            string activeLoanInfo = ExportSQLConnections.GetLoanInfo(uniLogin);

            return activeLoanInfo;
        }

        #endregion

        #region NEEDS SOME WORK
        public static string GetActivePCNotInStockInfo(string qrId)
        {
            string pcNotInStockInfo = ExportSQLConnections.GetPCNotInStockInfo(qrId);

            if (pcNotInStockInfo == "")// DEN HER OVER I EN SØGNING GENNEM PC TABLE
            {
                pcNotInStockInfo = "PC'en er ikke registreret i databasen!"; // HER TJEK PC TABLE EFTER PC
            }

            return pcNotInStockInfo;
        }

        #endregion

        #endregion

        #region IMPORT
        public static void DeleteLoanAndLoaner(string qrId)
        {
            string tempUniLogin = ImportSQLConnection.GetUniLoginFromLoan(qrId);
            ImportSQLConnection.RemoveLoanFromDatabase(qrId);
            ImportSQLConnection.RemoveTest(tempUniLogin);
        }
        #endregion

        #region REGISTER

        public static void RegisterPC(string qrID, string serialNumber, string pcModel)
        {
            ObjectPC addPC = new ObjectPC(qrID, serialNumber, pcModel);

            RegisterSQLConnections.CreatePC(addPC.QRID, addPC.SerialNumber, addPC.PCModel);
        }

        public static bool CheckQR(string qrId)
        {
            bool qrIdExists = RegisterSQLConnections.CheckDatabaseForQR(qrId);
            return qrIdExists;
        }

        public static string GetRegisteredPCInfo(string qrId)
        {
            string registeredPCInfo = RegisterSQLConnections.GetPCInfo(qrId);

            return registeredPCInfo;
        }

        #endregion
    }
}
