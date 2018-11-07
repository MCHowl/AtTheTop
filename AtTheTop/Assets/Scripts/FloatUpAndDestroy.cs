using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpAndDestroy : MonoBehaviour {

	float lifetime = 1;
	float moveScale = 1f;

	Color tempColor;
	
	RectTransform rTransform;
	TMPro.TextMeshProUGUI displayText;

	void Start () {
		Destroy(this.gameObject, lifetime);
		rTransform = GetComponent<RectTransform>();
		
	}

	public void InitialiseText(float value, bool type) {
		displayText = GetComponent<TMPro.TextMeshProUGUI>();
		// true = money
		if (type) {

			displayText.color = new Color(66f/255f, 165/255f, 19f/255f);

			if (value > 0) {
				displayText.text = "Money +$" + value.ToString("F2");
			} else {
				displayText.text = "Money -$" + Mathf.Abs(value).ToString("F2");
			}
		} else {

			displayText.color = new Color(226f /255f, 223f/255f, 40f/255f);

			if (value > 0) {
				displayText.text = "Energy +" + value.ToString("F1") + "%";
			} else {
				displayText.text = "Energy " + value.ToString("F1") + "%";
			}
		}
	}
	
	void Update () {
		rTransform.position = rTransform.position + (transform.up * moveScale);
		tempColor = displayText.color;
		tempColor.a = displayText.color.a - (Time.deltaTime / lifetime);
		displayText.color = tempColor;
	}
}
