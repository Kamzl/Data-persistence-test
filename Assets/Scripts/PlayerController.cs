using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Transform playerTransform;
    private Vector3 mouseTrack = Vector3.zero;
    private Rigidbody playerRigidbody;
    private bool canJump = true;
    private SpawnManager spawnManager;
    public float jumpForce = 0.5f;
    public ParticleSystem splashPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("mouse 0") && canJump && gameManager.isGameActive)
        {
            mouseTrack.x += -Input.GetAxis("Mouse X");
            mouseTrack.z += -Input.GetAxis("Mouse Y");
        }
        else if(mouseTrack != Vector3.zero)
        {
            Launch(mouseTrack);
            mouseTrack = Vector3.zero;
        }
        if(playerTransform.position.y < -1 && gameManager.isGameActive)
        {
            Instantiate(splashPrefab, playerTransform.position, splashPrefab.transform.rotation).Play();
            gameManager.isGameActive = false;
            StartCoroutine(GameOver());
        }
    }

    void Launch(Vector3 mouseTrack)
    {
        mouseTrack.y = Mathf.Pow(Mathf.Pow(mouseTrack.x, 2) + Mathf.Pow(mouseTrack.z, 2), 0.5f) / Mathf.Pow(3, 0.5f);       //Создание угла в 30 градусов путём увеличения силы по оси y
        Vector3 flyForce = mouseTrack * jumpForce;
        if (flyForce.y < 1)
        {
            flyForce.y = 1;
        }
        playerRigidbody.AddForce(flyForce, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lilypad"))
        {
            playerRigidbody.velocity = Vector3.zero;
            canJump = true;
            spawnManager.SpawnPlatforms((int)(collision.transform.position.z / 10) + 7);
            if (gameManager.isGameActive && playerTransform.position.z > 2)
            {
                gameManager.IncrementScore((int)playerTransform.position.z / 10 * 10 + 10);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        gameManager.GameOver();
    }
}
