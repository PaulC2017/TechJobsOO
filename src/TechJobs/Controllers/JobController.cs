using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System;


namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view 
            // TODO #1 - Completed

            Job jobToView = jobData.Find(id);
            /*JobDisplayViewModel displayThisJob = new JobDisplayViewModel
            {
                Name = jobToView.Name,
                Employer = jobToView.Employer,
                Location = jobToView.Location,
                CoreCompetency = jobToView.CoreCompetency,
                PositionType = jobToView.PositionType

            };
            
            return View(displayThisJob);
            */
            return View(jobToView);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View("New",newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            //Employer assignEmployerID = new Employer();

          
            if (ModelState.IsValid)

                
            {
                Job newJob = new Job

                {

                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(int.Parse(newJobViewModel.LocationID)),
                    CoreCompetency = jobData.CoreCompetencies.Find(int.Parse(newJobViewModel.CoreCompetencyID)),
                    PositionType = jobData.PositionTypes.Find(int.Parse(newJobViewModel.PositionTypeID))
                };

                jobData.Jobs.Add(newJob);
                return View("Index",newJob.ID);
            }

            return View("New", newJobViewModel); 
        }
    }
}
