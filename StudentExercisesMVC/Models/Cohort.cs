using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercises
{

    public class Cohort
    {

        //public Cohort(string name)
        //{

        //    Name = name;

        //}


        public int Id { get; set; }
        [Required]
        public string CohortName { get; set; }

        List<Student> StudentsInCohort { get; set; }
        List<Instructor> InstructorsOfCohort { get; set; }

    }

}