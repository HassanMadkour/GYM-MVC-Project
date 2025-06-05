using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Domain.Entities
{
    public class WorkoutPlan : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        public int TrainerId { get; set; }
        [ForeignKey("TrainerId")]
        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
