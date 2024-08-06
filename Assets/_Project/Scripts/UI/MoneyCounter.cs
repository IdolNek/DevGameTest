using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MoneyCounter: MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyCount;

        // public void Construct(MoneyData money)
        // {
        //     _money = money;
        //     _money.OnMoneyChanged += OnMoneyChanged;
        // }
        //
        // private void OnMoneyChanged() => 
        //     _moneyCount.text = _money.Collected.ToString();
    }
}