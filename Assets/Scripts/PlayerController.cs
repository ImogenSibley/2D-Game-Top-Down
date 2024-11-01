using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Transform inventoryUI;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float speed = 4.0f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),
       Input.GetAxis("Vertical")) * speed;
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", rb.velocity.x);
        animator.SetFloat("ySpeed", rb.velocity.y);
        if (rb.velocity.magnitude < 0.01)
            animator.speed = 0.0f;
        else
            animator.speed = 1.0f;

        if (Input.GetKeyDown("i"))
        {
            if (inventoryUI.gameObject.activeSelf == false)
            {
                // set the text, and show
                string inv = GetComponent<Inventory>().GetInventoryString();
                inventoryUI.GetChild(1).GetComponent<TextMeshProUGUI>().text = inv;
                inventoryUI.gameObject.SetActive(true);
            }
            else
            {
                // hide the inventory
                inventoryUI.gameObject.SetActive(false);
            }
        }
    }
}
