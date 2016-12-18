using UnityEngine;
using System.Collections;

public class RotateItem : MonoBehaviour {
	
	void Update () {
        transform.Rotate(new Vector3(0, Time.deltaTime * 25, 0));
	}
}
