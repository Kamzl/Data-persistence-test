using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform cameraTransform;
    private Transform playerTransform;
    private GameManager gameManager;
    private Vector3 camPos = new Vector3(0, 10, -1);
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            camPos.z = playerTransform.position.z - 1;
        }
        cameraTransform.position = camPos;
    }
}
