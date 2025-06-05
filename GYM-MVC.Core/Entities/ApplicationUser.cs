using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Member")]
        public int? MemberId { get; set; }
        public virtual Member? Member { get; set; }

        [ForeignKey("Trainer")]
        public int? TrainerId { get; set; }
        public virtual Trainer? Trainer { get; set; }
    }
}
