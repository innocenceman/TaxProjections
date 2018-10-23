using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLines : MonoBehaviour {

    private HTTPtext httpText;
    private GameObject Marker;
    private GameObject Tips;

    private LineRenderer line;
    public Material material;
    private GameObject MarkerPoint_1;
    private GameObject TipsPoint_1;
    private Vector3 startPos;
    private Vector3 endPos;
    // Use this for initialization
    void Start () {

        httpText = GameObject.Find("UIManager").gameObject.GetComponent<HTTPtext>();
        httpText.draw_line += Drawline;

        Marker = GameObject.Find("Marker").gameObject;
        Tips = GameObject.Find("Tips").gameObject;
        MarkerPoint_1 = GameObject.Find("MarkerPoint_1").gameObject;
        TipsPoint_1 = GameObject.Find("TipsPoint_1").gameObject;

        line = this.gameObject.AddComponent<LineRenderer>();
        line.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void Drawline()
    {
        if (Marker.activeInHierarchy && Tips.activeInHierarchy)
        {
            Debug.Log("我开始画线了。。。");
            line.enabled = true;
            startPos = MarkerPoint_1.transform.position;
            endPos = TipsPoint_1.transform.position;
            line.SetPosition(0, startPos);
            line.SetPosition(1, endPos);
            line.material = material;
            line.startColor = Color.blue;
            line.endColor = Color.red;
            line.startWidth = 0.001f;
            line.endWidth = 0.001f;
        }
        else
        {
            line.enabled = false;
        }
    }
}
