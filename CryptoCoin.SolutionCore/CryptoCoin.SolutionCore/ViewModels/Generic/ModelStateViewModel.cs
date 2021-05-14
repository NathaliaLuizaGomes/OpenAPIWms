using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCoin.SolutionCore.ViewModels.Generic
{
    public class ModelStateViewModel
    {
        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsValid { get; set; }

        public string[] Keys { get; set; }

        public ModelStateErrorViewModel[] Values { get; set; }

    }
}
