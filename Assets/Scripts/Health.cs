using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[Header("Health")]
    [SerializeField]
    float health = 100f;

	[Header("VFX")]
	[SerializeField]
	GameObject deathVFX;
	[SerializeField]
	float durationOfVFX = 1f;

	[Header("SFX")]
	[SerializeField]
	AudioClip deathSFX;
	[SerializeField]
	[Range(0, 1)]
	float deathSoundVolume = 0.75f;

    /***
    *       DealDamage() is what is called to register damage to an enemy.
    ***/
    public void DealDamage(float damage)
	{
        health -= damage;
		//Debug.Log("Health is now = " + health);
        if (health <= 0f)
		{   // This object is now dead
			//Debug.Log("VFX triggered");
			TriggerDeathVFX();
            Destroy(gameObject);
		}   // if
    }   // DealDamage(float damage)

	/***
	*		TriggerDeathVFX() handles doing the explosion and destroying the attacker so it
	*	disappears.  It also updates the current score based on the attacker value.
	***/
	private void TriggerDeathVFX()
	{
		if (!deathVFX)
			return;	// Only happens if deathVFX is not set

		GameObject deathVFXObject = Instantiate(
					deathVFX,
					transform.position,
					transform.rotation);
		Destroy(deathVFXObject, durationOfVFX);
		Destroy(gameObject);
	}   // TriggerDeathVFX()
}   // class Health