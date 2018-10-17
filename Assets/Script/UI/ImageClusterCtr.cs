using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClusterCtr : MonoBehaviour {
    public List<SubNodeGroupCtr> subNodeGroupCtr = new List<SubNodeGroupCtr>();
    //public List<NImage> Nimages = new List<NImage>();

    public float xPos;


    private int num =0;
    public int Num {
        get { return num; }
        set
        {
            if (value < 0 || value > subNodeGroupCtr.Count - 1)
            {
                return;
            }

            num = value;
        }
    }

    


    public float MoveStep = 192.3f;//cell size + spacing
    // Use this for initialization
    void Start () {

        
       // hideAll();

    }

    public void hideAll() {
        foreach (var item in subNodeGroupCtr)
        {
            item.Hide();
        }
    }

    public void ShowAll() {
        foreach (var item in subNodeGroupCtr)
        {
            item.Show();
        }
    }

    public void Display(int num,List<GameObject> titleList) {
        for (int i = 0; i < subNodeGroupCtr.Count; i++)
        {
            if (num == i)
            {
                subNodeGroupCtr[i].Show();
            }
            else {
                subNodeGroupCtr[i].Hide();
            }
        }

        BottomBarCtr.instance.UpdateBottomBar(num + 1, subNodeGroupCtr.Count);

        CanvasMangager.instance.ONOFF(true, false);
    }


   public void GoToTarget(int num,List<GameObject> list)
    {

        Vector3 targetPos = MovePos(num);
        //Debug.Log(num);

        Move(targetPos, .5f);

        Display(num, list);

        BottomBarCtr.instance.UpdateBottomBar(num+1, subNodeGroupCtr.Count);

    }



    private void Move(Vector3 pos, float time)
    {

        LeanTween.moveLocal(this.gameObject, pos, time);


    }


    Vector3 MovePos(int num)
    {
        return new Vector3(xPos + num * MoveStep, transform.localPosition.y, transform.localPosition.z);
    }
}
