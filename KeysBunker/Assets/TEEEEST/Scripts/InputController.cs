using UnityEngine;
using System.Collections;

[RequireComponent (typeof (InputHandler))]

public class IInputController : MonoBehaviour {
	
	private InputHandler handler;

	void Start ()
	{
		handler = GetComponent<InputHandler> ();
	}

	void Update () {

		if (handler == null)
			return;

		if (Input.touches.Length > 0) {
			
			Touch touch = Input.touches[0];
			
			if (touch.phase == TouchPhase.Began)
			{
				handler.HandleTouchDown (touch.position);
			}
			else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
			{
				handler.HandleTouchUp(touch.position);
			}
			else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				handler.HandleTouchMove (touch.position);
			}
			
			
			handler.HandleTouchMove (touch.position);	
			
			return;
		}
		else if (Input.GetMouseButtonDown(0) )
		{
			handler.HandleTouchDown (Input.mousePosition);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			handler.HandleTouchUp(Input.mousePosition);
		}
		else 
			handler.HandleTouchMove (Input.mousePosition);
		
	}
}
