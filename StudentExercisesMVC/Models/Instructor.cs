using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentExercises
{

    public class Instructor
    {

        //public Instructor(string first, string last, string slack, Cohort cohort, string specialty)
        //{

        //    First = first;
        //    Last = last;
        //    Slack = slack;
        //    InstructorCohort = cohort;
        //    Specialty = specialty;



        //}
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Slack { get; set; }
        public string Specialty { get; set; }
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
        public List<Instructor> Instructors { get; set; }
        public void AssignExercise(Student student, Exercise exercise)
        {
            student.StudentExerciseList.Add(exercise);
            exercise.Students.Add(student);


        }




    }

}