using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // this is a reference to the rigidbocy components called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public Text log;

    GameManager replaying;

    void Awake()
    {
        replaying = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // we marked this a "fixedupdate" because we are using it to mess with physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);  // add a forward force

        if (!replaying.instantReplay)
        {
            if (Input.GetKey("d"))
            {
                //rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                Command moveRight = new MoveRight(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.SetCommand(moveRight);
                invoker.ExecuteCommand(moveRight);

                log.text = "Move Right";
            }

            if (Input.GetKey("a"))
            {
                //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                Command moveLeft = new MoveLeft(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.SetCommand(moveLeft);
                invoker.ExecuteCommand(moveLeft);

                log.text = "Move Left";
            }
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
    }
}
