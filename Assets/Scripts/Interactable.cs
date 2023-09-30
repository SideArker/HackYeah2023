using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent onInteract;
    [SerializeField] UnityEvent onMouseExit;
    [SerializeField] UnityEvent onMouseEnter;
    bool isInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onMouseEnter.Invoke();
        //print("on range");
        isInRange = true;
        //Show "E to interact"
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onMouseEnter.Invoke();
        //print("out of range");
        isInRange=false;
        //Hide "E to interact"
    }
    public void Interact()
    {
        //print("click");
        if (isInRange)
        {
            onInteract.Invoke();
            print("OPEEEEEEEEEEEN");
        }
    }
}
