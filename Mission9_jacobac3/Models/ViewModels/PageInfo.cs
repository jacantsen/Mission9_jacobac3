using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobac3.Models.ViewModels
{
    public class PageInfo
    {
        // keep track of page number info
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling(((double)TotalNumProjects / ProjectsPerPage));
    }
}
