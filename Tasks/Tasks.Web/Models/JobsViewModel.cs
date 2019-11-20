using System.Collections.Generic;
using Tasks.Data;

namespace Tasks.Web.Models
{
    public class JobsViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }

        public JobsViewModel (IEnumerable<Job> jobs)
        {
            this.Jobs = jobs;
        }
    }
}
