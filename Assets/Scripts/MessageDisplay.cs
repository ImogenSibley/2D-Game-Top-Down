using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MessageDisplay : MonoBehaviour
{
    public Transform messageUI;
    TextMeshProUGUI textObject; 

    // Start is called before the first frame update
    void Start()
    {
        textObject = messageUI.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    IEnumerator DoMessage(string message, float seconds)
    {
        messageUI.gameObject.SetActive(true); //makes text canvas active
        textObject.text = message; //sets message
        yield return new WaitForSeconds(seconds);
        messageUI.gameObject.SetActive(false); //makes text canvas inactive
    }

    IEnumerator DoMultilineMessage(string message)
    {
        messageUI.gameObject.SetActive(true); //make text canvas active
        string[] lines = message.Split("\n"); //split string function to split message into lines based on presence of end of line character
        foreach (string line in lines) 
        {
            textObject.text = line; 
            yield return null;
            while (true) 
            {
                if (Input.GetButtonDown("Fire1")) //while there is more text, move to next line if fire 1 button is being pressed
                    break;
                yield return null;
            }
        }
        messageUI.gameObject.SetActive(false); //set inactive when no more text
    }
    
    public void ShowMessage(string message, float seconds) //uses a co-routine to show the message
    {
        StartCoroutine(DoMessage(message, seconds)); 
    }

    public void ShowMultilineMessage(string message)
    {
        StartCoroutine(DoMultilineMessage(message));
    }

}
