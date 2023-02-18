using Asp.Net_WebApi_projekt.Models.Dto;
using Asp.Net_WebApi_projekt.Repositories;
using Asp.Net_WebApi_projekt.Services;
using Asp.Net_WebApi_projekt.Test.Mocks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Reflection;

namespace Asp.Net_WebApi_projekt.Test.Services
{
    [TestClass]
    public class WriteReservationTests
    {
        private IWriteReservationService _writeReservationService;

        public WriteReservationTests()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Mapper.MapperConfiguration)));

            var serviceProvider = services.BuildServiceProvider();

            var mapper = serviceProvider.GetService<IMapper>();

            var UoWMock = new Mock<IUnitOfWork>();
            UoWMock.SetupGet(x => x.Reservations).Returns(new MockReservationRepository());

            _writeReservationService = new WriteReservationService(UoWMock.Object, mapper);
        }

        [TestMethod]
        [DataRow(2023, 1, 1, 12, 0)]
        [DataRow(2021, 11, 13, 9, 35)]
        public async Task AddNewReservation__ShouldThrowException(int year, int month, int day, int hour, int minutes)
        {
            var reservation = new ReservationDto()
            {
                ClientId = 1,
                Price = 1,
                SwimmingTrackId = 1,
                StartTime = new DateTime(year, month, day, hour, minutes, 0),
                EndTime = new DateTime(year, month, day, hour, minutes, 0),
            };

            var reservation2 = new ReservationDto()
            {
                ClientId = 1,
                Price = 1,
                SwimmingTrackId = 1,
                StartTime = new DateTime(year, month, day, hour, minutes + 1, 0),
                EndTime = new DateTime(year, month, day, hour, minutes, 0),
            };


            await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => _writeReservationService.Add(reservation)
            );
            await Assert.ThrowsExceptionAsync<ArgumentException>(
                () => _writeReservationService.Add(reservation2)
            );
        }

        [TestMethod]
        [DataRow(2023, 1, 1, 12, 0)]
        [DataRow(2021, 11, 13, 9, 35)]
        public async Task AddNewReservation_ShouldAddReservation(int year, int month, int day, int hour, int minutes)
        {
            var reservation = new ReservationDto()
            {
                Id = 0,
                ClientId = 1,
                Price = 1,
                SwimmingTrackId = 1,
                StartTime = new DateTime(year, month, day, hour, minutes, 0),
                EndTime = new DateTime(year, month, day, hour, minutes + 1, 0),
            };

            var result = await _writeReservationService.Add(reservation);

            Assert.AreEqual(111, result);
        }
    }
}
