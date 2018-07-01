using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciador.Data.Map
{
    public class DispositivoNoMap
    {
        public DispositivoNoMap(EntityTypeBuilder<DispositivoNo> entityBuilder)
        {
            //entityBuilder.Property(entidade => entidade.EnderecoUrl).HasMaxLength(400);
        }
    }
}
