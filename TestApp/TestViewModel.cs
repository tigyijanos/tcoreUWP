using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCore.UniversalApp.Interfaces.Common;

namespace TestApp
{
    public class TestViewModel : ITCoreViewModel
    {
        public async Task InitializeViewModel()
        {
            await Task.Delay(1);
        }
    }
}
