
using System;

namespace API.Models
{
    public class Exercise
    {
        public Exercise() {
            id = Guid.NewGuid();
            exercise_name = "";
            exercise_desc = "";

        }
            
        public Guid id { get; set; }
        public string exercise_name { get; set; }
        public int exercise_repetition { get; set; }
        public string exercise_desc { get; set; }
        public bool exercise_status { get; set; }

    }
}