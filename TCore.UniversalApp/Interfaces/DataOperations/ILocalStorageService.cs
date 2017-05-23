using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCore.UniversalApp.Interfaces.DataOperations
{
    interface ILocalStorageService
    {
        void Insert<T>(Enum key, T value);

        T Get<T>(Enum key);

        void InValidate(Enum key);

        void CleanLocalStorage();

    }
}
