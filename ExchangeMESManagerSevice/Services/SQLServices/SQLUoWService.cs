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
        private MaterialSQLRepository _MateriaSQLRepository;
        private DM_MateriaSQLRepository _DM_MateriaSQLRepository;
        private EquipmentConfigurationSQLRepository _EquipmentConfigurationSQLRepository;
        private EquipmentSQLRepository _EquipmentSQLRepository;
        private BufferSQLRepository _BufferSQLRepository;
        private BufferDefinitionSQLRepository _BufferDefinitionSQLRepository;
        private EquipmentGroupConfigurationSQLRepository _EquipmentGroupConfigurationSQLRepository;
        private OperationSQLRepository _OperationSQLRepository;
        private AsPlannedBOPSQLRepository _AsPlannedBOPSQLRepository;
        private ProcessesSQLRepository _ProcessesSQLRepository;
        private ProcessToOperationLinkSQLRepository _ProcessToOperationLinkSQLRepository;
        private MaterialSpecificationSQLRepository _MaterialSpecificationSQLRepository;
        private EquipmentSpecificationSQLRepository _EquipmentSpecificationSQLRepository;
        private WOSQLRepository _WOSQLRepository;
        
        public string ConnectionString = @"Data Source=WIN-RI0FKDRK5SJ;Integrated Security=True;Initial Catalog=pbdstock;";
        public SQLUoWService()
        {
        }
        public WOSQLRepository WOSQLRepository
        {
            get
            {
                if (_WOSQLRepository == null)
                    _WOSQLRepository = new WOSQLRepository(ConnectionString);
                return _WOSQLRepository;
            }
        }

        public EquipmentSpecificationSQLRepository EquipmentSpecificationSQLRepository
        {
            get
            {
                if (_EquipmentSpecificationSQLRepository == null)
                    _EquipmentSpecificationSQLRepository = new EquipmentSpecificationSQLRepository(ConnectionString);
                return _EquipmentSpecificationSQLRepository;
            }
        }
        public MaterialSpecificationSQLRepository MaterialSpecificationSQLRepository
        {
            get
            {
                if (_MaterialSpecificationSQLRepository == null)
                    _MaterialSpecificationSQLRepository = new MaterialSpecificationSQLRepository(ConnectionString);
                return _MaterialSpecificationSQLRepository;
            }
        }

        public ProcessToOperationLinkSQLRepository ProcessToOperationLinkSQLRepository
        {
            get
            {
                if (_ProcessToOperationLinkSQLRepository == null)
                    _ProcessToOperationLinkSQLRepository = new ProcessToOperationLinkSQLRepository(ConnectionString);
                return _ProcessToOperationLinkSQLRepository;
            }
        }

        public ProcessesSQLRepository ProcessesSQLRepository
        {
            get
            {
                if (_ProcessesSQLRepository == null)
                    _ProcessesSQLRepository = new ProcessesSQLRepository(ConnectionString);
                return _ProcessesSQLRepository;
            }
        }


        public AsPlannedBOPSQLRepository AsPlannedBOPSQLRepository
        {
            get
            {
                if (_AsPlannedBOPSQLRepository == null)
                    _AsPlannedBOPSQLRepository = new AsPlannedBOPSQLRepository(ConnectionString);
                return _AsPlannedBOPSQLRepository;
            }
        }

        public OperationSQLRepository OperationSQLRepository
        {
            get
            {
                if (_OperationSQLRepository == null)
                    _OperationSQLRepository = new OperationSQLRepository(ConnectionString);
                return _OperationSQLRepository;
            }
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



        public MaterialSQLRepository MateriaSQLRepository
        {
            get
            {
                if (_MateriaSQLRepository == null)
                    _MateriaSQLRepository = new MaterialSQLRepository(ConnectionString);
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
