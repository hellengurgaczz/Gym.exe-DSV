
using System;

namespace API.Models
{
    public class Workout
    {
        public Workout() {
            id = Guid.NewGuid();
            workout_name = "";
            workout_desc = "";
            workout_recommendation = "";
        }
            
        public Guid id { get; set; }
        public string workout_name { get; set; }
        public int workout_frequency { get; set; }
        public string workout_desc { get; set; }
        public string workout_recommendation { get; set; }
        public bool workout_status { get; set; }

    }
}