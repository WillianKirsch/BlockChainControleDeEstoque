using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servico.BancoDeDados.Map
{
    public class TransacaoMap
    {
        public TransacaoMap(EntityTypeBuilder<Transacao> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Destinatario).HasMaxLength(400);
            entityBuilder.Property(entidade => entidade.Remetente).HasMaxLength(400);
        }
    }
}
