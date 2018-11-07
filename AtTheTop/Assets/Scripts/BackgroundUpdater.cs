using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUpdater : MonoBehaviour {

	public Sprite backgroundSprite;
	SpriteRenderer background;

	public bool isCar;
	public bool isComputer;
	public int upgradeLevel;

	// Use this for initialization
	void Start () {
		background = GetComponent<SpriteRenderer>();

		if (isCar && GameData.Upgrade4Level >= upgradeLevel)
		{
			background.sprite = backgroundSprite;
		}

		if (isComputer && GameData.Upgrade3Level >= upgradeLevel)
		{
			background.sprite = backgroundSprite;
		}
	}
}
