using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount;       //bydefault 0
    [SerializeField] private TMP_Text coinDisplay;
    public static int gemCount;
    [SerializeField] private TMP_Text GemDisplay;
    [SerializeField] private TMP_Text DistanceDisplay;
    public static int distancerun;
    [SerializeField] private int internalDistance; 

    void Update()
    {
        internalDistance = distancerun;
        coinDisplay.text = "" + coinCount;
        GemDisplay.text = "" + gemCount;
        DistanceDisplay.text = "" + distancerun;
    }

    public void PlayAgain()
    {
        this.enabled = false;
        coinCount = 0;
        gemCount = 0;
        distancerun = 0;
        SceneManager.LoadScene(1);
    }

    
}
