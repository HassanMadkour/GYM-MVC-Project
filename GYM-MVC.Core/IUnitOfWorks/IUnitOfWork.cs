using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_MVC.Core.IRepositories;

namespace GYM_MVC.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        public Task<int> Save();
        public IMemberRepo MemberRepo { get;}
        public ITrainerRepo TrainerRepo { get;}
        public IExcerciseRepo ExcerciseRepo { get;}
        public IWorkoutPlanRepo WorkoutPlanRepo { get;}
    }
}
