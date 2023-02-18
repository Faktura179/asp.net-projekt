using Asp.Net_WebApi_projekt.Models.Dto;

namespace Asp.Net_WebApi_projekt.Models
{
    public class ClientsPartialVM
    {
        public ClientsPartialVM(List<ClientDto> clients, int totalPages, int currentPage)
        {
            Clients = clients;
            TotalPages = totalPages;
            CurrentPage = currentPage;
        }

        public List<ClientDto> Clients { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
