using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FoldersAndTestCases.API.Domain.Models
{
    public enum TestCaseType : int
    {
        [Description("VoiceTestCase")]
        Voice = 1,
        [Description("SMSTestCase")]
        SMS = 2,
        [Description("EMailTestCase")]
        Email = 3,
        [Description("APITestCase")]
        API = 4,
        [Description("ExternalTestCase")]
        External = 5
    }
    public class TestCaseFile
    {
        public int TestcaseId { get; set; }
        public string Name { get; set; }
        //public int Type { get; set; }

        public int StepCount { get; set; }
        public int? FolderId { get; set; }

        [ForeignKey("FolderId")]
        public virtual Folder Folder { get; set; }
      
        public TestCaseType Type { get; set; }
    }
}
