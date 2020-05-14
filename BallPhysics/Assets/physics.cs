using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		phball[] objects = transform.GetComponentsInChildren<phball>();

		for ( int i = 0; i < objects.Length; i++ )
			for (int j = i+1; j < objects.Length; j++)
			{
					phball A = objects[i];
					phball B = objects[j];

					resolveCollision(A, B);
			}
	}

	void resolveCollision( phball A, phball B)
	{
		Vector2 BA = B.pos - A.pos;

		float distance = Mathf.Sqrt(BA.x * BA.x + BA.y * BA.y);

		if ( distance < ( A.radius + B.radius ) ) //если есть контакт
		{
			Vector2 n = BA.normalized;
			Vector2 Vba = B.velocity - A.velocity;

			if ( Vector2.Dot(n, Vba ) < 0) //если тела движутся навстречу
			{
				float e = 0.5f;
				float a = (1 + e) * Vector2.Dot(Vba, n) / (1 / A.mass + 1 / B.mass);

				Vector2 impulse = n * a;
				A.velocity += impulse / A.mass;
				B.velocity += -impulse / B.mass;
			}
		}
	}
}
