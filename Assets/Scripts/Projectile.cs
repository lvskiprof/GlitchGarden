using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float   moveSpeed = 1f;
    [SerializeField]
    float damage = 50f;

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}   // Update()

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		var health = otherCollider.GetComponent<Health>();  // Find the Health class for it (may be null)
		var attacker = otherCollider.GetComponent<Attacker>();  // Find the Attacker class for it (may be null)

		if (health && attacker)
		{   // Only do this if we collided with something that has Attacker and Health classes attached to it
			Debug.Log("I hit: " + otherCollider.name);  // Report what was hit for debugging
			gameObject.SetActive(false);
			health.DealDamage(damage);  // Cause the damage, which will destroy it if dead
			Destroy(gameObject);
		}   // if
	}   // OnTriggerEnter2D()
}   // class Projectile