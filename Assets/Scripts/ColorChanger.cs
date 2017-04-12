using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour 
{
	[SerializeField]
	Renderer _renderer;

	[SerializeField]
	private float _speed;

	[SerializeField]
	private Color _color;

	private Color _currenColor;

	private Color RandomColor
	{
		get
		{
			return new Color { r = Random.Range (0, 1), g = Random.Range (0, 1f), b = Random.Range (0, 1f) };
		}
	}

	void OnMouseOver()
	{
		_renderer.material.color = Color.red;
	}

	void Update () {
		_color = RandomColor;
		if (!_renderer || !_renderer.material)
			return;
		
		_renderer.material.color = Color.Lerp (_renderer.material.color, _currenColor, Time.deltaTime * _speed);

		if (_renderer.material.color == _currenColor)
			_currenColor = RandomColor;
	}
}
