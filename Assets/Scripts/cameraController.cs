using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] Transform camera;

    private void Update()
    {
        camera.position = new Vector3(Player.Instance.transform.position.x, camera.position.y, -0.3f);
    }
}
