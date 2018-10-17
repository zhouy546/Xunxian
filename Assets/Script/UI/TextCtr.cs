using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCtr : MonoBehaviour {
    public TextBase textBase;

    public bool sToggle;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sToggle = !sToggle;
            if (sToggle)
            {
                textBase.HideAll();
                textBase.SetLocation(textBase.currentLocalPosition + Vector3.up * 20, 1f, LeanTweenType.easeInOutQuad);

            }
            else
            {
                textBase.ShowAll();
                textBase.SetLocation(textBase.startLocalPosition, 1f, LeanTweenType.easeInQuad);
                textBase.ChangeColor(Color.green, 1f, LeanTweenType.easeInCirc);

            }
        }
    }
}
