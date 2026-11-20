
using UnityEngine;

public class OutfitSelector : MonoBehaviour
{
    public GameObject top1;
    public GameObject top2;
    public GameObject top3;

    public GameObject bottom1;
    public GameObject bottom2;
    public GameObject bottom3;

    public GameObject shoes1;
    public GameObject shoes2;

    public void SelectTop1()
    {
        top1.SetActive(true);
        top2.SetActive(false);
        top3.SetActive(false);
    }

    public void SelectTop2()
    {
        top1.SetActive(false);
        top2.SetActive(true);
        top3.SetActive(false);
    }

    public void SelectTop3()
    {
        top1.SetActive(false);
        top2.SetActive(false);
        top3.SetActive(true);
    }

    public void SelectBottom1()
    {
        bottom1.SetActive(true);
        bottom2.SetActive(false);
        bottom3.SetActive(false);
    }

    public void SelectBottom2()
    {
        bottom1.SetActive(false);
        bottom2.SetActive(true);
        bottom3.SetActive(false);
    }

    public void SelectBottom3()
    {
        bottom1.SetActive(false);
        bottom2.SetActive(false);
        bottom3.SetActive(true);
    }

    public void SelectShoes1()
    {
        shoes1.SetActive(true);
        shoes2.SetActive(false);
    }

    public void SelectShoes2()
    {
        shoes1.SetActive(false);
        shoes2.SetActive(true);
    }
}

