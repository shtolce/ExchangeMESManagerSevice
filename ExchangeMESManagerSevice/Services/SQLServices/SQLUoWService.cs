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
        private DM_MateriaSQLRepository _DM_MateriaSQLRepository;
        private EquipmentConfigurationSQLRepository _EquipmentConfigurationSQLRepository;
        private EquipmentSQLRepository _EquipmentSQLRepository;
        private BufferSQLRepository _BufferSQLRepository;
        private BufferDefinitionSQLRepository _BufferDefinitionSQLRepository;
        private EquipmentGroupConfigurationSQLRepository _EquipmentGroupConfigurationSQLRepository;
        
        public string ConnectionString = @"Data Source=DMKIM\MSSQLSERVER1;Integrated Security=True;Initial Catalog=PBD_Preactor;";
        public SQLUoWService()
        {
        }
        public EquipmentGroupConfigurationSQLRepository EquipmentGroupConfigurationSQLRepository
        {
            get
            {
                if (_EquipmentGroupConfigurationSQLRepository == null)
                    _EquipmentGroupConfigurationSQLRepository = new EquipmentGroupConfigurationSQLRepository(ConnectionString);
                return _EquipmentGroupConfigurationSQLRepository;
            }
        }


        public BufferDefinitionSQLRepository BufferDefinitionSQLRepository
        {
            get
            {
                if (_BufferDefinitionSQLRepository == null)
                    _BufferDefinitionSQLRepository = new BufferDefinitionSQLRepository(ConnectionString);
                return _BufferDefinitionSQLRepository;
            }
        }


        public BufferSQLRepository BufferSQLRepository
        {
            get
            {
                if (_BufferSQLRepository == null)
                    _BufferSQLRepository = new BufferSQLRepository(ConnectionString);
                return _BufferSQLRepository;
            }
        }

        public EquipmentSQLRepository EquipmentSQLRepository
        {
            get
            {
                if (_EquipmentSQLRepository == null)
                    _EquipmentSQLRepository = new EquipmentSQLRepository(ConnectionString);
                return _EquipmentSQLRepository;
            }
        }

        public EquipmentConfigurationSQLRepository EquipmentConfigurationSQLRepository
        {
            get
            {
                if (_EquipmentConfigurationSQLRepository == null)
                    _EquipmentConfigurationSQLRepository = new EquipmentConfigurationSQLRepository(ConnectionString);
                return _EquipmentConfigurationSQLRepository;
            }
        }



        public MateriaSQLRepository MateriaSQLRepository
        {
            get
            {
                if (_MateriaSQLRepository == null)
                    _MateriaSQLRepository = new MateriaSQLRepository(ConnectionString);
                return _MateriaSQLRepository;
            }
        }

        public DM_MateriaSQLRepository DM_MateriaSQLRepository
        {
            get
            {
                if (_DM_MateriaSQLRepository == null)
                    _DM_MateriaSQLRepository = new DM_MateriaSQLRepository(ConnectionString);
                return _DM_MateriaSQLRepository;
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
