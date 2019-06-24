using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoldersAndTestCases.API.Resources
{
    public class TestCaseResource
    {
        public int TestcaseId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int StepCount { get; set; }
        public int? FolderId { get; set; }
    }
}
