using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardCreator : MonoBehaviour 
{
	[SerializeField]
	private int _m = 3;

	[SerializeField]
	private int _n = 3;

	[SerializeField]
	private ColorChanger _ball;

	[SerializeField]
	private Transform _sp;

	[SerializeField]
	private float _width;

	[SerializeField]
	private float _timer=2;

	private List<ColorChanger>_bolls = new List<ColorChanger>();

	public void GenerateField (int type) 
	{

		if (!_ball || !_sp)
			return;
		
		CleanContent ();

		Vector3 sp = _sp.position;

		for (int i = 0; i < _m; i++) 
		{
			for (int j = 0; j < _n; j++)
			{
				var temp = _ball.GetClone();
				if (!temp)
					continue;
				temp.transform.position = GetItemPosition ((FieldType)type, j, i);
				temp.name = i + ":" + j;
				temp.gameObject.transform.SetParent(this.gameObject.transform, true);
				_bolls.Add (temp);
			}
		}
	}

	private void Update ()
	{
		if (_timer>Time.time%5)
		{
			for (int i = 0; i < _m; i++) 
			{
				for (int j = 0; j < _n; j++) 
				{
					if (GameObject.Find ((i + Random.Range (0, _m)) + ":" + (j - Random.Range (0, _n))) && this.transform.FindChild (i + ":" + j).tag != "Green") {
						this.transform.FindChild (i + ":" + j).GetComponent<Renderer> ().material.color = Color.green;
						this.transform.FindChild (i + ":" + j).tag = "Green";
						_timer = Random.Range(1,3);
					}

					if (GameObject.Find ((i + Random.Range (0, _m)) + ":" + (j - Random.Range (0, _n))) && this.transform.FindChild (i + ":" + j).tag != "Blue") {
						this.transform.FindChild (i + ":" + j).GetComponent<Renderer> ().material.color = Color.blue;
						this.transform.FindChild (i + ":" + j).tag = "Blue";
						_timer = Random.Range(1,5);
					}

					if (GameObject.Find ((i + Random.Range (0, _m)) + ":" + (j - Random.Range (0, _n))) && this.transform.FindChild (i + ":" + j).tag != "Yellow") {
						this.transform.FindChild (i + ":" + j).GetComponent<Renderer> ().material.color = Color.yellow;
						this.transform.FindChild (i + ":" + j).tag = "Yellow";
						_timer = Random.Range(1,8);
					}
				}
			}	
		}
	}

	private Vector3 GetItemPosition(FieldType type, int j, int i)
	{
		if (!_sp)
			return Vector3.zero;
		
		Vector3 sp = _sp.position;

		if (type	== FieldType.Linear)
		{
			return new Vector3 {
				x = sp.x + +j * _width,
				y = sp.y - i * _width,
				z = 0 
			};
		}
		else
		{
			float _xOfset = (i % 2) != 0 ? _width / 2f : 0;;
			float _yOfset = _width/2;
			return new Vector3
			{
				x = sp.x + _xOfset + j * _width,
				y = sp.y - i * (_width- _yOfset),
				z = 0 
			};
		}
	}

	private void CleanContent ()
	{
		foreach (var item in _bolls) 
		{
			if (item == null)
				continue;
			item.PutClone ();
		}
		_bolls.Clear ();
	}

	private enum FieldType
	{
		Linear,
		Hex
	}
}