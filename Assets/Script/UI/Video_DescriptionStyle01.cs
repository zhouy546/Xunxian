using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionStyle01 : Video_DescriptionCtr
{
    public List<Sprite> SpriteList = new List<Sprite>();
    


    void Start()
    {

    }

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
        for (int i = 0; i < sprites.Count; i++)
        {

            SpriteList.Add(sprites[i]);

        }

        //StartCoroutine(AnimationLoop());
    }



    public override void TriggerAnimation(bool onoff)
    {
        StopAllCoroutines();
        base.TriggerAnimation(onoff);
        StartCoroutine(AnimationLoop());
    }

    IEnumerator AnimationLoop() {
        for (int i = 0; i < SpriteList.Count; i++)
        {
           
            nImagesDescription[0].image.sprite = SpriteList[i];
          
            yield return new WaitForSeconds(4f);
        }

        StartCoroutine(AnimationLoop());

    }

    

    public override void setupImage(Sprite L_sprite, Sprite R_sprite)
    {

    }
}
