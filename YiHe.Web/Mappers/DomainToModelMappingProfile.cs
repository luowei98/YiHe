using AutoMapper;
using YiHe.Model.Library;
using YiHe.Web.Helpers;
using YiHe.Web.Models.Library;


namespace YiHe.Web.Mappers
{
    public class DomainToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Article, ArticleModel>()
                .ForMember(am => am.PicturePath, exp => exp.MapFrom(a => PathHelper.ArticlePicture(a)));
        }
    }
}