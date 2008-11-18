using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objeto.Filtro;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Historico : ObjectBase
    {
        public static List<Historico> Lista(FiltroHistorico filtro)
        {
            return DaoHistorico.Lista(filtro);
        }

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.ID = (int)reader["idHistorico"];
            this.Login = reader["login"].ToString();
            this.Data = Convert.ToDateTime(reader["dataAlteracao"]);
            this.Entidade = reader["entidade"].ToString();
            this.IdMantido = (int)reader["idmantido"];
            this.Manutencao = reader["manutencao"].ToString();
        }

        public override void Inserir()
        {
            Dao.Incluir(this);
        }

        public override void Alterar()
        {
            Dao.Alterar(this);
        }

        public override void Excluir()
        {
            Dao.Excluir(this);
        }

        #endregion
    }
}
