using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float jumpForce;
    private float startSpeed;
    private float speedRun;
    public static float speedWallk;

    private Rigidbody playerRigidbody;
    private Vector3 movemant;
    public Slider enduranceSlider;

    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    
    private bool touchingPlatform;
    private float running;
    private float endurance;
    private bool flag;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

	void Update () {
        float h = Input.GetAxisRaw(horizontal);
        float v = Input.GetAxisRaw(vertical);
        Move(h, v);
        Jump();
        speedRun = speedWallk * running;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            flag = true;
            startSpeed = speedRun;
            enduranceSlider.value--;
            if (enduranceSlider.value == 0)
            {
                startSpeed = speedWallk;
                flag = false;
            }  
        }
        else
            startSpeed = speedWallk;
        if (!flag)
        StartCoroutine(Enum());
	}

    IEnumerator Enum() {
        yield return new WaitForSeconds(0.1f); 
            enduranceSlider.value += 0.1f;
    }
        
    

    void Jump() {
        if (touchingPlatform && Input.GetKeyDown(KeyCode.Space))
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

    public void JumpForce(float newForse)
    {
        jumpForce = newForse; 
    }

    public void Endurance(float newEndurance) 
    {
        endurance = newEndurance;
    }

}
