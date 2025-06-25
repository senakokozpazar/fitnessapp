using System;
namespace FitnessApp.Models
{
	public class ExerciseSummary
	{
        public int TotalExercises { get; set; }
        public int TotalDuration { get; set; }
        public int DurationLast7Days { get; set; }
        public DateTime? LastExerciseDate { get; set; }
    }
}

