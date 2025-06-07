using AutoMapper;
using GYM.Domain.Entities;
using GYM_MVC.ViewModels;

namespace GYM_MVC.Core.MapperConf {

    public class MapperConfig : Profile {

        public MapperConfig() {
            CreateMap<ApplicationUser, RegisterMemberViewModel>().AfterMap((src, dist) => {
            });
            CreateMap<RegisterMemberViewModel, ApplicationUser>().AfterMap((src, dist) => {
            });

            CreateMap<RegisterMemberViewModel, Member>().AfterMap((src, dist) => {
            });
            CreateMap<Member, RegisterMemberViewModel>().AfterMap((src, dist) => {
            });
        }
    }
}