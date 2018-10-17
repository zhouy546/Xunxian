using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionCtrDefault : Video_DescriptionCtr {

	// Use this for initialization
	void Start () {
		
	}

   public override void initialization() {
        base.initialization();
        foreach (var item in nImagesDescription)
        {
            item.initialization();
        }
       
    }

    public override void setupImage(List<Sprite> sprites) {

        for (int i = 0; i < nImagesDescription.Count; i++)
        {
           // Debug.Log(nImagesDescription.Count);
           // Debug.Log(sprites.Count);
           // Debug.Log(i);

            nImagesDescription[i].image.sprite = sprites[i];
        } 
    }
}
