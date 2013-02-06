using AutoMapper;
using YiHe.Domain.Commands.Material;
using YiHe.Domain.Commands.Security;
using YiHe.Web.ViewModels;
using YiHe.Web.ViewModels.Material;


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

            Mapper.CreateMap<NewsFormModel, CreateOrUpdateNewsCommand>();
        }
    }
}