using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        
        public void SetScore(float score) => 
            _scoreText.text = score.ToString();
    }
}