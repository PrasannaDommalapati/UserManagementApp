using AutoMapper;
using UserManagement.Business.Models;
using UserManagement.DataAccess.Entity;

namespace UserManagement.Business.Mappings
{
    public class ToUser : Profile
    {
        public ToUser()
        {
            //From user to user model
            CreateMap<User, UserModel>()
                .ForMember(a => a.Id, d => d.MapFrom(s =>s.Id))
                .ForMember(a => a.Email, d => d.MapFrom(s => s.Email))
                .ForMember(a => a.LastName, d => d.MapFrom(s => s.LastName))
                .ForMember(a => a.FirstName, d => d.MapFrom(s => s.FirstName))
                .ForMember(a => a.DateModified, d => d.MapFrom(s => s.DateModified))
                .ForMember(a => a.Birthday, d => d.MapFrom(s => s.Birthday))
                .ForMember(a => a.Roles, d => d.MapFrom(s => s.Roles))
                .ForMember(a => a.Organisations, d => d.MapFrom(s => s.Organisations))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
