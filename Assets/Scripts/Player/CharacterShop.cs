using TMPro;
using UnityEngine;

public class CharacterShop : MonoBehaviourSingleton<CharacterShop>
{
    [SerializeField] public Character[] _characters;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterPrice;
    [SerializeField] private TextMeshProUGUI playerMoneyText;
    [SerializeField] private GameObject[] _buyButtons;
    [SerializeField] private int _playerMoney;
    private int _currentIndex;

    private void OnEnable()
    {
        _currentIndex = 0;
        int lenght = _characters.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);

            if (PlayerPrefs.GetInt(_characters[i].name) == 1)
                _characters[i].isBought = true;
            else
                _characters[i].isBought = false;
        }
        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;
        
        _playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        playerMoneyText.text = _playerMoney.ToString();
        
        if (_characters[_currentIndex].isBought)
        {
            _buyButtons[0].SetActive(false);
            _buyButtons[1].SetActive(true);
        }
        
        if (_characters[_currentIndex].isSelected)
        {
            _buyButtons[1].GetComponentInChildren<TextMeshProUGUI>().SetText("Selected");
        }
    }

    public void nextCharacter()
    {
        int lenght = _characters.Length;
        _currentIndex++;
        if (_currentIndex >= lenght)
            _currentIndex = 0;

        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);
        }

        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;

        if (_characters[_currentIndex].isBought)
        {
            _buyButtons[0].SetActive(false);
            _buyButtons[1].SetActive(true);
        }
        else
        {
            _buyButtons[0].SetActive(true);
            _buyButtons[1].SetActive(false);
        }

        if (_characters[_currentIndex].isSelected)
        {
            _buyButtons[1].GetComponent<TextMeshProUGUI>().SetText("Selected");
        }
    }

    public void previousCharacter()
    {
        int lenght = _characters.Length;
        _currentIndex--;
        if (_currentIndex < 0)
            _currentIndex = lenght - 1;

        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex)
                _characters[i].character.SetActive(true);
            else
                _characters[i].character.SetActive(false);
        }
        
        characterName.text = _characters[_currentIndex].name;
        characterPrice.text = "$ : " + _characters[_currentIndex].price;
        
        if (_characters[_currentIndex].isBought)
        {
            _buyButtons[0].SetActive(false);
            _buyButtons[1].SetActive(true);
        }
        else
        {
            _buyButtons[0].SetActive(true);
            _buyButtons[1].SetActive(false);
        }
        
        if (_characters[_currentIndex].isSelected)
        {
            _buyButtons[1].GetComponentInChildren<TextMeshProUGUI>().SetText("Selected");
        }
        
    }

    public void BuyCharacter()
    {
        if (_playerMoney >= _characters[_currentIndex].price)
        {
            _characters[_currentIndex].isBought = true;
            _playerMoney -= (int)_characters[_currentIndex].price;
            PlayerPrefs.SetInt(_characters[_currentIndex].name,1);
            PlayerPrefs.SetInt("PlayerMoney",_playerMoney);
            PlayerPrefs.Save();
            playerMoneyText.text = _playerMoney.ToString();
            _buyButtons[0].SetActive(false);
            _buyButtons[1].SetActive(true);

            switch (_currentIndex)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 6:
                case 7:
                case 8:
                    GooglePlayManager.UnlockAchievemt(GPGSIds.achievement_axe_to_meet_you);
                    break;
                case 9:
                case 10:
                    GooglePlayManager.UnlockAchievemt(GPGSIds.achievement_the_mad_king);
                    break;
                case 3:
                    break;
                case 4:
                case 5:
                case 11:
                case 12:
                case 13:
                case 14:
                    GooglePlayManager.UnlockAchievemt(GPGSIds.achievement_let_the_magic_begin);
                    break;
            }
        }

        int lenght = _characters.Length;
        int charactersBuyed = 0;
        for (int i = 0; i < lenght; i++)
        {
            if (_characters[i].isBought)
                charactersBuyed++;
        }
        
        if (charactersBuyed == lenght -1)
            GooglePlayManager.UnlockAchievemt(GPGSIds.achievement_unite_the_kingdom);
        
        AnalyticsManager.instance.RecordPurchaseEvent( _characters[_currentIndex].name, _characters[_currentIndex].price,_characters[_currentIndex].index);
    }

    public void SelecCharacter()
    {
        int lenght = _characters.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (i == _currentIndex && _characters[_currentIndex].isBought)
            {
                _characters[_currentIndex].isSelected = true;
                PlayerPrefs.SetInt("PlayerCharacter",_currentIndex);
                _buyButtons[1].GetComponentInChildren<TextMeshProUGUI>().SetText("Selected");
            }
            else
                _characters[_currentIndex].isSelected = false;
        }
    }
}