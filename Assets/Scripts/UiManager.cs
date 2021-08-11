using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text coinText;
    public Text textMessage;
    public Text healthText;

    private void Start()
    {
        textMessage.text = "";
        healthText.text = "Health: 5";
        coinText.text = "Coins: 0";
    }

    public void Message(string message)
    {
        textMessage.text = message.ToString();
    }

    public void AddCoins(int coins)
    {
        coinText.text = "Coins: " + coins.ToString();
    }

    public void HealthCount(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }
}
