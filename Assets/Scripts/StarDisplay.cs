using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField]
    int stars = 100;
    TextMeshProUGUI starText;

    /***
    *       Start is called before the first frame update
    ***/
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }   // Start()

    /***
    *       UpdateDisplay will update the number of stars we have available whenever it changes.
    ***/
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }   // UpdateDisplay()

    /***
    *       AddStars will update the number of stars we have available when we get more.
    ***/
    public void AddStars(int amount)
	{
        stars += amount;
        UpdateDisplay();
	}   // AddStars()

    /***
    *       SpendStars will update the number of stars we have available when we use some,
    *   but only if we have enough.
    ***/
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }   // if
    }   // SpendStars()
}   // class StarDisplay