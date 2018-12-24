//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="k0d3r">
//     Copyright (c) k0d3r. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using ValidationsCustomActivities;

    /// <summary>
    /// The Program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// The Main function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var message = string.Empty;

            // Validate whether given DataTable contains valid data or not.
            var result = ValidaterUtility.IsValidDataTable(GetData, new List<string> { "ID", "Age" }, out message);
            Console.WriteLine($"IsValid : {result}, Message : {message}");

            // Collect only valid records from given DataTable
            var resultRows = ValidaterUtility.GetValidDataTableRows(GetData, new List<string> { "ID", "Age" });
            Console.WriteLine($"Total Rows {GetData.Rows.Count}, Valid Rows : {resultRows.Rows.Count}");

            // Collect only invalid records from given DataTable this may help you report invalid records to customer
            var inValidResultRows = ValidaterUtility.GetInValidDataTableRows(GetData, new List<string> { "ID", "Age" });
            Console.WriteLine($"Total Rows {GetData.Rows.Count}, Invalid Rows : {inValidResultRows.Rows.Count}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Gets sample data from GetData
        /// </summary>
        private static DataTable GetData
        {
            get
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID", typeof(Int32));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Salary", typeof(double));
                dataTable.Columns.Add("Age", typeof(Int32));

                DataRow dr = dataTable.NewRow();
                dr["ID"] = 1;
                dr["Name"] = "Srinivas";
                dr["Salary"] = 100.50;
                dr["Age"] = 25;
                dataTable.Rows.Add(dr);

                DataRow dr1 = dataTable.NewRow();
                dr1["ID"] = 2;
                dr1["Name"] = "Kumar";
                dr1["Salary"] = 100.50;
                //dr1["Age"] = 26;
                dataTable.Rows.Add(dr1);

                DataRow dr2 = dataTable.NewRow();
                dr2["ID"] = 3;
                dr2["Name"] = "Bin";
                dr2["Salary"] = 200.50;
                dr2["Age"] = 24;
                dataTable.Rows.Add(dr2);

                DataRow dr3 = dataTable.NewRow();
                //dr3["ID"] = 4;
                dr3["Name"] = "Boy";
                dr3["Salary"] = 500.50;
                //dr3["Age"] = 25;
                dataTable.Rows.Add(dr3);

                DataRow dr4 = dataTable.NewRow();
                dr4["ID"] = 5;
                dr4["Name"] = "Hell";
                dr4["Salary"] = 400.50;
                dr4["Age"] = 35;
                dataTable.Rows.Add(dr4);

                return dataTable;
            }
        }
    }
}
