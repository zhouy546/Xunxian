using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMangager : MonoBehaviour {
    public GameObject Building;
    public NImage BlackScreen;
    public static CanvasMangager instance;
    public List<GameObject> Obj = new List<GameObject>();

    public List<GameObject> MainTitle = new List<GameObject>();

    public List<Animator> Titleanimators = new List<Animator>();


    public int currentOnShowTitle;

    public Animator ScreenProtectAnim;
    public NImage ScreenProtectNimage;

    public bool isInScreenProtect;
    //public List<GameObject> SubNodeTitle_Eco = new List<GameObject>();
    // public List<GameObject> SubNodeTitle_GongYi = new List<GameObject>();
    // Use this for initialization
    public void initialization() {
        if (instance == null) {
            instance = this;
        }
        BlackScreen.initialization();
        ScreenProtectNimage.initialization();

    }

    // Update is called once per frame
    void Update() {

    }

    public void TurnOffAllTitle() {
        ONOFF(false, false);
        //   ONOFF(false, -1, false, SubNodeTitle_Eco);
        //     ONOFF(false, -1, false, SubNodeTitle_GongYi);

        //foreach (var item in MainTitle)
        //{
        //    item.SetActive(false);
        //}
    }

    public void HideAlltitleText() {
        foreach (var item in Titleanimators)
        {
          item.SetBool("Show", false);
        }
    }

    public void ShowScreenProtect() {
        ScreenProtectAnim.SetBool("Show", true);
        isInScreenProtect = true;
    }

    public void HideScreenProtect() {
        ScreenProtectAnim.SetBool("Show", false);
        isInScreenProtect = false;
    }


    public void ONOFF(bool ONOFF,bool building) {
        //Debug.Log(ONOFF);
         Obj[0].SetActive(ONOFF);



        Building.SetActive(building);
    }


    public void HideCurretTitle() {

        Titleanimators[currentOnShowTitle].SetBool("Show", false);

    }

    public void UpdateTitle(int titleNum, List<GameObject> TitleList) {
        currentOnShowTitle = titleNum;
        for (int i = 0; i < TitleList.Count; i++)
        {
            if (i == titleNum)
            {
               // TitleList[i].SetActive(true);
                Titleanimators[i].SetBool("Show", true);
            }
            else
            {
              //  TitleList[i].SetActive(false);
            }
        }
    }

    public IEnumerator Fade() {
        BlackScreen.ShowAll(1f);
        yield return new WaitForSeconds(1f);
        BlackScreen.HideAll(.7f);
    }
}
