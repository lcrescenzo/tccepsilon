using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public partial class Movimentacao : ObjectBase
    {
        public static Movimentacao Carregar(CADRI cadri, Residuo residuo)
        {
            return DaoMovimentacao.Carregar(cadri, residuo);
        }

        /// <summary>
        /// Carrega ultimos transportes
        /// </summary>
        /// <param name="quantidade">Quantidades dos ultimos transportes</param>
        /// <returns></returns>
        public List<Transporte> CarregarUltimosTransportes(int quantidade)
        {
            return Dao.CarregarUltimosTransportes(this, quantidade);
        }

        

        #region Data
        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            base.ID = Convert.ToInt32(reader["idMovimentacao"]);
            this._cadri = new CADRI((int)reader["idCadri"], this.CarregarTotal);
            this._login = new Login((int)reader["idUsuario"], this.CarregarTotal);
            this._residuo = new Residuo((int)reader["idResiduo"], this.CarregarTotal);
        }

        public override void Inserir()
        {
            Dao.Incluir(this);
        }

        [Obsolete("Este método não foi implementado, não utilizá-lo", true)]
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
