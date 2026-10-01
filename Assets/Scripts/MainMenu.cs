using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject fadeOut;
    [SerializeField] private GameObject bounceText;
    [SerializeField] private GameObject bigButton;
    [SerializeField] private GameObject animationCam;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject menuControls;
    [SerializeField] private AudioSource buttonSelectSound;
    public static bool hasClicked;                              // "ClickToStart" Text (Bigbutton) we are talking about
    [SerializeField] private GameObject fadeIn;

    void Start()                    
    {
        StartCoroutine(FadeInTurnOff());
        if(hasClicked == true)                            //"ClickToStart" Text will appear only once in starting of the game
        {
            mainCam.SetActive(true);                 
            animationCam.SetActive(false);
            menuControls.SetActive(true);
            bounceText.SetActive(false);
            bigButton.SetActive(false); 
        }
    }


    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }

    IEnumerator StartButton()
    {
        buttonSelectSound.Play();  
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(0.95f);
        SceneManager.LoadScene(1);
    }

    IEnumerator AnimCam()
    {
        animationCam.GetComponent<Animator>().Play("AnimationCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animationCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;

    }

    IEnumerator FadeInTurnOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }

    
}
