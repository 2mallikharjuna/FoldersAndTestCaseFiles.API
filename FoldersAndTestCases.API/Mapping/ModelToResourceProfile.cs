using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoldersAndTestCases.API.Domain.Models;
using FoldersAndTestCases.API.Resources;

namespace FoldersAndTestCases.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Folder, FolderResource>();
            CreateMap<TestCaseFile, TestCaseResource>();
        }
    }
}
