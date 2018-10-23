using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarker : MonoBehaviour {

    public GameObject Marker;
    public GameObject UIBOX;
    private Matrixcontrol matrix;
    private Vector3 pos;
    private HTTPtext httptext;
    private ChangeMarkerSize changeMarkerSize;

    //比例
    private float scale_width;
    private float scale_height;

    private int value_1;
    private int value_2;

    // Use this for initialization
    void Start () {
        matrix = GameObject.Find("UIManager").GetComponent<Matrixcontrol>();
        httptext = GameObject.Find("UIManager").GetComponent<HTTPtext>();
        changeMarkerSize = GameObject.Find("UIManager").GetComponent<ChangeMarkerSize>();
        value_1 = changeMarkerSize.shrinkValue_1;
        value_2 = changeMarkerSize.shrinkValue_2;
    }
	
	// Update is called once per frame
	void Update () {
        scale_width = matrix.Scale_PhysicToPixel_Width;
        
        scale_height = matrix.Scale_PhysicToPixel_Height;
        matrix.X_element = httptext.Xposition;
        matrix.Y_element = httptext.Yposition;

        matrix.StraightTranform_FullScreen();

        pos.x = matrix.eInimage[0, 0] * scale_width * (value_1 * value_2);
        pos.y = matrix.eInimage[1, 0] * scale_height * (value_1 * value_2);
        //Debug.Log("matrix.eInimage[0, 0]" + matrix.eInimage[0, 0]);
        //Debug.Log("matrix.eInimage[1, 0]" + matrix.eInimage[1, 0]);
        //Debug.Log("scale_width:" + scale_width);
        //Debug.Log("scale_height:" + scale_height);
        //Debug.Log("pos.x:" + pos.x);
        //Debug.Log("pos.y:" + pos.y);
        //pos.x = matrix.eInimage[0, 0];
        //pos.y = matrix.eInimage[1, 0];
        pos.z = UIBOX.transform.position.z;
        Marker.transform.localPosition = pos;
        //Marker.transform.position = pos;
        //Debug.Log("最终UI位置:" + pos);

    }
}
