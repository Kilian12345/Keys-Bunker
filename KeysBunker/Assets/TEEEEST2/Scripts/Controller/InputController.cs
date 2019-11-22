using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IInputHandler))]
public class InputController : MonoBehaviour {

	private IInputHandler handler;
	private bool down;

	void Awake () {
		handler = GetComponent<IInputHandler> ();
	}

	void Update () {

		if (handler == null)
			return;
		
		if (Input.touches.Length > 0) {
			
			Touch touch = Input.touches[0];

			if (touch.phase == TouchPhase.Began)
			{
				handler.HandleTouchDown (touch.position);
				down = true;
			}
			else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
			{
				handler.HandleTouchUp(touch.position);
				down = false;
			}
			else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				if (down)
					handler.HandleTouchMove (touch.position);

			}
			if (down)
				handler.HandleTouchMove (touch.position);	
			
			return;
		}
		else if (Input.GetMouseButtonDown(0) )
		{
			down = true;
			handler.HandleTouchDown (Input.mousePosition);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			down = false;
			handler.HandleTouchUp(Input.mousePosition);
		}
		else 
			if (down)
				handler.HandleTouchMove (Input.mousePosition);

	}
}
