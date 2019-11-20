using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tasks.Data;
using Tasks.Web.Models;

namespace Tasks.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly TasksContext _db;

        public JobsController(TasksContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Job> jobs = _db.Jobs.OrderBy(x => x.CreationDate).ToList();

            return View(new JobsViewModel(jobs));
        }

        [HttpGet("Jobs/{Id}")]
        public string GetJob(Guid Id)
        {
            Job job = _db.Jobs.FirstOrDefault(x => x.Id == Id);

            return JsonConvert.SerializeObject(job, Formatting.Indented);
        }

        [HttpPost]
        public IActionResult Add(Job job)
        {
            _db.Jobs.Add(job);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Job job)
        {
            Job dbJob = _db.Jobs.FirstOrDefault(x => x.Id == job.Id);

            if (dbJob != null) {
                dbJob.Name = job.Name;
                dbJob.Description = job.Description;
                dbJob.Tag = job.Tag;
                dbJob.Date = job.Date;

                _db.Jobs.Update(dbJob);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
