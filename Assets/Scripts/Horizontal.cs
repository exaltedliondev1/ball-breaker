using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MonoBehaviour
{
    public GameObject Lines;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball")
        {
            Lines.SetActive(true);
            Board.Instance.DecreaseHorizontallyHealth(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball")
        {
            Lines.SetActive(false);
        }
    }
}
