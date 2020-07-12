using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online13.Models;


namespace Online13.ViewModels
{
    public class VmEventSingle
    {
        public Event Event { get; set; }
        public List<EventRelSpeakers> eventRelSpeakers { get; set; }
        public List<Position> positions { get; set; }
    }
}