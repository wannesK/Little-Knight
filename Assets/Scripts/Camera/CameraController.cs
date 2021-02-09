using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float minX, maxX;
    public float minY, maxY;

    private GameMaster gm;
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }
    void Update()
    {
        Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, nextPos, followSpeed * Time.deltaTime);
    }
}
