using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersAndTestCases.API.Domain.Models
{
    public class Folder
    {
        public int FolderID { get; set; }
        public int? ParentFolderId { get; set; }

        [ForeignKey("FolderID")]
        public virtual Folder ParentFolder { get; set; }
        public string Name { get; set; }

        public List<Folder> ChildFolders { get; set; } = new List<Folder>();
        public List<TestCaseFile> TestCases { get; set; } = new List<TestCaseFile>();
    }
}
