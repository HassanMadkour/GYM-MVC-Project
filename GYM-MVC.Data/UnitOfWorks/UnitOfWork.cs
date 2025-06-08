using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Core.IUnitOfWorks;
using GYM_MVC.Data.Data;
using GYM_MVC.Data.Repositories;

namespace GYM_MVC.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        GYMContext context;
        IMemberRepo memberRepo;
        ITrainerRepo trainerRepo;
        IExcerciseRepo excerciseRepo;
        IWorkoutPlanRepo workoutPlanRepo;
        public UnitOfWork(GYMContext context)
        {
            this.context = context;    
        }

        public async Task<int> Save() => await context.SaveChangesAsync();

        public IMemberRepo MemberRepo
        {
            get 
            { 
                if(memberRepo is null)
                    memberRepo = new MemberRepo(context);
                return memberRepo;
            }
        }

        public ITrainerRepo TrainerRepo
        {
            get
            {
                if(trainerRepo is null)
                    trainerRepo = new TrainerRepo(context);
                return trainerRepo;
            }
        }

        public IExcerciseRepo ExcerciseRepo
        {
            get
            {
                if(excerciseRepo is null)
                    excerciseRepo = new ExcerciseRepo(context);
                return excerciseRepo;
            }
        }

        public IWorkoutPlanRepo WorkoutPlanRepo
        {
            get
            {
                if(workoutPlanRepo is null)
                    workoutPlanRepo = new WorkoutPlanRepo(context);
                return workoutPlanRepo;
            }
        }


    }
}
