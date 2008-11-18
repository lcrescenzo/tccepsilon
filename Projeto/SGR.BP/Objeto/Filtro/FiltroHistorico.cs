using System;
using System.Collections.Generic;
using System.Text;
using SGR.BP.Bases;

namespace SGR.BP.Objeto.Filtro
{
    [Serializable]
    public class FiltroHistorico : IFiltro
    {
        private int? _idUsuario;

        public int? Usuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private int? _idEntidade;

        public int? Entidade
        {
            get { return _idEntidade; }
            set { _idEntidade = value; }
        }

        private int? _idManutencao;

        public int? Manutencao
        {
            get { return _idManutencao; }
            set { _idManutencao = value; }
        }

        private DateTime? _dataInicio;

        public DateTime? DataInicio
        {
            get { return _dataInicio; }
            set { _dataInicio = value; }
        }

        private DateTime? _dataFim;

        public DateTime? DataFim
        {
            get { return _dataFim; }
            set { _dataFim = value; }
        }

    }
}
