namespace TaskManager.Tests;
using Microsoft.AspNetCore.Authentication.OAuth;
using Moq;
using NUnit.Framework;
using TaskManagerProject.Data.Repositories;
using TaskManagerProject.DTOs.ActivityDTO;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

[TestFixture]
public class ActivityServiceTest
{
    private Mock<IRepository<Activity>> _repoMock;
    private ActivityService _service;

    [SetUp]
    public void Setup()
    {
        _repoMock = new Mock<IRepository<Activity>>();
        _service = new ActivityService(_repoMock.Object);
    }

    [Test]
    public void CreateActivityIsCreatingItCorrectly()
    {
        var dto = new ActivityRequestDto
        {
            Title = "Nova Task test mock",
            DueDate = new DateTime(2029,03,20),
            Description = "Descrição",
            CategoryId = "1",
            UserId = "1",
            Status = TaskStatusEnum.Pending
        };

        var service = new ActivityService(_repoMock.Object);

        // Act
        service.CreateActivity(dto);

        // Assert
        _repoMock.Verify(r => r.Create(It.IsAny<Activity>()), Times.Once);
    }
}
