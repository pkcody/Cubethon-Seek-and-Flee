using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee
{
    // character: Static
    // target: Static
    // maxSpeed: float
    public Transform character;
    public Transform target;
    public float maxSpeed;

    // function getSteering() -> KinematicSteeringOutput:
    // result = new KinematicSteeringOutput()
    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        //10 # Get the direction to the target.
        //11 result.velocity = target.position - character.position
        result.velocity = character.position - target.position;

        //13 # The velocity is along this direction, at full speed.
        //14 result.velocity.normalize()
        //15 result.velocity *= maxSpeed
        result.velocity.Normalize();
        result.velocity *= maxSpeed;



        //17 # Face in the direction we want to move.
        //18 character.orientation = newOrientation(
        //19 character.orientation,
        //20 result.velocity)
        float angle = newOrientation(character.rotation.eulerAngles.y, result.velocity);
        character.eulerAngles = new Vector3(0, angle, 0);
        Debug.Log(angle);


        //22 result.rotation
        result.rotation = 0;
        //# Get the direction away from the target.
        //        2 steering.velocity = character.position - target.position
        // result.velocity = character.position - target.position;


        return result;
    }

    //    1 function newOrientation(current: float, velocity: Vector) -> float:
    //2 # Make sure we have a velocity.
    //3 if velocity.length() > 0:
    //4 # Calculate orientation from the velocity.
    //5 return atan2(-static.x, static.z)
    //6
    //7 # Otherwise use the current orientation.
    //8 else:
    //9 return current
    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(velocity.x, velocity.z);
            angle *= Mathf.Rad2Deg;

            return angle;
        }
        else
        {
            return current;
        }
    }


}
