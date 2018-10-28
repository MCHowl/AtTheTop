using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToAlpha : MonoBehaviour {

    float fadeTime = 2;
    Image image;

	void Start () {
        image = GetComponent<Image>();
        StartCoroutine(FadeToWhite());
	}

    void setAlpha(float newAlpha) {
        Color imageColor = image.color;
        imageColor.a = newAlpha;
        image.color = imageColor;
    }

    public IEnumerator FadeToWhite() {
        while (image.color.a > 0) {
            setAlpha(image.color.a - Time.deltaTime / fadeTime);
            yield return null;
        }

        GameController.Paused = false;
        yield return null;
    }

    public IEnumerator FadeToBlack() {
        GameController.Paused = true;

        while (image.color.a < 1) {
            setAlpha(image.color.a + Time.deltaTime / fadeTime);
            yield return null;
        }

        yield return null;
    }
}
