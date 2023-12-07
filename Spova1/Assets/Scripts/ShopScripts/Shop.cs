using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/01/2023]
 * [Randomizes the item displayed on the shop when spawned.]
 */
public class Shop : MonoBehaviour
{
    private string[] itemNames = new string[5] {
        "Damage Upgrade", 
        "Health Upgrade", 
        "Healing", 
        "Speed Boost",
        "Secret Key",
    };



    /// <summary>
    /// randomly assigns items to be sold at each vendor
    /// </summary>
    private void Start()
    {
        /*testing to see how i can change each sign and button cost
         * 
         * 
        TextMeshPro thisName = transform.Find("Items").transform.Find("Item1").transform.Find("Sign").transform.Find("Name").gameObject.GetComponent<TextMeshPro>();
        TextMeshPro thisCost = transform.Find("Items").transform.Find("Item1").transform.Find("Sign").transform.Find("Cost").gameObject.GetComponent<TextMeshPro>();
        GameObject thisButton = transform.Find("Items").transform.Find("Item1").transform.Find("Button").gameObject;

        thisName.text = "helt upgrad + 2";
        thisCost.text = "cost - 1";
        thisButton.GetComponent<ShopButton>().cost = 1;
        */

        for (int i = 0; i < 4; i ++)
        {
            string thisItemName = "Item" + (i + 1);
            TextMeshPro thisName = transform.Find("Items").transform.Find(thisItemName).transform.Find("Sign").transform.Find("Name").gameObject.GetComponent<TextMeshPro>();
            TextMeshPro thisCost = transform.Find("Items").transform.Find(thisItemName).transform.Find("Sign").transform.Find("Cost").gameObject.GetComponent<TextMeshPro>();
            GameObject thisButton = transform.Find("Items").transform.Find(thisItemName).transform.Find("Button").gameObject;


            int number = UnityEngine.Random.Range(1, 101);
            print(number);


            if (number == 100)
            {
                // secret key
                thisName.text = itemNames[4];
                thisCost.text = "10 Coins";
                thisButton.GetComponent<ShopButton>().cost = 10;
                thisButton.GetComponent<ShopButton>().secretKey = true;
            }
            else if (number > 75)
            {
                // speed boost
                int upgradeAmount = UnityEngine.Random.Range(2, 5);
                int costAmount = UnityEngine.Random.Range(2, 5);

                thisName.text = "+ " + upgradeAmount + " Speed";
                thisCost.text = costAmount + " Coins";
                thisButton.GetComponent<ShopButton>().cost = costAmount;
                thisButton.GetComponent<ShopButton>().speedUp = upgradeAmount;
            }
            else if (number > 50)
            {
                // healing
                int healingAmount = UnityEngine.Random.Range(50,101);
                int costAmount = UnityEngine.Random.Range(1,3);

                thisName.text = "Heal " + healingAmount + " health";
                thisCost.text = costAmount + " Coins";
                thisButton.GetComponent<ShopButton>().cost = costAmount;
                thisButton.GetComponent<ShopButton>().healing = healingAmount;
            }
            else if (number > 25)
            {
                // health upgrade
                int healthAmount = UnityEngine.Random.Range(25, 100);
                int costAmount = UnityEngine.Random.Range(3,6);

                thisName.text = "Gain " + healthAmount + " health";
                thisCost.text = costAmount + " Coins";
                thisButton.GetComponent<ShopButton>().cost = costAmount;
                thisButton.GetComponent<ShopButton>().healthUp = healthAmount;
            }
            else
            {
                // damage upgrade
                int damageAmount = UnityEngine.Random.Range(1,5);
                int costAmount = UnityEngine.Random.Range(1,5);

                thisName.text = "Gain " + damageAmount + " damage";
                thisCost.text = costAmount + " Coins";
                thisButton.GetComponent<ShopButton>().cost = costAmount;
                thisButton.GetComponent<ShopButton>().damageUp = damageAmount;
            }
        }
    }
}
