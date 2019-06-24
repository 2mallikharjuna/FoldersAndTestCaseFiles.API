using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersAndTestCases.API.Resources
{
    public class FolderResource
    {
        public int FolderID { get; set; }
        public string Name { get; set; }
        public int? ParentFolderId { get; set; }
    }
}
