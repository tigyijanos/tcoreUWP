using System.Threading.Tasks;

namespace TCore.UniversalApp.Interfaces.Common
{
    public interface ITCoreViewModel
    {
        Task InitializeViewModel();

        /// <summary>
        /// multiple views single viewmodel
        /// </summary>
        System.Enum ViewKey { get; set; }
    }
}
