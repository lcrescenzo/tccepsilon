using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SGR.BP.Bases
{
    internal interface IDao<T> where T : ObjectBase
    {
        void Incluir(T objeto);
        void Alterar(T objeto);
        void Excluir(T objeto);
        IDataParameterCollection ParametrosIncluir(T objeto);
        IDataParameterCollection ParametrosExcluir(T objeto);
        IDataParameterCollection ParametrosAlterar(T objeto);
    }
}
