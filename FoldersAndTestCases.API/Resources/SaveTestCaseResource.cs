using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FoldersAndTestCases.API.Resources
{
    public class SaveTestCaseResource
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int StepCount { get; set; }
        public int? FolderId { get; set; }
    }
}
