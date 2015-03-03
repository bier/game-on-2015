using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public int damage = 5;
	public float rateOfFire = 1.0f;

	public Enemy target;
	private float lastShot;

	// Use this for initialization
	void Start () {
		lastShot = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (target != null) {
			if (Time.timeSinceLevelLoad >= lastShot + rateOfFire) {
				target.TakeDamage(damage);
				lastShot = Time.timeSinceLevelLoad;
			}
		}
	}

	public void OnTriggerEnter(Collider collider) {
		if (target != null) {
			return;
		}

		Enemy enemy = collider.gameObject.GetComponent<Enemy>();
		if (enemy != null) {
			Debug.Log ("Setting target...");
			target = enemy;
		}
	}

	public void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Enemy>() == target) {
			Debug.Log ("Unsetting target...");
			target = null;
		}
	}
}
