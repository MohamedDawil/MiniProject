using System;
using System.Collections.Generic;

namespace MiniProject.Models.Entities
{
    public partial class Ticket
    {
        public Ticket()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EventId { get; set; }
        public DateTime StartDate { get; set; }
        public string PresaleName { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
