using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ServiceModel; //for MEF

namespace OrderStacker.Business.Managers
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            //tell MEF to satisfy imports
            //It will resolve anything that's tagged with Import in This class
            if (ObjectBase.Container != null)
            {
                ObjectBase.Container.SatisfyImportsOnce(this);
            }
        }

        //protected: can only be called from within the same assembly
        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (FaultException ex)  //Make sure the fault we caught due to null falls in here, not the last catch clause
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        //protected: can only be called from within the same assembly
        protected void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            try
            {
                codeToExecute.Invoke();
            }
            catch (FaultException ex)  //Make sure the fault we caught due to null falls in here, not the last catch clause
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

    }
}
