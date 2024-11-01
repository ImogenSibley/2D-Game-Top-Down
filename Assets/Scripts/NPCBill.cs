using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBill : MonoBehaviour
{
    MessageDisplay messageBox;

    void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }
    void MagicCallback(bool answer)
    {
        if (answer)
        {
            // find the stone in the world
            GameObject stone = GameObject.Find("Stone");
            Destroy(stone);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Inventory inv = collision.gameObject.GetComponent<Inventory>();
            bool hasScroll = inv.GetCount("Scroll") > 0;
            bool hasPotion = inv.GetCount("Potion") > 0;
            if (!hasScroll && !hasPotion)
            {
                messageBox.ShowMultilineMessage
                    (
                    "You want to cross the river? The stone has been here many years.\n" +
                    "It is too heavy for any on the island to move. Only magic will move it.\n" +
                    "There is an old lady in the forest who may help, but she will need to be paid"
                    );
            }
            if (hasScroll && !hasPotion)
            {
                messageBox.ShowMultilineMessage
                    (
                    "Ah, you have the scroll but it is useless without quaffing the blue potion.\n " +
                    "You must find the blue potion."
                    );
            }
            else if (hasScroll && hasPotion)
            {
                messageBox.YesNoMessage("Aha, you have the magic to move the stone. Would you like to quaff the potion and read the scroll ? ", MagicCallback);
            }
        }
    }

}
