//-----------------------------------------------------------------------
// <copyright file="DataValidator.cs" company="k0d3r">
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
    /// The IsValidData class
    /// </summary>
    public class IsValidData : CodeActivity
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
        /// The ResultMessage
        /// Result message which may contain error message or success message
        /// </summary>
        [Category("Output")]
        public OutArgument<string> ResultMessage { get; set; }

        /// <summary>
        /// The IsValidData
        /// returns boolean result whether given datatale data is valid or not
        /// </summary>
        [Category("Output")]
        public OutArgument<bool> IsValidDataTable { get; set; }

        /// <summary>
        /// The Execute
        /// Which is responsible for validating the data
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(CodeActivityContext context)
        {
            var fieldList = RequiredFields.Get(context);
            var dataTale = ValidationData.Get(context);
            var resultMessage = string.Empty;

            var result = ValidaterUtility.IsValidDataTable(dataTale, fieldList.Split(';').ToList(), out resultMessage);

            IsValidDataTable.Set(context, result);
            ResultMessage.Set(context, resultMessage);
        }
    }
}
