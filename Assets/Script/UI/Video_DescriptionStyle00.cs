using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionStyle00 : Video_DescriptionCtr
{

    public override void initialization()
    {
        base.initialization();
        foreach (var item in nImagesDescription)
        {
            item.initialization();
        }
    }

    public override void setupImage(List<Sprite> sprites)
    {
        for (int i = 0; i < nImagesDescription.Count; i++)
        {
              nImagesDescription[i].image.sprite = sprites[i];
        }
    }
}
