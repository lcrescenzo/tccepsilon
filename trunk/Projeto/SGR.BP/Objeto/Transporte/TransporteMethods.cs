using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto
{
    public partial class Transporte : ObjectBase
    {
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            base.ID = Convert.ToInt32(reader["idTransporte"]);
            this.Data = (DateTime)reader["dataSaida"];
            this.LoginUltimaAlteracao = new Login((int)reader["idUsuario"], this.CarregarTotal);
            this.Movimentacao = new Movimentacao((int)reader["idMovimentacao"], this.CarregarTotal);
            this.Quantidade = Convert.ToDouble(reader["qtdSaida"]);
            this.Transportadora = reader["transportadora"].ToString();
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

    }
}
