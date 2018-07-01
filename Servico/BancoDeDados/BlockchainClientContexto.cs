using BlockChain.Entidades;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bloco>().HasKey(m => m.Id);
            builder.Entity<DispositivoNo>().HasKey(m => m.Id);
            builder.Entity<Transacao>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
