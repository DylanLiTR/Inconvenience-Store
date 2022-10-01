using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;
    [SerializeField] float offsetSmoothing = 3;
    Vector3 playerPosition;
    Vector3 camPosition;
    Camera cam;
    float camHeight;
    float camWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        camPosition = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(camPosition.x, leftWall.position.x - camWidth, rightWall.position.x + camWidth), 
                                         Mathf.Clamp(camPosition.y, -5f + camHeight, 25 - camHeight), camPosition.z);
    }
}
