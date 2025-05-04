namespace credirect_api.Models
{
    public class ClientManager
    {
        public int? ClientManagerID { get; set; }
        public Client? Client { get; set; }
        public int? ClientID { get; set; }
        public ManagerInformation? ManagerInformation { get; set; }
        public int? ManagerID { get; set; }

    }
}