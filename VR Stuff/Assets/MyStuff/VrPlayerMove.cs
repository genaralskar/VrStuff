using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrPlayerMove : MonoBehaviour {

	public SteamVR_TrackedController _controller;
	public GameObject _camera;
	public CharacterController _player;
	public bool padInput = false;

	public float moveSpeed = 1;

	void OnEnable()
	{
		_controller.PadTouched += HandlePadTouched;
		_controller.PadUntouched += HandlePadUntouched;
	}

	void OnDisable()
	{
		_controller.PadTouched -= HandlePadTouched;
		_controller.PadUntouched -= HandlePadUntouched;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandlePadTouched(object sender, ClickedEventArgs e)
	{

		Vector3 targetDirection = new Vector3(e.padX, 0f, e.padY);
		targetDirection = _camera.transform.TransformDirection(targetDirection);
		targetDirection.y = 0.0f;

		//StartCoroutine(Move(targetDirection));
		StartCoroutine(Move(e));
	}

	IEnumerator Move(ClickedEventArgs e)
	{
		while(true)
		{
			yield return new WaitForEndOfFrame();

			Vector3 targetDirection = new Vector3(Input.GetAxis("Primary Pad X"), 0f, Input.GetAxis("Primary Pad Y"));
			
			targetDirection = _camera.transform.TransformDirection(targetDirection);
			targetDirection.y = 0.0f;

			targetDirection = targetDirection.normalized;
			print(targetDirection);

			_player.Move(targetDirection * moveSpeed * Time.deltaTime);
		}
		
	}

	void HandlePadUntouched(object sender, ClickedEventArgs e)
	{
		StopAllCoroutines();
	}
}
