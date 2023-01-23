using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    //    class Kinematic :
    //2 position: Vector
    //3 orientation: float
    //4 velocity: Vector
    //5 rotation: float

    //not these
    //public Vector3 position;
    //public float orientation;


    public Vector3 velocity;
    public float rotation;

    public KinematicSeek _steering;
    public float _mySpeed = 7f;
    public Transform _target;

    private void Start()
    {
        _steering = new KinematicSeek();
        _steering.target = _target;
        _steering.character = this.transform;
        _steering.maxSpeed = _mySpeed;
    }

    //4 function update(steering: SteeringOutput, time: float):

    //4 function update(steering: SteeringOutput, time: float):
    //5 # Update the position and orientation.
    //6 position += velocity* time
    //7 orientation += rotation* time
    //8
    //9 # and the velocity and rotation.
    //10 velocity += steering.linear* time
    //11 rotation += steering.angular* time


    public void KinematicUpdate(KinematicSteeringOutput steering, float time)
    {
        //position += velocity * time;
        //orientation += rotation * time;

        //velocity += steering.velocity * time;
        transform.position += steering.velocity * time;
    }

    // Update is called once per frame
    void Update()
    {
        KinematicSteeringOutput steering = _steering.getSteering();
        KinematicUpdate(steering, Time.deltaTime);
    }
}
