using GYM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MVC.Core.Entities
{
    public class Schedule  : BaseEntity
    {
        public string DayOfWeek {  get; set; }

        public TimeOnly Time { get; set; }

        public string ClassName{  get; set; }

    }
}
