using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public GameObject target;
	public float frequency = 1.0f;
	public int numberOfUnits = 10;

	private int spawnedUnits = 0;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.timeSinceLevelLoad > lastSpawnTime + frequency && spawnedUnits < numberOfUnits) {
			Spawn ();
		}
	}

	private void Spawn() {
		GameObject spawnedUnit = GameObject.Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject;
		spawnedUnits ++;
		lastSpawnTime = Time.timeSinceLevelLoad;

		//	set the target
		Enemy enemy = spawnedUnit.GetComponent<Enemy>();
		enemy.target = target;
	}
}
