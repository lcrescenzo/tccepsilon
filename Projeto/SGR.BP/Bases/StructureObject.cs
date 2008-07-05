using System;
using System.Collections.Generic;
using System.Text;

namespace SGR.BP.Bases
{
    internal interface IDataObject<TypeDao>
    {
        TypeDao Dao { get; set; }
    }
}
