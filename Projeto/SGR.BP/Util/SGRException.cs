using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace SGR.BP.Util
{
    public class SGRException : Exception
    {
        public SGRException()
            : base()
        { }

        public SGRException(string mensagem)
            : base(mensagem)
        { }
    }

    public class SGRInformacaoException : SGRException 
    {
        public SGRInformacaoException()
            : base()
        { }

        public SGRInformacaoException(string mensagem)
            : base(mensagem)
        { }
    }
    public class SGRErroException : SGRException 
    {
        public SGRErroException()
            : base()
        { }

        public SGRErroException(string mensagem)
            : base(mensagem)
        { }
    }
    public class SGRAlertaException : SGRException 
    {
        public SGRAlertaException()
            : base()
        { }

        public SGRAlertaException(string mensagem)
            : base(mensagem)
        { }
    }
    public class SGRConfirmacaoException : SGRException 
    {
        public SGRConfirmacaoException()
            : base()
        { }

        public SGRConfirmacaoException(string mensagem)
            : base(mensagem)
        { }
    }
}