using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Services.SQLServices;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Services
{
    public class SQLUoWService : IDisposable
    {
        private bool disposed = false;
        private MateriaSQLRepository _MateriaSQLRepository;

        public SQLUoWService()
        {
        }
         

        public MateriaSQLRepository MateriaSQLRepository
        {
            get
            {
                if (_MateriaSQLRepository == null)
                    _MateriaSQLRepository = new MateriaSQLRepository();
                return _MateriaSQLRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
