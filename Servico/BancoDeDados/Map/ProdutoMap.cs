using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Servico.BancoDeDados.Map
{
    public class ProdutoMap
    {
        public ProdutoMap(EntityTypeBuilder<Produto> entityBuilder)
        {
            entityBuilder.HasKey(m => m.Id);
            entityBuilder.Property(entidade => entidade.Codigo).HasMaxLength(50);
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(400);
        }
    }
}
