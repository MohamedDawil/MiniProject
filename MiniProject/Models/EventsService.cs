using MiniProject.Json;
using MiniProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class EventsService
    {
        public async Task<IndexVM[]> GetEventsAsync()
        {
            var http = new HttpClient();
            var url = string.Format("https://app.ticketmaster.com/discovery/v2/events.json?apikey=1Ja7Cr4nkXBk7CtLdBxDAfxcOjPfeUvE");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Rootobject>(result); // Convertor from string"result" to json
            List<IndexVM> indexVMs = new List<IndexVM>();

            foreach (var item in json._embedded.events)
            {
                var indexVM = new IndexVM();
                indexVM.Date = Convert.ToDateTime(item.dates.start.localDate);
                var tempurl = item.images[0].url;
                indexVM.Image = (tempurl == null) ? "" : tempurl;
                indexVM.Url = item.url;
                indexVM.Name = item.name;
                indexVM.Id = item.id;
                indexVMs.Add(indexVM);
            }
            return indexVMs.ToArray();
        }

        public async Task<BookVM> GetEventByIdAndNameAsync(string id, string name)
        {
            var http = new HttpClient();
            var url = string.Format("https://app.ticketmaster.com/discovery/v2/events.json?apikey=1Ja7Cr4nkXBk7CtLdBxDAfxcOjPfeUvE");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Rootobject>(result); // Convertor from string"result" to json
            var newEvent = json._embedded.events.SingleOrDefault(e => e.id == id);
            var preSale = newEvent.sales.presales.SingleOrDefault(p => p.name == name);

            var bookVM = new BookVM
            {
                Name = newEvent.name,
                EventId = newEvent.id,
                StartDate = preSale.startDateTime,
                PresaleName = preSale.name,
            };

            return bookVM;
        }

        public async Task<DetailVM> GetEventByIdAsync(string id)
        {
            var http = new HttpClient();
            var url = string.Format("https://app.ticketmaster.com/discovery/v2/events.json?apikey=1Ja7Cr4nkXBk7CtLdBxDAfxcOjPfeUvE");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Rootobject>(result); // Convertor from string"result" to json
            var newEvent = json._embedded.events.SingleOrDefault(e => e.id == id);
            var tempurl = newEvent.images[0].url;

            var detailVM = new DetailVM
            {
                Name = newEvent.name,
                Id = newEvent.id,
                Url = newEvent.url,
                Image = (tempurl == null) ? "" : tempurl
            };
            foreach (var presale in newEvent.sales.presales)
            {
                detailVM.Presales.Add(
                    new PresaleVM
                    {
                        StartDateTime = presale.startDateTime,
                        EndDateTime = presale.endDateTime,
                        Name = presale.name
                    }
                    );
            }
            return detailVM;
        }
    }



}
