using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.Core.Entities;
using GYM_MVC.Core.Helper;
using GYM_MVC.ViewModels;
using GYM_MVC.ViewModels.AccountViewModels;
using GYM_MVC.ViewModels.MembershipViewModels;
using GYM_MVC.ViewModels.ScheduleViewModels;
using GYM_MVC.ViewModels.ExerciseViewModels;
using GYM_MVC.ViewModels.TrainerViewModels;
using GYM_MVC.ViewModels.WorkoutPlansViewModels;

namespace GYM_MVC.Core.MapperConf {

    public class MapperConfig : Profile {

        public MapperConfig() {
            //CreateMap<ApplicationUser, RegisterMemberViewModel>().AfterMap((src, dist) => {
            //    dist.Password = src
            //});
            CreateMap<RegisterUserViewModel, ApplicationUser>().AfterMap((src, dist) => {
                dist.PasswordHash = src.Password;
                dist.UserName = src.Name;
                dist.Email = src.Email;
                dist.PhoneNumber = src.PhoneNumber;
            });

            CreateMap<RegisterMemberViewModel, Member>().AfterMap((src, dist) => {
                dist.Name = src.MemberName;
                dist.Age = DateTime.Today.Year - src.BirthDate.Year;
                dist.AvailableDays = src.AvailableDays.ToString();
                dist.MaritalStatus = src.MaterialStatus;
                dist.Weight = src.Weight;
                dist.Height = src.Height;
                dist.Illnesses = src.Illnesses ?? "";
                dist.Injuries = src.Injuries ?? "";
                dist.SleepHours = src.SleepHours;
                dist.TrainerId = src.SelectedTrainerId;
            });
            CreateMap<RegisterTrainerViewModel, Trainer>().ReverseMap();
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
            CreateMap<WorkoutPlan, DisplayWorkoutPlanVM>().AfterMap((src, dist) => {
                dist.MemberName = src.Member.Name;
                dist.TrainerName = src.Trainer.Name;
            }).ReverseMap();
            CreateMap<WorkoutPlan, CreateWorkoutPlanVM>().ReverseMap();
            CreateMap<WorkoutPlan, EditWorkoutPlanVM>().ReverseMap();

            CreateMap<CreateMembershipViewModel, Membership>().AfterMap(
                (src, dist) =>
                    dist.Type = EnumHelper.ToEnum<MembershipType>(src.SelectedMembershipType)
                );
            CreateMap<UpdateMembershipViewModel, Membership>().AfterMap(
                (src, dist) => {
                    dist.Type = EnumHelper.ToEnum<MembershipType>(src.SelectedMembershipType);
                    dist.Id = src.Id;
                }
                ).ReverseMap().AfterMap(
                   (src, dist) => {
                       dist.SelectedMembershipType = src.Type.ToString();
                   }
                );
            CreateMap<Membership, DisplayMembershipViewModel>().AfterMap(
                (src, dist) => {
                    dist.SelectedMembershipType = src.Type.ToString();
                }
                );
            CreateMap<Exercise, EditExerciseVM>().AfterMap((src, dest) =>
            {
                dest.MemberId = src.WorkoutPlan.MemberId;
            }).ReverseMap();
            CreateMap<Exercise, ExerciseVM>().ReverseMap();
        }
    }
}