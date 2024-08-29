using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int _maxScore;
    private GameObject _playerVisual;
    private bool _loadedGameplayScene;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void WriteSaveFile()
    {
        
    }
}
