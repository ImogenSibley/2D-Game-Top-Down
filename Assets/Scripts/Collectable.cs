using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //when object collides with player
        {
            collision.gameObject.GetComponent<Inventory>().Add(itemName, 1); //add to inventory
            MessageDisplay display = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
            display.ShowMessage("You picked up a " + itemName + ".", 2.0f);
            Destroy(gameObject); //delete object
        }
    }
}
