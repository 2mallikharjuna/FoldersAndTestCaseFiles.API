
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FoldersAndTestCases.API.UnitTests.DbContextMocker;
using FoldersAndTestCases.API.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FoldersAndTestCases.API.Mapping;
using FoldersAndTestCases.API.Persistence.Repositories;
using FoldersAndTestCases.API.Resources;
using FoldersAndTestCases.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoldersAndTestCases.API.UnitTests.Controllers
{
    public class TestCaseFilesControllerUnitTest
    {
        [Fact]
        public async Task TestAddTestCaseFilesAsync()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestAddTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
            
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

           var testModel = new SaveTestCaseResource()
            {
                Name = "Mad Max: Fury Road.MP4",
                Type = 1,
                StepCount = 2,
                FolderId = 100,
            };
            // Act
            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);
            var response = await controller.AddTestCaserAsync(testModel) as ObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            var rModel = response.Value as TestCaseResource;
            
            Assert.NotNull(rModel);
            Assert.Equal(testModel.Name, rModel.Name);
            Assert.Equal(testModel.Type, rModel.Type);
            Assert.Equal(testModel.StepCount, rModel.StepCount);
            Assert.Equal(testModel.FolderId, rModel.FolderId);

        }
        [Fact]
        public async Task TestAddTestCaseFilesAsync_InvalidType()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestAddTestCaseFilesAsync_InvalidType));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
           
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var testModel = new SaveTestCaseResource()
            {
                Name = "Mad Max: Fury Road",
                Type = 10, //Type doesn't exist
                StepCount = 2,
                FolderId = 100,
            };
            // Act
            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);
            var response = await controller.AddTestCaserAsync(testModel) as ObjectResult;
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
            var rModel = response.Value as TestCaseResource;

            Assert.Null(rModel);
           

        }

        [Fact]
        public async Task TestListTestCaseFilesAsync_Null()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestListTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
            
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            // Act
            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);
            var response = await controller.ListAsync(null) as IEnumerable<TestCaseResource>;
            dbContext.Dispose();
            
            //Assert
            Assert.NotNull(response);
            Assert.Single(response);
        }

        [Fact]
        public async Task TestListTestCaseFilesAsync()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestListTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            // Act
            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(),null);

            
            var response = await controller.ListAsync(101) as IEnumerable<TestCaseResource>;
            dbContext.Dispose();
           
            // Assert
            Assert.NotNull(response);
            Assert.Single(response);
        }
        [Fact]
        public async Task TestListTestCaseFilesAsync_NotFound()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestListTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            // Act
            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);

            
            var response = await controller.ListAsync(100) as IEnumerable<TestCaseResource>;
            dbContext.Dispose();

            Assert.NotNull(response);
            Assert.Empty(response);
        }

        [Fact]
        public async Task TestDeleteTestCaseFilesAsync_NotFound()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestListTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);

            
            var response = await controller.DeleteTestCaseFileAsync(100) as ObjectResult;
            dbContext.Dispose();
            
            // Assert
            Assert.Null(response);
        }
        [Fact]
        public async Task TestDeleteTestCaseFilesAsync_Valid()
        {
            // Arrange
            var dbContext = AppDBContextMocker.GetAppDbContext(nameof(TestListTestCaseFilesAsync));
            var tcService = new TestCaseService(new TestCaseRepository(dbContext), new UnitOfWork(dbContext), null);
            

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ResourceToModelProfile());
                cfg.AddProfile(new ModelToResourceProfile());
            });

            var controller = new TestCaseFilesController(tcService, mockMapper.CreateMapper(), null);

            // Act
            var response = await controller.DeleteTestCaseFileAsync(101) as ObjectResult;
            dbContext.Dispose();
            
            // Assert
            Assert.NotNull(response);

            var deletedModel = response.Value as TestCaseResource;
            
            Assert.NotNull(deletedModel);
            Assert.Equal("Email.txt", deletedModel.Name);
            Assert.Equal(3, deletedModel.Type);
            Assert.Equal(2, deletedModel.StepCount);
            Assert.Null(deletedModel.FolderId);
        }
    }
}
