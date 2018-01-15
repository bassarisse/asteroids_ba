﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {

	public Rigidbody2D TargetBody;
	public float ImpulseForce = 1.5f;
	public int Level = 0;

	public AsteroidEvent OnDie;

	void Start() {
		if (OnDie == null)
			OnDie = new AsteroidEvent ();
	}

	void OnEnable () {
		this.TargetBody.AddForce (this.transform.up * this.ImpulseForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		var cache = AsteroidHit.Cache;
		var key = collider.gameObject;
		if (cache.ContainsKey(key))
			cache [key].Hit (gameObject, collider);
	}

	public void Die() {
		OnDie.Invoke (gameObject, this);
	}
}
