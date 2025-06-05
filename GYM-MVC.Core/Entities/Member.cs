using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Domain.Entities
{
    public class Member : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(12,70)]
        public int Age { get; set; }
        public string? MaritalStatus { get; set; }
        [Range(30, 300)]
        public decimal Weight { get; set; }
        [Range(100, 250)]
        public decimal Height { get; set; }
        [MaxLength(200)]
        public string Illnesses { get; set; }
        [MaxLength(200)]
        public string Injuries { get; set; }
        [Range(0, 24)]
        public int SleepHours { get; set; }
        public string AvailableDays { get; set; }
    
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

       
        public int? TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public virtual Trainer Trainer { get; set; }

        public virtual WorkoutPlan? WorkoutPlan { get; set; }
    }
}
