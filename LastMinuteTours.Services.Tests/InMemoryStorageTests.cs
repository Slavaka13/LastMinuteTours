using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using LastMinuteTours.Entities;
using Xunit;

namespace LastMinuteTours.Services.Tests
{
    /// <summary>
    /// Тестики
    /// </summary>
    public class InMemoryStorageTests
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly InMemoryStorage storage;

        public InMemoryStorageTests()
        {
            // Фейковая фабрика логгеров, чтобы не тянуть настоящий Serilog.
            var loggerMock = new Mock<ILogger>();
            var loggerFactoryMock = new Mock<ILoggerFactory>();
            loggerFactoryMock
                .Setup(f => f.CreateLogger(It.IsAny<string>()))
                .Returns(loggerMock.Object);

            storage = new InMemoryStorage(loggerFactoryMock.Object);
        }

        /// <summary>
        /// GetAllToursAsync должен возвращать пустой список, если туров ещё нет.
        /// </summary>
        [Fact]
        public async Task GetAllToursAsyncShouldReturnEmptyWhenNoTours()
        {
            // Act
            var tours = await storage.GetAllToursAsync(cancellationToken);

            // Assert
            tours.Should().BeEmpty();
        }

        /// <summary>
        /// AddTourAsync должен добавлять тур.
        /// </summary>
        [Fact]
        public async Task AddTourAsyncShouldAddTour()
        {
            // Arrange
            var tour = CreateTour();

            // Act
            await storage.AddTourAsync(tour, cancellationToken);
            var tours = await storage.GetAllToursAsync(cancellationToken);

            // Assert
            tours.Should().ContainSingle()
                .Which.Id.Should().Be(tour.Id);
        }

        /// <summary>
        /// UpdateTourAsync должен обновлять существующий тур.
        /// </summary>
        [Fact]
        public async Task UpdateTourAsyncShouldUpdateExistingTour()
        {
            // Arrange
            var tour = CreateTour(costPerVacationer: 100m, numberVacationers: 2);
            await storage.AddTourAsync(tour, cancellationToken);

            var updated = new TourModel
            {
                Id = tour.Id,
                Direction = Direction.France,
                DepartureDate = tour.DepartureDate.AddDays(1),
                NumberNights = tour.NumberNights + 1,
                CostPerVacationer = 200m,
                NumberVacationers = 3,
                AvailabilityWiFi = !tour.AvailabilityWiFi,
                Surcharges = 50m
            };

            // Act
            await storage.UpdateTourAsync(updated, cancellationToken);
            var tours = await storage.GetAllToursAsync(cancellationToken);
            var actual = tours.Should().ContainSingle().Subject;

            // Assert
            actual.Direction.Should().Be(Direction.France);
            actual.NumberNights.Should().Be(updated.NumberNights);
            actual.CostPerVacationer.Should().Be(200m);
            actual.NumberVacationers.Should().Be(3);
            actual.Surcharges.Should().Be(50m);
        }

        /// <summary>
        /// DeleteTourAsync должен удалять тур.
        /// </summary>
        [Fact]
        public async Task DeleteTourAsyncShouldRemoveTour()
        {
            // Arrange
            var tour = CreateTour();
            await storage.AddTourAsync(tour, cancellationToken);

            // Act
            await storage.DeleteTourAsync(tour.Id, cancellationToken);
            var tours = await storage.GetAllToursAsync(cancellationToken);

            // Assert
            tours.Should().BeEmpty();
        }

        /// <summary>
        /// GetStatisticsAsync должен возвращать корректную статистику.
        /// </summary>
        [Fact]
        public async Task GetStatisticsAsyncShouldReturnCorrectStatistics()
        {
            // Arrange
            var tour1 = CreateTour(costPerVacationer: 100m, numberVacationers: 2, surcharges: 50m);
            var tour2 = CreateTour(costPerVacationer: 200m, numberVacationers: 1, surcharges: 0m);

            await storage.AddTourAsync(tour1, cancellationToken);
            await storage.AddTourAsync(tour2, cancellationToken);

            // ожидаемое:
            // тур1: 100*2 + 50 = 250
            // тур2: 200*1 + 0  = 200
            // итого: 450, доплаты: 50, туров с доплатами: 1
            var expectedTotalTours = 2;
            var expectedTotalCost = 450m;
            var expectedToursWithSurcharges = 1;
            var expectedTotalSurcharges = 50m;

            // Act
            var stats = await storage.GetStatisticsAsync(cancellationToken);

            // Assert
            stats.TotalTours.Should().Be(expectedTotalTours);
            stats.TotalCost.Should().Be(expectedTotalCost);
            stats.ToursWithSurcharges.Should().Be(expectedToursWithSurcharges);
            stats.TotalSurcharges.Should().Be(expectedTotalSurcharges);
        }

        private static TourModel CreateTour(
            decimal costPerVacationer = 100m,
            int numberVacationers = 1,
            decimal surcharges = 0m)
        {
            return new TourModel
            {
                Id = Guid.NewGuid(),
                Direction = Direction.France,
                DepartureDate = DateTime.Today,
                NumberNights = 7,
                CostPerVacationer = costPerVacationer,
                NumberVacationers = numberVacationers,
                AvailabilityWiFi = true,
                Surcharges = surcharges
            };
        }
    }
}
