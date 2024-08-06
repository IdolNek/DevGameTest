using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    public interface IUIFactory : IService
    {
        void Open(WindowsId windowID);
        void CreateUIRoot();
    }
}