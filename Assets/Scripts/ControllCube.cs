using UnityEngine;
using System.Collections;

public class ControllCube : MonoBehaviour {

	public float xMax;
	public float xMin;
	
	public void move(){
		if(transform.position.x == xMax){
			Debug.Log ("MoveLeft");
			GetComponent<Rigidbody>().MovePosition(new Vector3(xMin,0.0f,0.0f));
		}else{
			GetComponent<Rigidbody>().MovePosition(new Vector3(xMax,0.0f,0.0f));
		}
	}
}
