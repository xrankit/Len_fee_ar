using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class MerasureLine : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public ARCameraManager arcameraManager;
    public LineRenderer line;
    private List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
    public GameObject centerPoint;
    public GameObject dot;
    private GameObject dot1;
    private GameObject dot2;
    private GameObject startPoint;
    private GameObject endPoint;
    private LineRenderer cloneLine;
    bool isEnd = false;
    bool isStatic = false;
    public TMP_Text showText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arRaycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2),hitpoint,TrackableType.Planes);
        if(hitpoint.Count>0)
        {
            centerPoint.transform.position = hitpoint[0].pose.position;
            centerPoint.transform.position = hitpoint[0].pose.position;
        }
        if(isStatic ==true)
        {
            cloneLine.SetPosition(1,centerPoint.transform.position);
            endPoint = centerPoint;
        }
        if(isEnd== true)
        {
            showText.text = Vector3.Distance(startPoint.transform.position,endPoint.transform.position).ToString();
        }
    }

    public void Button_Pressed()
    {
        if(isStatic == false)
        {
            dot1 = Instantiate(dot,centerPoint.transform.position,Quaternion.identity);
            cloneLine = Instantiate(line);
            cloneLine.SetPosition(0,dot1.transform.position);
            isStatic = true;
            startPoint = dot1;
            isEnd = true;
        }
        else
        {
            dot2 = Instantiate(dot,centerPoint.transform.position,Quaternion.identity);
            cloneLine.SetPosition(0,dot1.transform.position);
            isStatic = false;
            endPoint.transform.position = dot2.transform.position;
        }
    }
}
