using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application
{
    public interface IOutputPort<in TCasoDeUsoResponse>
    {
        void Handler(TCasoDeUsoResponse response);
    }
}
