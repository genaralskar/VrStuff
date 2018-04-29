using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimativesCreator : MonoBehaviour {

	private SteamVR_TrackedController _controller;
	private PrimitiveType _currentPrimitiveType = PrimitiveType.Sphere;

	void OnEnable()
	{
		_controller = GetComponent<SteamVR_TrackedController>();
		_controller.TriggerClicked += HandleTriggerClicked;
		_controller.PadClicked += HandlePadClicked;
	}

	void OnDisable()
	{
		_controller.TriggerClicked -= HandleTriggerClicked;
		_controller.PadClicked -= HandlePadClicked;
	}

	#region Primative Spawning
	void HandleTriggerClicked(object sender, ClickedEventArgs e)
	{
		SpawnCurrentPrimativeAtController();
	}

	void SpawnCurrentPrimativeAtController()
	{
		var spawnedPrimative = GameObject.CreatePrimitive(_currentPrimitiveType);
		spawnedPrimative.transform.position = transform.position;
		spawnedPrimative.transform.rotation = transform.rotation;

		spawnedPrimative.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		if(_currentPrimitiveType == PrimitiveType.Plane)
		{
			spawnedPrimative.transform.localScale = new Vector3(.01f, .01f, .01f);
		}
	}
	#endregion

	#region  PrimativeSelection

	void HandlePadClicked(object sender, ClickedEventArgs e)
	{
		if(e.padY < 0)
			SelectPreviousPrimitive();
		else
			SelectNextPrimitive();
	}

	void SelectNextPrimitive()
	{
		_currentPrimitiveType++;
		if(_currentPrimitiveType > PrimitiveType.Quad)
			_currentPrimitiveType = PrimitiveType.Sphere;
	}

	void SelectPreviousPrimitive()
	{
		_currentPrimitiveType--;
		if(_currentPrimitiveType < PrimitiveType.Sphere)
		{
			_currentPrimitiveType = PrimitiveType.Quad;
		}
	}
	#endregion

}
