using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Domain.Repositories
{
    /// <summary>
    /// Holds the history of each flag that has been set on this membership
    /// </summary>
    public interface ITestCaseRepository
    {
        ///<Summary>
        /// Find all the test cases with in folder
        /// <param name="folderId"> An instance of cover details to compare with this ones.</param>
        ///<returns>
        /// A boolean value indicating whether this object is similar to a given one.
        ///</returns>
        ///</Summary>
        Task<IEnumerable<TestCaseFile>> ListAsync(int? folderId);

        ///<Summary>
        /// Find the testcase file by Id
        /// <param name="folderId"> An instance of cover details to compare with this ones.</param>
        ///<returns>
        /// A boolean value indicating whether this object is similar to a given one.
        ///</returns>
        ///</Summary>
        Task<TestCaseFile> FindByIdAsync(int id);
        ///<Summary>
        /// Add the testcase
        /// <param name="testCase"> An instance of cover details to compare with this ones.</param>
        ///<returns>
        /// A boolean value indicating whether this object is similar to a given one.
        ///</returns>
        ///</Summary>
        Task AddAsync(TestCaseFile testCase);

        ///<Summary>
        /// Remove the testcase
        /// <param name="testCase"> An instance of cover details to compare with this ones.</param>
        ///<returns>
        /// A boolean value indicating whether this object is similar to a given one.
        ///</returns> 
        ///</Summary>
        void Remove(TestCaseFile testCase);
    }
}
