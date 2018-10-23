using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffObjectControl : MonoBehaviour {

    RaycastHit hitInfo;
    private Vector3 position;
    private Vector3 direction;
    private GameObject uibox;
    private GameObject calibrateUI;
    private GameObject markedUI;

    void Start () {
        uibox = GameObject.Find("UIBox").gameObject;
        calibrateUI = GameObject.Find("CalibrateUI_Parent").gameObject;
        markedUI = GameObject.Find("MarkedUI").gameObject;
        calibrateUI.SetActive(false);
        
    }
	void Update () {
        position = this.gameObject.transform.position;
        direction = this.transform.forward;
        if (Physics.Raycast(position,direction,out hitInfo))
        {
            OnOffController();
        }
	}

    private void OnOffController()
    {
        if (hitInfo.collider.name == "OnController")
        {
            uibox.GetComponent<Renderer>().enabled = true;
            //uibox.SetActive(true);
            calibrateUI.SetActive(true);
            markedUI.SetActive(false);

        }
        if (hitInfo.collider.name == "OffController")
        {
            uibox.GetComponent<Renderer>().enabled = false;
            calibrateUI.SetActive(false);
            markedUI.SetActive(true);
        }
    }

    private void OnCircle()
    {

    }

    private void OffCircle()
    {

    }
}
