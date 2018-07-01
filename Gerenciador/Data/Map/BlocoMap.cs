using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciador.Data.Map
{
    public class BlocoMap
    {
        public BlocoMap(EntityTypeBuilder<Bloco> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Chave).HasMaxLength(400);
            entityBuilder.Property(entidade => entidade.ChaveBlocoAnterior).HasMaxLength(400);
        }
    }
}
