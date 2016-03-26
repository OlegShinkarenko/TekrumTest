using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    float jumpForce = 100f;
    float startSpeed = 1f;
    float speedRun;
    float speedWallk = 2f;

    private Rigidbody playerRigidbody;
    private Vector3 movemant;
    public Slider enduranceSlider;

    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private string space = "space";
    
    private bool touchingPlatform;
    private float running;
    private float endurance;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        float h = Input.GetAxisRaw(horizontal);
        float v = Input.GetAxisRaw(vertical);
        Move(h, v);
        speedRun = speedWallk * running;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            startSpeed = speedRun;
            enduranceSlider.value--;
        }
        else
            startSpeed = speedWallk;

        if (touchingPlatform && Input.GetKeyDown(space))
        {
               playerRigidbody.velocity = Vector2.zero;
               playerRigidbody.AddForce(Vector2.up * jumpForce);
               touchingPlatform = false;
        }
	}

    void Move(float h, float v) {
        movemant.Set(h, 0, v);
        movemant = movemant.normalized * startSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movemant);
    }

    void OnCollisionEnter() {
        touchingPlatform = true;
    }

    void OnCollisionExit() {
        touchingPlatform = false;
    }

    public void RunSpeed(float newSpeed)
    {
        running = newSpeed;
    }

    public void WallkSpeed(float newSpeed)
    {
        speedWallk = newSpeed; 
    }
}
