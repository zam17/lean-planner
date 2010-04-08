using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeanPlanner.Domain.Entities
{
    public class Project
    {
        public Project(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Project Name Cannot be NULL","name");
            }

            Name = name;
        }

        public string Name { get; private set; }

        public string Description { get; set; }
    }
}
