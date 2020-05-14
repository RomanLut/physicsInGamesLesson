using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
	public GameObject ballRef;
	public GameObject gunRef;

	public float V = 30;
	public float g = 9.8f;

	private float Vx;
	private float Vy;

	private float x;
	private float y;

	// Start is called before the first frame update
	void Start()
    {
		x = 0;
		y = 0;

		float angle = gunRef.transform.rotation.eulerAngles.z / 180.0f * Mathf.PI;

		Vx = V * Mathf.Cos( angle );
		Vy = V * Mathf.Sin( angle );
	}

	// Update is called once per frame
	void Update()
    {
		if ( y < 0 ) return;

		float t = Time.time;

		x = Vx * t;
		y = Vy * t - g * t * t / 2;

		ballRef.transform.position = new Vector3( x, y, 0 );
    }
}
