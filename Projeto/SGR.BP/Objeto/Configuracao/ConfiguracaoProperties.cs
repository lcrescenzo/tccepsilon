using System;
using System.Collections.Generic;
using System.Text;

namespace SGR.BP.Objeto
{
    public partial class Configuracao
    {
        internal int? _idLogin = null;
        private Login _login = null;

        public Login Login
        {
            get
            {
                if (!_idLogin.HasValue)
                    return null;

                if (Util.General.IsNullOrDisposed(_login))
                    _login = new Login(_idLogin.Value, false);
                return _login;
            }
            set
            {
                _idLogin = value.ID;
                _login = value;
            }
        }

    }
}
