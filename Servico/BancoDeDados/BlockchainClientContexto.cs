using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore;
using Servico.BancoDeDados.Map;

namespace Servico.BancoDeDados
{
    public class BlockchainClientContexto : DbContext
    {
        public BlockchainClientContexto(DbContextOptions<BlockchainClientContexto> options) : base(options)
        {
        }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<DispositivoNo> Dispositivos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemTransacao> ItansTransacao { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new BlocoMap(builder.Entity<Bloco>());
            new DispositivoNoMap(builder.Entity<DispositivoNo>());
            new TransacaoMap(builder.Entity<Transacao>());
            new ProdutoMap(builder.Entity<Produto>());
        }
    }
}
