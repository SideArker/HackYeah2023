using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{
    public bool onTrig = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("iseeyou");
        onTrig = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTrig = false;
    }

}
