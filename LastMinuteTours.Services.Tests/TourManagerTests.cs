using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using LastMinuteTours.Entities;
using LastMinuteTours.Services;
using LastMinuteToursManger.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LastMinuteToursManager.Tests
{
    public class TourManagerTests
    {
        private readonly Mock<ITourService> storageMock;
        private readonly ITourManager manager;
        private readonly CancellationToken token = CancellationToken.None;

        public TourManagerTests()
        {
            var loggerFactory = Mock.Of<ILoggerFactory>(factory => factory.CreateLogger(It.IsAny<string>()) == Mock.Of<ILogger>());
            storageMock = new Mock<ITourService>();
            manager = new TourManager(storageMock.Object, loggerFactory);
        }

        [Fact]
        public async Task GetAllToursAsync_ReturnsValueFromStorage()
        {
            // Arrange
            var expected = new List<TourModel>
            {
                new TourModel { Id = Guid.NewGuid(), Direction = Direction.France }
            };

            storageMock
                .Setup(s => s.GetAllToursAsync(token))
                .ReturnsAsync(expected);

            // Act
            var result = await manager.GetAllToursAsync(token);

            // Assert
            result.Should().BeEquivalentTo(expected);
            storageMock.Verify(s => s.GetAllToursAsync(token), Times.Once);
        }

        [Fact]
        public async Task AddTourAsync_CallsStorageAddOnce()
        {
            var tour = new TourModel { Id = Guid.NewGuid() };

            // Act
            await manager.AddTourAsync(tour, token);

            // Assert
            storageMock.Verify(s => s.AddTourAsync(tour, token), Times.Once);
        }

        [Fact]
        public async Task UpdateTourAsync_CallsStorageUpdateOnce()
        {
            var tour = new TourModel { Id = Guid.NewGuid() };

            // Act
            await manager.UpdateTourAsync(tour, token);

            // Assert
            storageMock.Verify(s => s.UpdateTourAsync(tour, token), Times.Once);
        }

        [Fact]
        public async Task DeleteTourAsync_CallsStorageDeleteOnce()
        {
            var id = Guid.NewGuid();

            // Act
            await manager.DeleteTourAsync(id, token);

            // Assert
            storageMock.Verify(s => s.DeleteTourAsync(id, token), Times.Once);
        }

        [Fact]
        public async Task GetStatisticsAsync_ComputesStatsCorrectly()
        {
            // Arrange
            var tours = new List<TourModel>
            {
                new TourModel { CostPerVacationer = 100, NumberVacationers = 2, Surcharges = 50 },
                new TourModel { CostPerVacationer = 200, NumberVacationers = 1, Surcharges = 0 }
            };

            storageMock
                .Setup(s => s.GetAllToursAsync(token))
                .ReturnsAsync(tours);

            // Act
            var stats = await manager.GetStatisticsAsync(token);

            // Assert
            stats.TotalTours.Should().Be(2);
            stats.TotalCost.Should().Be(450); // 100*2+50 + 200*1
            stats.ToursWithSurcharges.Should().Be(1);
            stats.TotalSurcharges.Should().Be(50);
        }
    }
}
