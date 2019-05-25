using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour {

    
    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    public List <Transform> targets = new List<Transform>();

    private GameObject player1;
    private GameObject player2;
    
    private Vector3 velocity;
    private Camera cam;


    void Awake (){
        //Add players in List to find the center


    }
    private void Start() {
        cam = GetComponent<Camera>();
        FindPlayer();
    }
    private void Update() {
        FindPlayer();
    }

    void FindPlayer() {
        if (player1 == null) {
            player1 = GameObject.FindGameObjectWithTag("Player");
            targets.Add(player1.transform);
        }
        if (player2 == null) {
            player2 = GameObject.FindGameObjectWithTag("Player2");
            targets.Add(player2.transform);
        }
    }

    void LateUpdate() {
        if (targets.Count == 0) {
            return;
        }
        Move();
        Zoom();
    }
    
    void AddPlayers(){
        targets.Add(player1.transform);
        targets.Add(player2.transform);
    }

    void Zoom() {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move() {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance() {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++) {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint() {
        if(targets.Count == 1) {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++) {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
