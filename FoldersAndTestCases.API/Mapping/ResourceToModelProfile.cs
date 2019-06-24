using FoldersAndTestCases.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoldersAndTestCases.API.Domain.Models;

namespace FoldersAndTestCases.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveFolderResource, Folder>();
            CreateMap<SaveTestCaseResource, TestCaseFile>()
                .ForMember(destination => destination.Type,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(TestCaseType), source.Type)));
        }
    }
}
