﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdlaansSystem
{
    class SQLManager
    { 
        // Lav noget der henter værdier fra XAML pages, eller gør det som i landlyst
        //public static string qrID;
        //public static string serialNumber;
        //public static string pcModel;
        //public static bool inStock;

        public static void RegisterPC(string qrID, string serialNumber, string pcModel)
        {
            ObjectPC addPC = new ObjectPC(qrID, serialNumber, pcModel);

            RegisterSQLConnections.CreatePC(addPC.QRID, addPC.SerialNumber, addPC.PCModel);
        }

        public static DateTime startDate;
        public static DateTime endDate;

        public static void ExportToLoaner(string uniLogin, string name, string phone, int isStudent)
        {
            ObjectLoaner addLoaner = new ObjectLoaner(uniLogin, name, phone, isStudent);
            ExportSQLConnections.CreateLoaner(addLoaner.UNILogin, addLoaner.Name, addLoaner.Phone, addLoaner.IsStudent);

            //ObjectLoan addLoan = new ObjectLoan(startDate, endDate);
            //ExportSQLConnections.CreateLoan(addLoan.StartDate, addLoan.EndDate);
        }
    }
}
