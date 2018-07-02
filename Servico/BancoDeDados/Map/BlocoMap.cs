using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servico.BancoDeDados.Map
{
    public class BlocoMap
    {
        public BlocoMap(EntityTypeBuilder<Bloco> entityBuilder)
        {
            entityBuilder.HasKey(m => m.Id);
            entityBuilder.Property(entidade => entidade.Chave).HasMaxLength(400);
            entityBuilder.Property(entidade => entidade.ChaveBlocoAnterior).HasMaxLength(400);
            entityBuilder.Property(entidade => entidade.ChaveBlocoSucessor).HasMaxLength(400);
        }
    }
}
