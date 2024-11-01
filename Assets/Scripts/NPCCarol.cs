using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UIElements;

public class NPCCarol : MonoBehaviour
{
    MessageDisplay messageBox;
    Inventory inventory;

    void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory = collision.gameObject.GetComponent<Inventory>();
            bool hasGold = inventory.GetCount("Gold Ring") > 0;
            if (hasGold)
            {
                messageBox.YesNoMessage("I can sell you a powerful scroll for that gold ring. \nDo you want to buy it? ", BuyCallback);
            }
            else
            {
                messageBox.ShowMultilineMessage("I have powerful magic to sell, but you have no gold!");
            }
        }
    }

    void BuyCallback(bool answer)
    {
        if (answer) 
        {
            inventory.Remove("Gold Ring", -1);
            inventory.Add("Scroll", 1);
            messageBox.ShowMultilineMessage
                (
                "Good luck. Remember you must quaff a blue potion before reading the scroll\n" +
                "I have none but I remember leaving some near the forest edge"
                );
        }
        else //if player says no
        {
            messageBox.ShowMultilineMessage
             (
             "I guess you'll never cross the river.\n" +
             "Good luck then."
             );
        }
    }

}
