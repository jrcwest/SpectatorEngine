using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinPanel : MonoBehaviour
{
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
        Debug.Log("PrintOnEnable: script was enabled");
    }

    public void OnClickConnect()
    {
        this.gameObject.SetActive(false);        
    }
}
