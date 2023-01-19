using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public AudioClip ouch;
    AudioSource audioSource;

    public delegate void HurtObstacle(Collision collisionInfo);
    public static event HurtObstacle OnHurtObstacle;

    private void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            if (OnHurtObstacle != null)
            {
                OnHurtObstacle(collisionInfo);
                Debug.Log("ouch");
                audioSource.PlayOneShot(ouch, .7F);
            }
        }
    }

}
