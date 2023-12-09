using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [11/13/2023]
 * [Handles all the scores and lives gui in the game scene.]
 */
public class UIManager : MonoBehaviour
{
    public GameObject playerObject;
    public TMP_Text healthText;
    public TMP_Text coinsText;

    private PlayerHandler playerInfo;

    // Start is called before the first frame update
    private void Start()
    {
        playerInfo = playerObject.GetComponent<PlayerHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.text = "Health: " + playerInfo.health + " / " + playerInfo.maxHealth;
        coinsText.text = "Coins: " + playerInfo.Coins;
        
    }
}
