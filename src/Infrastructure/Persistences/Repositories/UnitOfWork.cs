using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyPortaLiveContext _context;
        public ITechnologyRepository Technology { get; private set; }

        public UnitOfWork(MyPortaLiveContext context)
        {
            _context = context;
            Technology = new TechnologyRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
