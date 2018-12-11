using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.ViewModels
{
    public class DetailVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public List<PresaleVM> Presales { get; set; } = new List<PresaleVM>();

    }
    public class PresaleVM
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Name { get; set; }

    }
}
