using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionDetect : MonoBehaviour
{
    [SerializeField] private GameObject theplayer;
    [SerializeField] private Animator playeranim;
    [SerializeField] private AudioSource collisonFX;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject fadeOut;

    void Start()
    {
        // 1. Find the Player using its Tag
        theplayer = GameObject.FindGameObjectWithTag("Player");

        // 2. Get the Animator directly from the Player we just found
        if (theplayer != null)
        {
            // 1. Find the specific child object by its exact name
            Transform characterModel = theplayer.transform.Find("Aj@Running");

            // 2. Get the Animator directly from that specific object
            if (characterModel != null)
            {
                playeranim = characterModel.GetComponent<Animator>();
            }
        }

        // 3. Find the Main Camera automatically
        mainCam = Camera.main.gameObject;

        // Find the active Canvas first, then find the inactive child named "FadeOut"
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        fadeOut = canvasTransform.Find("FadeOut").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }

    IEnumerator CollisionEnd()
    {
        collisonFX.Play();
        theplayer.GetComponent<PlayerMovement>().enabled = false;
        playeranim.Play("Stumble Backwards");
        mainCam.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(3);                         // we wanted time wait so thats why we made a coroutine 
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);                         // we wanted time wait so thats why we made a coroutine        
        SceneManager.LoadScene(4);
    }
}
