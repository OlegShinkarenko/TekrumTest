using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static float jumpForce = 1;
    public static float startJump; 
    public static float startSpeed = 1;
    public static float speedRun = 1;
    public static float speedWallk = 1;
    public static float running;
    
    public Slider enduranceSlider;
    public Slider wallk;
    public Slider run;
    public Slider jump;

    private Rigidbody playerRigidbody;
    private Vector3 movemant;

    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    
    private bool touchingPlatform;
    private float endurance;
    private bool flag;

    void Start() {
        wallk.value = PlayerPrefs.GetFloat("WallkSpeed");
        run.value = PlayerPrefs.GetFloat("RunSpeed");
        jump.value = PlayerPrefs.GetFloat("JumpForce");
        playerRigidbody = GetComponent<Rigidbody>();
    }

	void Update () {
        startJump = 1;
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

    public void WallkSpeed(float newSpeedWallk)
    {
        speedWallk = newSpeedWallk;

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
