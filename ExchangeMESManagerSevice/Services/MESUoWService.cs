using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Services
{
    public class MESUoWService : IDisposable
    {
        private bool disposed = false;
        private AuthorizationMesService _authService;
        private HttpMaterialsRepository _MaterialsRepository;
        private HttpDMMaterialsRepository _DMMaterialsRepository;
        private HttpUoMRepository _UoMRepository;
        private HttpMaterialClassRepository _MaterialClassRepository;
        private HttpEquipmentRepository _EquipmentRepository;
        private HttpEquipmentConfigurationRepository _EquipmentConfigurationRepository;
        private HttpAsPlannedBOPRepository _AsPlannedBOPRepository;
        private HttpSupplierRepository _SupplierRepository;

        public MESUoWService(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public HttpMaterialsRepository MaterialsRepository
        {
            get
            {
                if (_MaterialsRepository == null)
                    _MaterialsRepository = new HttpMaterialsRepository(_authService);
                return _MaterialsRepository;
            }
        }
        public HttpDMMaterialsRepository DMMaterialsRepository
        {
            get
            {
                if (_DMMaterialsRepository == null)
                    _DMMaterialsRepository = new HttpDMMaterialsRepository(_authService);
                return _DMMaterialsRepository;
            }
        }

        public HttpUoMRepository UoMRepository
        {
            get
            {
                if (_UoMRepository == null)
                    _UoMRepository = new HttpUoMRepository(_authService);
                return _UoMRepository;
            }
        }
        public HttpMaterialClassRepository MaterialClassRepository
        {
            get
            {
                if (_MaterialClassRepository == null)
                    _MaterialClassRepository = new HttpMaterialClassRepository(_authService);
                return _MaterialClassRepository;
            }
        }
        public HttpEquipmentRepository EquipmentRepository
        {
            get
            {
                if (_EquipmentRepository == null)
                    _EquipmentRepository = new HttpEquipmentRepository(_authService);
                return _EquipmentRepository;
            }
        }
        public HttpEquipmentConfigurationRepository EquipmentConfigurationRepository
        {
            get
            {
                if (_EquipmentConfigurationRepository == null)
                    _EquipmentConfigurationRepository = new HttpEquipmentConfigurationRepository(_authService);
                return _EquipmentConfigurationRepository;
            }
        }
        public HttpAsPlannedBOPRepository AsPlannedBOPRepository
        {
            get
            {
                if (_AsPlannedBOPRepository == null)
                    _AsPlannedBOPRepository = new HttpAsPlannedBOPRepository(_authService);
                return _AsPlannedBOPRepository;
            }
        }
        public HttpSupplierRepository SupplierRepository
        {
            get
            {
                if (_SupplierRepository == null)
                    _SupplierRepository = new HttpSupplierRepository(_authService);
                return _SupplierRepository;
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
