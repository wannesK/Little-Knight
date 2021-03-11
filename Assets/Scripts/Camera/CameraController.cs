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
    private ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;              
    }
    private void Start()
    {
        CheckMusic();
    }
    void LateUpdate()
    {
        Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, nextPos, followSpeed * Time.deltaTime);
    }
    public void MuteInGameMusic()
    {
        if (scoreManager.data.inGameMusicOff == true)
        {
            GetComponent<AudioSource>().enabled = true;
            scoreManager.data.inGameMusicOff = false;           
        }
        else if (scoreManager.data.inGameMusicOff == false)
        {
            GetComponent<AudioSource>().enabled = false;
            scoreManager.data.inGameMusicOff = true;           
        }
        
    }
    public void CheckMusic()
    {
        if (scoreManager.data.inGameMusicOff == false)
        {           
            GetComponent<AudioSource>().enabled = true;
        }
        else if (scoreManager.data.inGameMusicOff == true)
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }
}
