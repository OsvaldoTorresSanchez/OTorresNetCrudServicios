using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        WCF.Result GetById(int IdAlumno);

        [OperationContract]
        WCF.Result Add(ML.Usuario usuario);

        [OperationContract]
        WCF.Result Update(ML.Usuario usuario);

        [OperationContract]
        WCF.Result Delete(ML.Usuario usuario);
    }
}
