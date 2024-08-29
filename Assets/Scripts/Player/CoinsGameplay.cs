using TMPro;
using UnityEngine;

public class CoinsGameplay : MonoBehaviour
{ 
    [SerializeField] private PlayerController _player;
    [SerializeField] private TextMeshProUGUI _coinsLabel;
    
    void Update()
    {
        _coinsLabel.text = _player.GetPlayerMoney().ToString();
    }
}
