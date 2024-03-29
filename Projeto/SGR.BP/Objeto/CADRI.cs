using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;
using SGR.BP.Objetos;
using SGR.BP.Dao;

namespace SGR.BP.Objeto
{
    public class CADRI : ObjectBase
    {
        #region Construtores
        public CADRI()
        { 
        }

        public CADRI(int id)
        {
            this.ID = id;
            this.PreencheObjeto(Dao.Carregar(ID));
        }
        #endregion

        #region Atributos
        private List<Residuo> _residuos;
        private int _numero;
        private string _destino;
        private double _quantidade;
        private int _oi;
        private DateTime _validade;
        #endregion

        #region Propriedades
        public List<Residuo> Residuos
        {
            get 
            { 
                if(Util.General.IsNullOrDisposed(_residuos))
                    Dao.CarregarResiduos(this);

                return _residuos; 
            }
            set 
            { 
                _residuos = value; 
            }
        }

        public int Numero
        {
            get 
            { 
                return _numero; 
            }
            set 
            { 
                _numero = value; 
            }
        }
        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }
        public double Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public int OI
        {
            get { return _oi; }
            set { _oi = value; }
        }
        public DateTime Validade
        {
            get { return _validade; }
            set { _validade = value; }
        }

        #endregion

        #region Data

        internal override void PreencheObjeto(System.Data.IDataReader reader)
        {
            this.Destino = reader[""].ToString();
            this.Numero = Convert.ToInt32(reader[""]);
            this.OI = Convert.ToInt32(reader[""]);
            this.Quantidade = Convert.ToDouble(reader[""]);
            this.Validade = Convert.ToDateTime(reader[""]);
        }

        DaoCADRI Dao
        {
            get
            {
                if (_dao == null)
                    _dao = (IDao<ObjectBase>)(new DaoCADRI());

                return (DaoCADRI)_dao;
            }
        }
        #endregion
    }
}
