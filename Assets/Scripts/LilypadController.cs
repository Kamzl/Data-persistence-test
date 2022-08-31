using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadController : MonoBehaviour
{
    private Transform playerTransform;
    private Transform lilypadTransform;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        lilypadTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - lilypadTransform.position.z > 4 && gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }
}
