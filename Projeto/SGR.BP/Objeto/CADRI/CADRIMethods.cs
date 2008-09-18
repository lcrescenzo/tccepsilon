using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto
{
    public partial class CADRI : ObjectBase
    {
        public static List<CADRI> Lista()
        {
            return new List<CADRI>();
        }

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.Destino = reader["destino"].ToString();
            this.Numero = Convert.ToInt32(reader["numero"]);
            this.OI = Convert.ToInt32(reader["OI"]);
            this.Quantidade = Convert.ToDouble(reader["quantidade"]);
            this.Validade = Convert.ToDateTime(reader["validade"]);
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
