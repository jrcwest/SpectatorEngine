using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class StartupPanel : MonoBehaviourPunCallbacks
{
    string gameVersion = "1";
    bool isConnecting;

    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToPhoton()
    {
        // Use on startup to ensure photon is reachable?
        isConnecting = PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        // we don't want to do anything if we are not attempting to join a room.
        // this case where isConnecting is false is typically when you lost or quit the game, when this level is loaded, OnConnectedToMaster will be called, in that case
        // we don't want to do anything.
        if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            Debug.Log("Connected to Master!");
            isConnecting = false;
            gameObject.SetActive(false);
        }
    }
}
