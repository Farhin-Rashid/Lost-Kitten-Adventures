using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public Text coinsText;
    private int coins = 0;

    void Awake()
    {
        Instance = this;
    }   

    void Start()
    {
        UpdateCoinsText();
    }

    public void AddCoin()
    {
        coins += 1;
        UpdateCoinsText();
    }

    void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins.ToString();
    }
}
