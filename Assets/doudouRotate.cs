using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doudouRotate : MonoBehaviour {
    [SerializeField]
    float speed = 1;

	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
	}
}
