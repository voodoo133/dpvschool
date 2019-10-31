using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tasks
{
    public class Job
    {
        public Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime CreationDate = DateTime.Now;
        public DateTime? Date { get; set; }
    }
}