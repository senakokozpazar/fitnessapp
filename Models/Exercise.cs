using System;
namespace FitnessApp.Models
{
	public class Exercise
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ExerciseName { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime ExerciseDate { get; set; }
    }
}

