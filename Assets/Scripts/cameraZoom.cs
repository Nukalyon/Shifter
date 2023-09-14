using System;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public GameObject square;
    public Vector3 posSquare;
    public GameObject circle;
    public Vector3 posCircle;
    [SerializeField] Vector3 centerPoint;
    const float PROFONDEUR_3D = -10f;
    const float FLOOR_CAMERA_SIZE = 50f;
    float CameraSize;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*
        posSquare = square.transform.position;
        posCircle = circle.transform.position;
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
        float newX = Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1);
        float newY = Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1);
        transform.position = new Vector3(newX, newY, 0);
        */
        Vector3 posSquare = square.transform.position;
        Vector3 posCircle = circle.transform.position;
        centerPoint = (posSquare + posCircle) / 2;
        centerPoint.z = PROFONDEUR_3D;
        CameraSize = (posSquare - posCircle).magnitude;// - circle.transform.localScale.x;
        Camera.main.transform.position = centerPoint;
        if(CameraSize > FLOOR_CAMERA_SIZE)
        {
            Camera.main.orthographicSize = CameraSize / 2;
        }
        /*
        float ratio = Screen.height/ Screen.width;
        float distX = CalcDistX();
        float distY = CalcDistY();
        Vector3 distances = new Vector3(distX, distY);
        if(distX >= distY)
        {
            Camera.main.transform.position = new Vector3(distX, Camera.main.transform.position.y, PROFONDEUR_3D);
        }
        else
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, distances.y, PROFONDEUR_3D);
        }
        */
    }

    /*
    private float CalcDistX()
    {
        float sX = square.transform.position.x;
        float cX = circle.transform.position.x;
        return (sX + cX) / 2;
    }

    private float CalcDistY()
    {
        float sY = square.transform.position.y;
        float cY = circle.transform.position.y;
        return (sY + cY) / 2;
    }
    */
    /*
     *  src : https://discussions.unity.com/t/zoom-camera-based-on-position-between-player-an-object/38383/2
    var zoomBoundary = 15;
    var zoom = 13;
    var player : Transform;
    var mainCamera : Transform;
    var defZoom;
    
    function Start () {
    defZoom = mainCamera.GetComponent(CameraScrolling).distance;
    }
    
    function Update () {
    	if (player.transform.position.x < zoomBoundary)
    		mainCamera.GetComponent(CameraScrolling).distance = zoom +((defZoom - zoom)*(player.transform.position.x -this.transform.position.x) /(zoomBoundary - this.transform.position.x));
    		
    	else
    	   mainCamera.GetComponent(CameraScrolling).distance = defZoom;
    }


     *  src : https://discussions.unity.com/t/how-do-i-stop-my-player-from-moving-outside-the-screen-bounds-while-using-an-accelerometer/104761
     * 
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
	    Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

	    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
    */
}
