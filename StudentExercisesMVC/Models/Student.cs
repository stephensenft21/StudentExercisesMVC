using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercises
{

    public class Student
    {

        //CONSTRUCTOR
        //public Student(string first, string last, string slack, Cohort cohort)
        //{

        //    FirstName = first;
        //    LastName = last;
        //    SlackHandle = slack;
        //    StudentCohort = cohort;

        //}

        public int Id { get; set; }
        [Display(Name = "First Name")]

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Characters exceeds 20, minimum 2 characters")]


        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        public string Slack { get; set; }
        [Display(Name = "Cohort Id")]
        public int CohortId { get; set; }

        public Cohort StudentCohort { get; set; }
        public List<Exercise> StudentExerciseList { get; set; } = new List<Exercise>();

    }

}   