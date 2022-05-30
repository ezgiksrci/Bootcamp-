using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public static GameObject spawnedPlayer;

    private void Start()
    {
        spawnedPlayer = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-0.7621526f, 1.340919f, -53.05302f), Quaternion.identity);
    }
}
