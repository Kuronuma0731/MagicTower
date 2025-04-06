using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] public Article articleDoor;
    [SerializeField] public Animator doorAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Charaters")
        {
            doorAnimation.SetBool("OpenDoor", true);
            //KeyMeanager keyMeanager = GameObject.Find("KeyMeanager").GetComponent<KeyMeanager>();
            //keyMeanager?.AddArticle(itemName);
            //Destroy(gameObject);
        }
    }
    void CloseDoor()
    {
        Destroy(gameObject);
    }
}
