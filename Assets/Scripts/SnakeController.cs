using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour
{
	[SerializeField]
	GameObject _startText;

	[SerializeField]
	private MoveComponent _ballPrefab;

	private MoveComponent _lastItem;
	private MoveComponent _firstItem;

	[SerializeField, Range(0,100)]
	private float _speed = 1;

	private float _delay = 1f;
	private float _timeToSpawn;

	private void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			_startText.SetActive (false);

			if (!_firstItem) 
			{
				_firstItem = _ballPrefab.GetClone ();
				_lastItem = _firstItem;
				return;
			}

			var tempItem = _ballPrefab.GetClone ();

			if (tempItem) 
			{
				tempItem.Leader = _lastItem.transform;
				_lastItem = tempItem;
			}
		}

		if (_firstItem) 
		{
			Vector3 pos =  Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.z = 0;
			_firstItem.transform.position = Vector3.MoveTowards (_firstItem.transform.position, pos, Time.deltaTime * _speed);
		}
	}
}
