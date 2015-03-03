using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject target;
	public float speed = 1.0f;
	public int hitpoints = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 targetPos = target.transform.position;

			transform.LookAt(targetPos);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}

	public void TakeDamage(int damage) {
		hitpoints -= damage;
		if (hitpoints < 0) {
			Die ();
		}
	}

	private void Die() {
		GameObject.Destroy (gameObject);
	}
}
