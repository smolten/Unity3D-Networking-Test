using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public const int Damage = 10;

	void OnCollisionEnter(Collision collision)
	{
		var target = collision.gameObject;
		var health = target.GetComponent<Health>();
		if (health)
		{
			health.TakeDamage(Damage);
		}

		Destroy(gameObject);
	}
}
