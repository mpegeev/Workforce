﻿using System;
using System.Collections.Generic;
using System.Linq;
using Workforce.DAL;
using Workforce.DAL.linq2sql;

namespace Workforce.Models
{
    public class EmployeeSkillRow
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public bool IsCritical { get; set; }
        public bool? IsFuture { get; set; }
        public int? PlanningRating { get; set; }
        public string SkillSet { get; set; }
        public int Rating { get; set; }
        public bool? DevelopmentOpportunity { get; set; }
        public string OccupationArea { get; set; }
        public string Location { get; set; }
        public string JobGroup { get; set; }
        public string JobFamily { get; set; }
        public string JobFunction { get; set; }
        public string JobLevel { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class SkillDistribution
    {
        public List<EmployeeSkillRow> EmployeeSkills { get; private set; }

        public List<string> JobFamilies { get; private set; }
        public List<string> JobFunctions { get; private set; }
        public List<SkillSet> SkillSets { get; private set; }

        public SkillDistribution()
        {
            EmployeeSkills = new ReportDao().GetEmployeeSkills()
                .Select(emp => new EmployeeSkillRow
                                   {
                                       Id = emp.ID,
                                       SkillName = emp.Skill,
                                       SkillId = emp.SkillId,
                                       IsCritical = emp.IsCritical,
                                       IsFuture = emp.IsNeededInFuture,
                                       PlanningRating = emp.PlanningRating,
                                       SkillSet = emp.SkillSet,
                                       Rating = emp.Rating,
                                       DevelopmentOpportunity = emp.DevelopmentOpportunity,
                                       OccupationArea = emp.OccupationArea,
                                       Location = emp.Location,
                                       JobGroup= emp.GroupName,
                                       JobFamily = emp.FamName,
                                       JobFunction = emp.FuncName,
                                       JobLevel = emp.LevelName,
                                       Age = emp.Age ?? 0,
                                       Gender = emp.Gender
                                   })
                .ToList();

            JobFamilies = new LookupDao().GetJobFamilies();
            JobFunctions = new LookupDao().GetJobFunctions();
            SkillSets = new LookupDao().GetSkillSets();
        }

    }
}