using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCoin.SolutionCore.ViewModels.Generic
{
    public class ModelStateErrorModelViewModel
    {
        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
