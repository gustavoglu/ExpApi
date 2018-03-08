using Exp.Infra.Data.Inicializers;

namespace Exp.Services.Api.Configurations
{
    public class SeedConfiguration
    {
        private readonly ContaTipoInicializer _contaTipo;

        public SeedConfiguration(ContaTipoInicializer contaTipo)
        {
            _contaTipo = contaTipo;
        }

        public void Seed()
        {
            _contaTipo.Seed();
        }
    }
}
