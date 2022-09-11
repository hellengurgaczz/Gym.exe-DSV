using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/workouts")]

    public class WorkoutsController : ControllerBase 
    {
        private readonly DataContext _context;
        public WorkoutsController(DataContext context) => _context = context;


        [HttpPost]
        public IActionResult Create([FromBody] Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            return Created("Treino cadastrado!", workout);
        }

        [HttpGet]
        public List<Workout> List() => _context.Workouts.ToList(); 
        
        private Workout getById(Guid id)
        {
            Workout? workout = _context.Workouts.Find(id);
            return workout;
            
        }

        [HttpPut]
        public IActionResult Update( [FromBody] Workout newWorkout)
        {
            Workout? workout = getById(newWorkout.id);

            if(workout == null) {
                return NotFound();
            }

            workout.workout_name = newWorkout.workout_name;
            workout.workout_frequency = newWorkout.workout_frequency;
            workout.workout_desc = newWorkout.workout_desc;
            workout.workout_recommendation = newWorkout.workout_recommendation;
            workout.workout_status = newWorkout.workout_status;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete( [FromRoute] Guid id)
        {
            Workout workout = getById(id);

            if(workout == null) {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            _context.SaveChanges();
            return Ok();
        }
    }

}