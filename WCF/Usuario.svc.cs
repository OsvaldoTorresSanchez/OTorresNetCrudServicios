using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public WCF.Result GetAll()
        {

            ML.Result result = BL.Usuairo.GetAll();

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result GetById(int usuario)
        {
            ML.Result result = BL.Usuairo.GetById(usuario);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuairo.Add(usuario);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuairo.Update(usuario);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public WCF.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuairo.Delete(usuario.IdUsuario);

            WCF.Result resultSL = new WCF.Result();
            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.ex = result.ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

    }
}
