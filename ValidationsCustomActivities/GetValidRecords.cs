//-----------------------------------------------------------------------
// <copyright file="GetValidRecords.cs" company="k0d3r">
//     Copyright (c) k0d3r. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ValidationsCustomActivities
{
    using System.Activities;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// The GetValidRecords class
    /// </summary>
    public class GetValidRecords : CodeActivity
    {
        /// <summary>
        /// The RequiredFields
        /// Provide required fields semicolan separated
        /// </summary>
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> RequiredFields { get; set; }

        /// <summary>
        /// The ValidationData
        /// Input DataTable with filled records
        /// </summary>
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> ValidationData { get; set; }

        /// <summary>
        /// The ValidDataTable
        /// returns datatable with valid records
        /// </summary>
        [Category("Output")]
        public OutArgument<DataTable> ValidDataTable { get; set; }

        /// <summary>
        /// The Execute
        /// Which is responsible for returning only valid records from given datatable
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            var fieldList = RequiredFields.Get(context);
            var dataTale = ValidationData.Get(context);

            var result = ValidaterUtility.GetValidDataTableRows(dataTale, fieldList.Split(';').ToList());

            ValidDataTable.Set(context, result);
        }
    }
}
