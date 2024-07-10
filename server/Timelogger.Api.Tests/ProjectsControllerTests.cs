using NUnit.Framework;
using Moq;
using Timelogger.Api.Controllers;
using Timelogger.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;
using System.Collections.Generic;

namespace Timelogger.Api.Tests
{
    [TestFixture]
    public class ProjectsControllerTests
    {
        private Mock<IProjectService> _mockProjectService;
        private ProjectsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockProjectService = new Mock<IProjectService>();
            _controller = new ProjectsController(_mockProjectService.Object);
        }

        [Test]
        public async Task GetProjects_ReturnsOkObjectResult_WithAListOfProjects()
        {
            // Arrange
            var mockProjects = new List<ProjectDTO>
            {
                new ProjectDTO { Id = 1, Name = "Project 1" },
                new ProjectDTO { Id = 2, Name = "Project 2" }
            };
            _mockProjectService.Setup(service => service.GetProjectsAsync()).ReturnsAsync(mockProjects);

            // Act
            var result = await _controller.GetProjects();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(mockProjects, okResult.Value);
        }

        [Test]
        public async Task GetProjectById_ReturnsNotFound_WhenProjectDoesNotExist()
        {
            // Arrange
            _mockProjectService.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync((ProjectDTO)null);

            // Act
            var result = await _controller.GetProjectById(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetProjectById_ReturnsOkObjectResult_WithProject()
        {
            // Arrange
            var project = new ProjectDTO { Id = 1, Name = "Project A" };
            _mockProjectService.Setup(x => x.GetProjectByIdAsync(1)).ReturnsAsync(project);

            // Act
            var result = await _controller.GetProjectById(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(project, okResult.Value);
        }


        [Test]
        public async Task AddProject_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newProject = new ProjectDTO { Id = 3, Name = "New Project" };
            _mockProjectService.Setup(x => x.AddProjectAsync(newProject)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddProject(newProject);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }

    }
}