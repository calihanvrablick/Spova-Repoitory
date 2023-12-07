using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/01/2023]
 * [Handles the functionality of the shop buttons.]
 */
public class ShopButton : MonoBehaviour
{
    private float buyCooldown = 1f;


    // the upgrades for the player
    public int healing;
    public int damageUp;
    public int healthUp;
    public int speedUp;
    public bool secretKey;


    public int cost;
    public Boolean onCooldown = false;


    /// <summary>
    /// processes the button's information and acts accordingly
    /// if the button is on cooldown, don't do anything
    /// if the player has enough money, buy the item and set the button on a 1 second cooldown
    /// if the player does not have money, set the button on cooldown and turn the button red temporarily
    /// </summary>
    /// <param name="buttonPressed"></param>
    public int OnPurchase(int playerCoins, GameObject buttonPressed)
    {
        print("pressed button");
        Boolean onCooldown = buttonPressed.GetComponent<ShopButton>().onCooldown;

        if (onCooldown == true)
            return 0;

        int buttonCost = buttonPressed.GetComponent<ShopButton>().cost;

        if (playerCoins >= buttonCost)
        {
            StartCoroutine(OnSuccess(buttonPressed));
            return buttonCost;
        }
        else
        {
            StartCoroutine(OnError(buttonPressed));
            return 0;
        }
    }





    /// <summary>
    /// called when the player does not have the funds to purchase the goods.
    /// turns the button red until the buttoncooldown is finished.
    /// </summary>
    /// <param name="buttonPressed"></param>
    /// <returns></returns>
    IEnumerator OnError(GameObject buttonPressed)
    {
        // setup the materials array because unity is a jag
        Renderer renderer = buttonPressed.GetComponent<Renderer>();

        buttonPressed.GetComponent<ShopButton>().onCooldown = true;
        renderer.material.SetColor("_Color", Color.red);

        yield return new WaitForSeconds(buyCooldown);
        buttonPressed.GetComponent<ShopButton>().onCooldown = false;
        renderer.material.SetColor("_Color", Color.green);
    }





    /// <summary>
    /// called when the player successfully buys the item.
    /// disappears and reappears after the buttonCooldown is finished.
    /// </summary>
    /// <param name="buttonPressed"></param>
    /// <returns></returns>
    IEnumerator OnSuccess(GameObject buttonPressed)
    {
        buttonPressed.GetComponent<ShopButton>().onCooldown = true;
        buttonPressed.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(buyCooldown);
        buttonPressed.GetComponent<ShopButton>().onCooldown = false;
        buttonPressed.GetComponent<MeshRenderer>().enabled = true;
    }
}
