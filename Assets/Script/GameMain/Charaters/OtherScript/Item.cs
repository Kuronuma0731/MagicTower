using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Article itemName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Charaters")
        {
            KeyMeanager keyMeanager = GameObject.Find("KeyMeanager").GetComponent<KeyMeanager>();
            keyMeanager?.AddArticle(itemName);
            Destroy(gameObject);
        }
    }
}