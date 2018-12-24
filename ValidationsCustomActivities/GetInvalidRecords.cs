//-----------------------------------------------------------------------
// <copyright file="GetInvalidRecords.cs" company="k0d3r">
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
    /// The GetInvalidRecords class
    /// </summary>
    public class GetInvalidRecords : CodeActivity
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
        /// The InvalidItemsDataTable
        /// returns datatable with invalid records
        /// </summary>
        [Category("Output")]
        public OutArgument<DataTable> InvalidItemsDataTable { get; set; }

        /// <summary>
        /// The Execute
        /// Which is responsible for returning only invalid records from given datatable
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            var fieldList = RequiredFields.Get(context);
            var dataTale = ValidationData.Get(context);

            var result = ValidaterUtility.GetInValidDataTableRows(dataTale, fieldList.Split(';').ToList());

            InvalidItemsDataTable.Set(context, result);
        }
    }
}
