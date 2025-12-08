using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WaveSpawner : MonoBehaviour
{
   
    public List<Zombie> zombies = new List<Zombie>();
    public int currWave;
    private int waveValue;
    public List<GameObject> zombiesToSpawn = new List<GameObject>();
 
    public Transform[] spawnLocation;
    public int spawnIndex;
 
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
 
    public List<GameObject> spawnedzombies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer <=0)
        {
            //spawn an Zombie
            if(zombiesToSpawn.Count >0)
            {
                GameObject Zombie = (GameObject)Instantiate(zombiesToSpawn[0], spawnLocation[spawnIndex].position,Quaternion.identity); // spawn first Zombie in our list
                zombiesToSpawn.RemoveAt(0); // and remove it
                spawnedzombies.Add(Zombie);
                spawnTimer = spawnInterval;
 
                if(spawnIndex + 1 <= spawnLocation.Length-1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            else
            {
                waveTimer = 0; // if no zombies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
 
        if(waveTimer<=0 && spawnedzombies.Count <=0)
        {
            currWave++;
            GenerateWave();
        }
    }
 
    public void GenerateWave()
    {
        waveValue = currWave * 10;
        Generatezombies();
 
        spawnInterval = waveDuration / zombiesToSpawn.Count; // gives a fixed time between each zombies
        waveTimer = waveDuration; // wave duration is read only
    }
 
    public void Generatezombies()
    {
        // Create a temporary list of zombies to generate
        // 
        // in a loop grab a random Zombie 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.
 
        // repeat... 
 
        //  -> if we have no points left, leave the loop
 
        List<GameObject> generatedzombies = new List<GameObject>();
        while(waveValue>0 || generatedzombies.Count <50)
        {
            int randZombieId = Random.Range(0, zombies.Count);
            int randZombieCost = zombies[randZombieId].cost;
 
            if(waveValue-randZombieCost>=0)
            {
                generatedzombies.Add(zombies[randZombieId].ZombiePrefab);
                waveValue -= randZombieCost;
            }
            else if(waveValue<=0)
            {
                break;
            }
        }
        zombiesToSpawn.Clear();
        zombiesToSpawn = generatedzombies;
    }
  
}
 
[System.Serializable]
public class Zombie
{
    public GameObject ZombiePrefab;
    public int cost;
}