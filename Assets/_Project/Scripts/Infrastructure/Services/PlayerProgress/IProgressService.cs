
namespace Assets.Scripts.Infrastructure.Services.PlayerProgress
{
    public interface IProgressService : IService
    {
        // MoneyData Money { get; set; }
        int CurrentLevel { get; }
        int CurrrentScore { get; }
    }
}