using UnityEngine;

public class CollectGem : MonoBehaviour
{
    [SerializeField] private AudioSource GemFX;

    private void OnTriggerEnter(Collider other)
    {
        GemFX.Play();
        MasterInfo.gemCount +=1;
        this.gameObject.SetActive(false);
    }
}
