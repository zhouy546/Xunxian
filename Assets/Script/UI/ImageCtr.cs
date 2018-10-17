using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCtr : MonoBehaviour {

    public ImageBase imageBase;

    private bool toggleA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
                imageBase.HideAll();
        }

        if (Input.GetMouseButtonDown(1))
        {
                imageBase.ShowAll();
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            toggleA = !toggleA;
            if (toggleA)
            {
                imageBase.SetLocation(Vector3.zero, .5F,LeanTweenType.easeInOutQuad);
                foreach (var item in imageBase.ChildrenimageBases)
                {
                    item.SetLocation(Vector3.zero, .5F, LeanTweenType.easeInOutQuad);
                }
                imageBase.SetScale(Vector3.zero, .5F, LeanTweenType.easeInOutQuad);
            }
            else {
                imageBase.SetLocation(imageBase.startLocalPosition, .5F, LeanTweenType.easeInOutQuad);
                foreach (var item in imageBase.ChildrenimageBases)
                {
                    item.SetLocation(item.startLocalPosition, .5F, LeanTweenType.easeInOutQuad);
                }
                imageBase.SetScale( Vector3.one, .5F, LeanTweenType.easeInOutQuad);
            }

        }
    }

    void initialization() {
    }
}
