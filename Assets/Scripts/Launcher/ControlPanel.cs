using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{

    /**************************************************************************************/

    #region Public Fields
    
    [SerializeField]
    private GameObject joinPanel;
    [SerializeField]
    private GameObject hostPanel;
   
    #endregion

    /**************************************************************************************/

    #region Public Methods

    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void OnClickHost()
    {
        this.gameObject.SetActive(false);
        hostPanel.SetActive(true);
    }

    public void OnClickJoin()
    {
        this.gameObject.SetActive(false);
        joinPanel.SetActive(true);
    }


    #endregion

    /**************************************************************************************/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
