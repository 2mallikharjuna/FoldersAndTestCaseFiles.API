using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Domain.Services.Communication
{
    public class FolderResponse : BaseResponse
    {
        public Folder Folder { get; private set; }

        private FolderResponse(bool success, string message, Folder folder) : base(success, message)
        {
            Folder = folder;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="folder">Saved category.</param>
        /// <returns>Response.</returns>
        public FolderResponse(Folder folder) : this(true, string.Empty, folder)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public FolderResponse(string message) : this(false, message, null)
        { }
    }
}
