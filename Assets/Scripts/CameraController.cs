using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform leftBounds;
    public Transform rightBounds;

    public float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;

    private float camWidth, camHeight, levelMinX,levelMaxX;
    

    // Start is called before the first frame update
    void Start(){
        camHeight = UnityEngine.Camera.main.orthographicSize *2;
        camWidth = camHeight * UnityEngine.Camera.main.aspect;
        levelMinX = leftBounds.position.x + 0 + (camWidth/2);
        levelMaxX = rightBounds.position.x - 0 - (camWidth/2);
    }

    // Update is called once per frame
    void Update(){
        if (target){
            float targetX = Mathf.Max (levelMinX, Mathf.Min(levelMaxX,target.position.x));
            float x = Mathf.SmoothDamp(transform.position.x,targetX, ref smoothDampVelocity.x,smoothDampTime);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
