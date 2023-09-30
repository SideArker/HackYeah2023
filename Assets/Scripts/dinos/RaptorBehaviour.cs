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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, agroDist);
    }
    void Start()
    {
        atk = GetComponent<EnemyAttack>();
        pTrans = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position ,pTrans.position);
        float x = transform.position.x;
        float y = pTrans.position.y;
        if (agroCollider.onTrig)
        {
            if (dist >= minDist)  x = pTrans.position.x;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), moveSpeed * Time.deltaTime);
        }
    }
}
