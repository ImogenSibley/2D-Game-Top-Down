using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJill : MonoBehaviour
{
    MessageDisplay messageBox;
    // Start is called before the first frame update
    void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            messageBox.ShowMultilineMessage("Hi, I'm Jill! \nI live here in the town.\nHave you been here long? \nI ran out of things to say.");
        }
    }

}
