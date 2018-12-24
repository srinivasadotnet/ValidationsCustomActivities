//-----------------------------------------------------------------------
// <copyright file="ValidaterHelper.cs" company="k0d3r">
//     Copyright (c) k0d3r. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ValidationsCustomActivities
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// The ValidaterHelper class
    /// Responsible for validating the data
    /// </summary>
    public static class ValidaterUtility
    {
        /// <summary>
        /// The IsValidDataTable
        /// Validates given DataTable against given required fields and returns result
        /// </summary>
        /// <param name="dataTable">input dataTable with minimum 1 record</param>
        /// <param name="fieldList">input fieldList with minimum 1 field name</param>
        /// <param name="message">output message may contains error message success message</param>
        /// <returns>returns whether given DataTable is valid or not</returns>
        public static bool IsValidDataTable(DataTable dataTable, List<string> fieldList, out string message)
        {

            if (dataTable.Rows.Count <= 0 || fieldList.Count <= 0)
            {
                message = "Required fields are missing";
                return false;
            }

            var invalidColumns = fieldList.Where(field => !dataTable.Columns.Contains(field));
            if (invalidColumns.Any())
            {
                message = $"'{string.Join(",", invalidColumns.ToList())}' columns not found in the DataTable";
                return false;
            }

            string resultMessage = string.Empty;
            List<string> invalidFields = new List<string>();
            foreach (var field in fieldList)
            {
                var invalidDataRows = dataTable.AsEnumerable().Where(row => string.IsNullOrWhiteSpace(row[field].ToString()));
                if (invalidDataRows.Any())
                {
                    invalidFields.Add($"({field} : {invalidDataRows.Count()} Rows Invalid)");
                }
            }

            message = invalidFields.Any() ? $"'{string.Join(";", invalidFields)}' {(invalidFields.Count > 1 ? "fields" : "field")} contains Invalid data" : "Valid Data";
            return true;
        }

        /// <summary>
        /// The GetValidDataTableRows
        /// Responsbile for removing all invalid records and returning valid records back
        /// </summary>
        /// <param name="dataTable">input dataTable with minimum 1 valid/invalid rows</param>
        /// <param name="fieldList">input fieldList with minimum 1 valid column</param>
        /// <returns>returns all valid rows</returns>
        public static DataTable GetValidDataTableRows(DataTable dataTable, List<string> fieldList)
        {
            if (dataTable.Rows.Count <= 0 || fieldList.Count <= 0)
            {
                return new DataTable();
            }

            var invalidColumns = fieldList.Where(field => !dataTable.Columns.Contains(field));
            if (invalidColumns.Any())
            {
                return new DataTable();
            }

            foreach (var field in fieldList)
            {
                dataTable = dataTable.AsEnumerable().Where(row => !string.IsNullOrWhiteSpace(row[field].ToString())).CopyToDataTable();
            }

            return dataTable;
        }

        /// <summary>
        /// The GetInValidDataTableRows
        /// Responsible for collecting invalid rows from given datatable
        /// This may help you to report invalid records to customer 
        /// </summary>
        /// <param name="dataTable">input dataTable with minimum 1 valid/invalid rows</param>
        /// <param name="fieldList">input fieldList with minimum 1 valid column name</param>
        /// <returns>returns only invalid rows as a DataTable</returns>
        public static DataTable GetInValidDataTableRows(DataTable dataTable, List<string> fieldList)
        {
            if (dataTable.Rows.Count <= 0 || fieldList.Count <= 0)
            {
                return new DataTable();
            }

            var invalidColumns = fieldList.Where(field => !dataTable.Columns.Contains(field));
            if (invalidColumns.Any())
            {
                return new DataTable();
            }

            var invalidData = dataTable.Clone();

            List<DataRow> invalidDataItems = new List<DataRow>();
            foreach (var field in fieldList)
            {
                var invalidItems = dataTable.AsEnumerable().Where(row => string.IsNullOrWhiteSpace(row[field].ToString()));
                invalidDataItems.AddRange(invalidItems);
            }

            invalidData = invalidDataItems.Distinct().CopyToDataTable();

            return invalidData;
        }
    }
}
