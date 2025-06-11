using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.Core.Entities;
using GYM_MVC.ViewModels;
using GYM_MVC.ViewModels.ScheduleViewModels;

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
        }
    }
}