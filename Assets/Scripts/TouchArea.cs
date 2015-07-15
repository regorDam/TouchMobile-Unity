using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

// 
public class TouchArea : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler{

	public float smoothing;
	public ControllCube controllCube;

	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	private bool touched;
	private int pointerID;

	void Awake()
	{
		direction = Vector2.zero;
		touched = false;
	}
	
	public void OnPointerDown(PointerEventData data)
	{
		if (!touched)
		{
			touched = true;
			pointerID = data.pointerId;
			origin = data.position;
		}
	}
	
	public void OnDrag(PointerEventData data)
	{
		if (data.pointerId == pointerID)
		{
			Vector2 currentPosition = data.position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw.normalized;
			if(direction != Vector2.up ){
				Debug.Log ("Shoot");
			}
		}
	}
	
	public void OnPointerUp(PointerEventData data)
	{
		if (data.pointerId == pointerID)
		{
			direction = Vector3.zero;
			touched = false;
			controllCube.move();
		}
	}
	
	public Vector2 GetDirection()
	{
		smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
		return smoothDirection;
	}

}
