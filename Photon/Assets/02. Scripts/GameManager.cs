using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPun
{
    public Transform[] spawnPoints;

    private void Awake()
    {
        Screen.SetResolution(800, 600, FullScreenMode.Windowed);
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 30;

        CreatePlayer();   
    }

    private void CreatePlayer()
    {
        int index = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate("Player",spawnPoints[index].position,spawnPoints[index].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
