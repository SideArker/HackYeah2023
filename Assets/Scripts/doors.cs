using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] float cameraY;
    [SerializeField] Transform camera;
    [SerializeField] Animator animator;

    public void GoToDoors()
    {
        StartCoroutine(Anim());
    }
    IEnumerator Anim()
    {
        animator.Play("black");
        yield return new WaitForSecondsRealtime(0.5f);
        Player.Instance.transform.position = new Vector3((float)targetPos.position.x, (float)targetPos.position.y);
        camera.transform.position = new Vector3(0, cameraY);
        animator.Play("toblack");
        yield return new WaitForSecondsRealtime(0.5f);


    }
}
