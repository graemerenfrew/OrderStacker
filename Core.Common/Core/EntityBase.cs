using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core.Common.Core
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {   //Allow objects that are built on EntityBase to auto extend
        //and store the extensiondata somewhere.  Allows a degree
        //of future proofing.
        public ExtensionDataObject ExtensionData { get; set; }

        //TODO Always want to have this in my records, for audit.  Maybe I should make it GUID
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
 
    }
}
