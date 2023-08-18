using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HostPanel : MonoBehaviour
{


    [SerializeField]
    private TMP_Text roomCodeLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        string roomCode = GenerateRoomCode(5);
        roomCodeLabel.text = roomCode;
    }

    public void OnClickStart()
    {
        this.gameObject.SetActive(false);        
    }

    public string GenerateRoomCode(int codeLength)
    {
        const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
        string roomCode = "";

        for(int i=0; i<codeLength; i++)
        {
            roomCode += glyphs[Random.Range(0, glyphs.Length)];
        }

        return roomCode.ToUpper();
    }
}
