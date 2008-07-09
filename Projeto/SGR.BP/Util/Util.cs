using System;
using System.Collections.Generic;
using System.Text;

namespace SGR.BP.Util
{
    public class General
    {
        public static bool IsNullOrDisposed(object objeto)
        {
            if(objeto == null)
                return true;
            object isDisposed = objeto.GetType().GetField("m_fDisposed", System.Reflection.BindingFlags.NonPublic).GetValue(objeto);
            if (isDisposed != null)
                if ((bool)isDisposed)
                    return true;

            return false;
                 
        }
    }
}
