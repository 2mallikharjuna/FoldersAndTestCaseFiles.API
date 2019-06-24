using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Domain.Services.Communication
{
    public class TestCaseResponce : BaseResponse
    {
        public TestCaseFile Folder { get; private set; }

        private TestCaseResponce(bool success, string message, TestCaseFile testCase) : base(success, message)
        {
            Folder = testCase;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public TestCaseResponce(TestCaseFile testCase) : this(true, string.Empty, testCase)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TestCaseResponce(string message) : this(false, message, null)
        { }
    }
}
