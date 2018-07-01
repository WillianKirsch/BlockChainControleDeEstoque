using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servico.BancoDeDados.Map
{
    public class DispositivoNoMap
    {
        public DispositivoNoMap(EntityTypeBuilder<DispositivoNo> entityBuilder)
        {
            //entityBuilder.Property(entidade => entidade.EnderecoUrl).HasMaxLength(400);
        }
    }
}
