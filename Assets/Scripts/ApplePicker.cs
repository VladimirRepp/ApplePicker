using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Settings")]
    public GameObject basketPrefab;
    public int numBasket;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    private void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i<numBasket; i++)
        {
            GameObject basketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            basketGO.transform.position = pos;
            basketList.Add(basketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in apples)
        {
            Destroy(tGO);
        }

        if(basketList.Count > 0)
        {
            int index = basketList.Count - 1;
            GameObject basketGO = basketList[index];
            basketList.RemoveAt(index);
            Destroy(basketGO);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
