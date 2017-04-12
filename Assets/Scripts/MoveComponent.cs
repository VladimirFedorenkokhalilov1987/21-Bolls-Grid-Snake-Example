using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour
{
	public Transform Leader
	{
		get;
		set;
	}

	[SerializeField,Range(0,10f)]
	private float _speed = 1;

	[SerializeField]
	private float _distanse;

	void Update () 
	{
		if (!Leader)
		{
			return;
		}
		if (Vector3.Distance (transform.position, Leader.position) < _distanse)
			return;

		transform.position = Vector3.Lerp (transform.position, Leader.position, Time.deltaTime * _speed);
	}
}