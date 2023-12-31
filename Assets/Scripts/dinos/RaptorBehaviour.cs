using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RaptorBehaviour : MonoBehaviour
{
    EnemyAttack atk;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float agroDist = 3;
    [SerializeField] float minDist = 1.5f;
    Transform pTrans;
    [SerializeField] onTrigger agroCollider;
    [SerializeField] Animator animator;
    [SerializeField] EnemyAttack enemyAttack;
    Vector3 scale;
    private bool moving;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroDist);
    }
    void Start()
    {
        atk = GetComponent<EnemyAttack>();
        pTrans = Player.Instance.transform;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs(transform.position.x - pTrans.position.x);
        float x = transform.position.x;
        float y = pTrans.position.y;
        animator.SetBool("moving", false);
        moving = false;
        if (transform.position.x > pTrans.position.x) transform.localScale = new Vector3(-1 * scale.x, scale.y, 1);
        else
        if(transform.position.x < pTrans.position.x) transform.localScale = new Vector3(1 * scale.x, scale.y, 1);

        if (agroCollider.onTrig)
        {
            if (dist >= minDist)
            {
                x = pTrans.position.x;
                animator.SetBool("moving", true);
                moving = true;
            }
            else
            if (transform.position.y == y)
            {
                animator.SetBool("moving", false);
                moving = false;
            }
            else
            {
                animator.SetBool("moving", true);
                moving = true;
            } 
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), moveSpeed * Time.deltaTime);
            //if(!moving)
            //{
            //    enemyAttack.Attack();
            //}
        }
    }
}
