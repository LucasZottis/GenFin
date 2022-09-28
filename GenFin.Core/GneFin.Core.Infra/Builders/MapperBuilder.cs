using AutoMapper;
using GenFin.Core.Dominio.Profiles;

namespace GenFin.Core.Infra.Builders
{
    public static class MapperBuilder
    {
        public static IMapper BuildMapper()
        {
            var mapperConfiguration = new MapperConfiguration( m =>
            {
                m.AddProfile( new CategoryProfile() );
            } );

            return mapperConfiguration.CreateMapper();
        }
    }
}