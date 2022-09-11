using System;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/exercises")]

    public class ExercisesController : ControllerBase 
    {
        private readonly DataContext _context;
        public ExercisesController(DataContext context) => _context = context;


        [HttpPost]
        public IActionResult Create([FromBody] Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
            return Created("Exercicio cadastrado!", exercise);
        }

        [HttpGet]
        public List<Exercise> List() => _context.Exercises.ToList();
        
        private Exercise getById(Guid id)
        {
            Exercise? exercise = _context.Exercises.Find(id);
            return exercise;
            
        }
        [HttpPut]
        public IActionResult Update([FromBody] Exercise newExercise)
        {
            Exercise exercise = getById(newExercise.id);

            if(exercise == null) {
                return NotFound();
            }

            exercise.exercise_name = newExercise.exercise_name;
            exercise.exercise_desc = newExercise.exercise_desc;
            exercise.exercise_repetition = newExercise.exercise_repetition;
            exercise.exercise_status = newExercise.exercise_status;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete( [FromRoute] Guid id)
        {
            Exercise exercise = getById(id);

            if(exercise == null) {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
            return Ok();
        }
    }

}