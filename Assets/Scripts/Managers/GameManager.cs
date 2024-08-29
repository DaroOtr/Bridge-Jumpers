using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BridgeManager _bridgeManager;
    [SerializeField] private WatterBehaviour _watterBehaviour;
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _scoreDisplayLose;
    [SerializeField] private TextMeshProUGUI _scoreDisplayPause;
    [SerializeField] private TextMeshProUGUI _HighscoreDisplayLose;
    [SerializeField] private TextMeshProUGUI _HighscoreDisplayPause;
    [SerializeField] private GameObject _spikes;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int playerHighScore;
    [SerializeField] private int minScoreToSpawn;
    [SerializeField] private int maxDeaths = 5;
    [SerializeField] private int currentDeaths;
    
    public static GameManager instance;
    
    private int _selectedCharacter;
    private int colectedCoins;
    private bool isGamePaused;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        
        if (_playerController == null)
            _playerController = FindObjectOfType<PlayerController>();

        _playerController.OnPlayerDead += OnPlayerDead;
        _scorePanel.SetActive(true);
        _pausePanel.SetActive(false);
        _losePanel.SetActive(false);
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

        playerHighScore = PlayerPrefs.GetInt("PlayerHighScore");
        
        if (!PlayerPrefs.HasKey("RunTutorial"))
            PlayerPrefs.SetInt("RunTutorial",1);

        if (PlayerPrefs.HasKey("CurrentDeaths"))
            currentDeaths = PlayerPrefs.GetInt("CurrentDeaths");
        else
            currentDeaths = 0;
        
        SoundManager.Instance.PlayGameplayMusic();

    }

    private void OnPlayerDead()
    {
        currentDeaths++;
        if (currentDeaths >= maxDeaths)
        {
            UnityAdsManager.Instance.ShowNonRewardedAd();
            currentDeaths = 0;
        }

        AnalyticsManager.instance.RecordHighScoreEvent(playerHighScore,_playerController.GetCharacterName());
            
        _bridgeManager.canSpawn = false;
        _watterBehaviour._canMove = false;
        _scorePanel.SetActive(false);
        _pausePanel.SetActive(false);
        _losePanel.SetActive(true);
        _scoreDisplayLose.text = "Player Score : " + _playerController.GetPlayerScore();
        _HighscoreDisplayLose.text = "High Score : " + playerHighScore;
        
        PlayerPrefs.SetInt("CurrentDeaths",currentDeaths);
    }

    public void ToglePause()
    {
        if (isGamePaused)
        {
            _scorePanel.SetActive(true);
            _pausePanel.SetActive(false);
            _losePanel.SetActive(false);
            isGamePaused = false;
            _bridgeManager.canSpawn = true;
            _watterBehaviour._canMove = true;
            
            _scoreDisplayPause.text = "Player Score : " + _playerController.GetPlayerScore();
            _HighscoreDisplayPause.text = "High Score : " + playerHighScore;
        }
        else
        {
            _scorePanel.SetActive(false);
            _pausePanel.SetActive(true);
            _losePanel.SetActive(false);
            isGamePaused = true;
            _bridgeManager.canSpawn = false;
            _watterBehaviour._canMove = false;
            
            _scoreDisplayPause.text = "Player Score : " + _playerController.GetPlayerScore();
            _HighscoreDisplayPause.text = "High Score : " + playerHighScore;
        }
    }

    public void AddScore(int value)
    {
        _playerController.AddPlayerScore(value);
        _scoreDisplay.text = _playerController.GetPlayerScore().ToString();

        if (_playerController.GetPlayerScore() >= minScoreToSpawn)
            _spikes.SetActive(true);
    }

    public void AddCoins(int value)
    {
        _playerController.AddPlayerMoney(value);
        colectedCoins += value;
    }

    public void AddRewardCoins()
    {
        UnityAdsManager.Instance.ShowRewardedAd();
        int rewardCoins = colectedCoins * 2;
        AddCoins(rewardCoins);
    }

    public void SetPlayerHighScore(int value)
    {
        if (value > playerHighScore)
            playerHighScore = value;
        PlayerPrefs.SetInt("PlayerHighScore", playerHighScore);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        if (_playerController != null)
            _playerController.OnPlayerDead -= OnPlayerDead;
    }
}