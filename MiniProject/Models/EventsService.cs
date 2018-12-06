using MiniProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class EventsService
    {
        public IndexVM[] GetEvents()
        {
            IndexVM[] indexVMs = new IndexVM[] {
                new IndexVM {
                Date = DateTime.Now,
                Url = "HTTP",
                Name = "JoelÄrBäst",
                Image = "Happy goat"
                }
            };
            return indexVMs;
        }
    }
}
