using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasklyApp.Models
{
    public class TaskOverview
    {
        public string? Total { get; set; }
        public string? Todo { get; set; }
        public string? OnGoing { get; set; }
        public string? Done { get; set; }
    }
}
