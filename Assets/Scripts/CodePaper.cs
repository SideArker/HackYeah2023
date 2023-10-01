using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodePaper : MonoBehaviour
{

    [SerializeField] UnityEvent openCode;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            openCode.Invoke();
        }
    }
}
