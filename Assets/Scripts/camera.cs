using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class camera : MonoBehaviourPunCallbacks
{
    PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            gameObject.transform.Find("Camera").gameObject.SetActive(true);
            gameObject.transform.Find("Canvas").gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            StartCoroutine(WaitToStartGame());
        }
    }

    IEnumerator WaitToStartGame()
    {
        yield return new WaitForSeconds(5);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("curveFollowEnabled", RpcTarget.All);
    }

    [PunRPC]
    void curveFollowEnabled()
    {
        if (view.IsMine)
        {
            gameObject.GetComponent<curveFollow>().enabled = true;
            print("Script aktif edildi " + view.ViewID);
            gameObject.GetComponent<camera>().enabled = false;
        }
    }
}
