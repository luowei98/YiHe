using AutoMapper;
using YiHe.Domain.Commands.Security;
using YiHe.Web.ViewModels;


namespace YiHe.Web.Mappers
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<CategoryFormModel, CreateOrUpdateCategoryCommand>();
            //Mapper.CreateMap<ExpenseFormModel, CreateOrUpdateExpenseCommand>();
            Mapper.CreateMap<UserFormModel, UserRegisterCommand>();
        }
    }
}