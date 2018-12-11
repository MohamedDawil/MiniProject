using System;
using System.Collections.Generic;

namespace MiniProject.Models.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}
