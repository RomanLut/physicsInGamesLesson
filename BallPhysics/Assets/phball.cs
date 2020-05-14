using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phball : MonoBehaviour
{
	public Vector2 pos;
	public float radius;
	public float mass = 0;
	public Vector2 velocity;
	public float g = -0.98f;

	// Start is called before the first frame update
	void Start()
    {
		pos.x = transform.position.x;
		pos.y = transform.position.y;

		radius = transform.localScale.x*0.5f;

		if ( mass == 0 ) mass = 0.05f * Mathf.PI * radius * radius;
	}

	// Update is called once per frame
	void Update()
    {
		float dt = Time.deltaTime;

		pos.x += velocity.x * dt;
		pos.y += velocity.y * dt + g * dt * dt / 2.0f;

		velocity.y += g * dt;

		transform.position = new Vector3(pos.x, pos.y, 0);
	}
}
