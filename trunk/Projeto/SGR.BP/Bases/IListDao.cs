using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SGR.BP.Bases
{
    interface IListDao<T> where T : ObjectBase
    {
        void Incluir(T objeto, IDbConnection pConnection);
        void Alterar(T objeto, IDbConnection pConnection);
        void Excluir(T objeto, IDbConnection pConnection);
    }
}
