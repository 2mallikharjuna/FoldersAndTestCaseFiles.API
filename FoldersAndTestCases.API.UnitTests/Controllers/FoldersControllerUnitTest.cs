using FoldersAndTestCases.API.UnitTests.DbContextMocker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FoldersAndTestCases.API.Controllers;
using FoldersAndTestCases.API.Mapping;
using FoldersAndTestCases.API.Persistence.Repositories;
using FoldersAndTestCases.API.Resources;
using FoldersAndTestCases.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FoldersAndTestCases.API.UnitTests.Controllers
{
    public class FoldersControllerUnitTest
    {
        [Fact]
        public async Task TestAddFolderTaskAsync()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestAddFolderTaskAsync));
            
            var fService = new FolderService(new FolderRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var folderModel = new SaveFolderResource()
            {
                Name = "NullParentFolder",
                ParentFolderId = null,
            };
            // Act
            var controller = new FoldersController(fService, mockMapper.CreateMapper(), null);
            var response = await controller.AddFolderAsync(folderModel) as ObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            var folderResponce = response.Value as FolderResource;
            Assert.NotNull(folderResponce);
            Assert.NotNull(folderResponce.FolderID);
            Assert.Equal(folderResponce.Name, folderModel.Name);
            Assert.Null(folderModel.ParentFolderId);

        }
        [Fact]
        public async Task TestAddFolderTaskAsync_InvalidParentFolder()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestAddFolderTaskAsync_InvalidParentFolder));
            var fService = new FolderService(new FolderRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var folderModel = new SaveFolderResource()
            {
                Name = "NoParentFolder",
                ParentFolderId = 200,
            };
            // Act
            var controller = new FoldersController(fService, mockMapper.CreateMapper(), null);
            var response = await controller.AddFolderAsync(folderModel) as ObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            var folderResponce = response.Value as FolderResource;
            Assert.Null(folderResponce);
        }
        [Fact]
        public async Task TestAddFolderTaskAsync_validParentFolder()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestAddFolderTaskAsync_validParentFolder));
            var fService = new FolderService(new FolderRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var folderModel = new SaveFolderResource()
            {
                Name = "validParentFolder",
                ParentFolderId = 104,
            };
            // Act
            var controller = new FoldersController(fService, mockMapper.CreateMapper(), null);
            var response = await controller.AddFolderAsync(folderModel) as ObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            var folderResponce = response.Value as FolderResource;
            Assert.NotNull(folderResponce);
            Assert.NotNull(folderResponce.FolderID);
            Assert.Equal(folderResponce.Name, folderModel.Name);
            Assert.Null(folderModel.ParentFolderId);

        }


    }
}
