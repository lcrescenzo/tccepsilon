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
        IDataReader Carregar(int pId);
        List<IDataParameter> ParametrosIncluir(T objeto);
        List<IDataParameter> ParametrosExcluir(T objeto);
        List<IDataParameter> ParametrosAlterar(T objeto);
    }
}
