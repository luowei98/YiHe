using AutoMapper;
using YiHe.Model.Material;
using YiHe.Web.ViewModels.Material;


namespace YiHe.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<Category, CategoryFormModel>();
            //Mapper.CreateMap<Expense, ExpenseFormModel>().ForMember(dest => dest.Category, opt => opt.Ignore());

            Mapper.CreateMap<News, NewsFormModel>()
                .ForMember(nfm => nfm.CreateTime, exp => exp.MapFrom(n => n.CreateTime.ToShortDateString()));
        }
    }
}