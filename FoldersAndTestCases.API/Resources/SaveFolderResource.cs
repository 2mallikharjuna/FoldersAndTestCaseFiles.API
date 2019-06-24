using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FoldersAndTestCases.API.Resources
{
    public class SaveFolderResource
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? ParentFolderId { get; set; }
    }
}
