using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.Core.Entities;
using GYM_MVC.ViewModels;
using GYM_MVC.ViewModels.ScheduleViewModels;
using GYM_MVC.ViewModels.AccountViewModels;
using GYM_MVC.ViewModels.ExerciseViewModels;
using GYM_MVC.ViewModels.TrainerViewModels;
using GYM_MVC.ViewModels.WorkoutPlansViewModels;

namespace GYM_MVC.Core.MapperConf {
    public class MapperConfig : Profile {
        public MapperConfig() {
            //CreateMap<ApplicationUser, RegisterMemberViewModel>().AfterMap((src, dist) => {
            //    dist.Password = src
            //});
            CreateMap<RegisterMemberViewModel, ApplicationUser>().AfterMap((src, dist) => {
                dist.PasswordHash = src.Password;
                dist.UserName = src.Name;
                dist.Email = src.Email;
                dist.PhoneNumber = src.PhoneNumber;
            });

            CreateMap<RegisterMemberViewModel, Member>().AfterMap((src, dist) => {
                dist.Name = src.Name;
                dist.Age = DateTime.Today.Year - src.BirthDate.Year;
                dist.AvailableDays = src.AvailableDays.ToString();
                dist.MaritalStatus = src.MaterialStatus;
                dist.Weight = src.Weight;
                dist.Height = src.Height;
                dist.Illnesses = src.Illnesses ?? "";
                dist.Injuries = src.Injuries ?? "";
                dist.SleepHours = src.SleepHours;
            });
            CreateMap<Member, RegisterMemberViewModel>().AfterMap((src, dist) => {
            });
            CreateMap<LoginUserViewModel, ApplicationUser>().AfterMap((src, dist) => {
                dist.UserName = src.UserName;
            });

            CreateMap<CreateScheduleViewModel, Schedule>().ReverseMap();

            CreateMap<Schedule, ScheduleViewModel>().ReverseMap();
            CreateMap<Member, MemberViewModel>().ReverseMap();
            CreateMap<Trainer, DisplayTrainerVM>().ReverseMap();
            CreateMap<Trainer, CreateTrainerVM>().ReverseMap();
            CreateMap<Trainer, EditTrainerVM>().ReverseMap();
            CreateMap<Member, MemberByTrainerIdVM>().ReverseMap();
            CreateMap<Member, DisplayMemberWithWorkoutPlansVM>().ReverseMap();
            CreateMap<WorkoutPlan, DisplayWorkoutPlanVM>().AfterMap((src, dist) =>
            {
                dist.MemberName = src.Member.Name;
                dist.TrainerName = src.Trainer.Name;
            }).ReverseMap();
            CreateMap<WorkoutPlan, CreateWorkoutPlanVM>().ReverseMap();
            CreateMap<WorkoutPlan, EditWorkoutPlanVM>().ReverseMap();
            CreateMap<Exercise, EditExerciseVM>().ReverseMap();
            CreateMap<Exercise, ExerciseVM>().ReverseMap();
        }
    }
}