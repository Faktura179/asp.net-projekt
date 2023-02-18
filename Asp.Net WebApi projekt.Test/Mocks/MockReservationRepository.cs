using Asp.Net_WebApi_projekt.Data.Models;
using Asp.Net_WebApi_projekt.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_WebApi_projekt.Test.Mocks
{
    internal class MockReservationRepository : IReservationRepository
    {
        public void Add(Reservation reservation)
        {
            reservation.Id = 111;
        }

        public Task Delete(int Id)
        {
            return Task.CompletedTask;
        }

        public Task<List<Reservation>> GetAll()
        {
            return Task.FromResult(new List<Reservation>());
        }

        public Task<Reservation> GetById(int id)
        {
            var date = new DateTime(2020, 1, 1);
            return Task.FromResult(new Reservation()
            {
                Id = id,
                ClientId = 1,
                Price = 0,
                StartTime = date,
                EndTime = date.AddHours(1)
            }); ;
        }
    }
}
