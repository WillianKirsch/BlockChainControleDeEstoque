using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servico.BancoDeDados.Map
{
    public class DispositivoNoMap
    {
        public DispositivoNoMap(EntityTypeBuilder<DispositivoNo> entityBuilder)
        {
            entityBuilder.HasKey(m => m.Id);
            entityBuilder.Property(entidade => entidade.EnderecoUrl).HasMaxLength(400);
            entityBuilder.Property(entidade => entidade.Erro).HasMaxLength(600);
            
        }
    }
}
