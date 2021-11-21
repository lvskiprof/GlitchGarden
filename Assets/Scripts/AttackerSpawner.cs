using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    float       minSpawnDelay = 3f; // Minimum second before spawning an attacker
    [SerializeField]
    float       maxSpawnDelay = 5f; // Maximum second before spawning an attacker
    [SerializeField]
    Attacker    attackerPrefab;     // Animation of attacker
    bool        spawn = true;       // Keep spawning while true

    int attackerCount = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
		{
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }   // while
    }   // Start()

    /***
    *       Spawn an attacker.
    ***/
    private void SpawnAttacker()
    {
        var attacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        attackerCount++;
        attacker.name = attacker.name + " #" + attackerCount;
    }   // SpawnAttacker()
}   // class AttackerSpawner