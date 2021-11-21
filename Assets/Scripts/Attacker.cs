using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
	[Header("Attacker")]
	float currentSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if (transform.position.x < 1f)
		{
            // Destroy(this);
		}   // if
    }   // Updater()

    /***
    *       Set the current movement speed.
    ***/
    public void SetMovementSpeed(float speed)
	{
        currentSpeed = speed;
    }   // SetMovementSpeed()
}   // class Attacker