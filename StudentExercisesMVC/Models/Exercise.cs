using System;
using System.Collections.Generic;

namespace StudentExercises
{

    public class Exercise
    {

        //public Exercise(string name, string language)
        //{

        //    Name = name;
        //    Language = language;

        //}
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseLanguage { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }

}