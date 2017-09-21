using EmployeeListTest.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeListTest.DAL
{
    public static class DbInitializer
    {

        public static void Initialize(this EmployeeContext context)
        {
            context.Database.Migrate();

            //TODO: Add ability to reseed jobs
            if (!context.Jobs.Any())
            {
                var jobs = new Job[]
                {
                    new Job(){Title = "CEO"},
                    new Job(){Title = "Business Analist"},
                    new Job(){Title = "Developer"},
                    new Job(){Title = "QA"}
                };

                foreach (Job j in jobs)
                {
                    context.Jobs.Add(j);
                }
                context.SaveChanges();
            }

        }
    }
}
