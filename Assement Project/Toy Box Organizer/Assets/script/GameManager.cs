
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Sound")]
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource audioSource;

    [Header("Extra")]
    public ParticleSystem playParticle;
    public GameObject endpanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


 //   public Action<bool> gameEnablde;
    public int totalBasket;
    void Start()
    {
        endpanel.SetActive(false);
        StartCoroutine(EndPane());
    }

    //private void Update()
    //{
    //    if(totalBasket == 6) 
    //    {
    //        endpanel.SetActive(true);
    //    }
    //}
    public void PlayParticle() 
    {

        playParticle.Play();
    }
    public void PlaySound(bool isCorrect)
    {
        if (isCorrect)
        {
            audioSource.PlayOneShot(correctSound);
        }
        else
        {
            audioSource.PlayOneShot(incorrectSound);
        }
      
      
    }

    IEnumerator EndPane()
    {
        yield return new WaitUntil(() => totalBasket == 6);
        yield return new WaitForSeconds(1.5f);
        endpanel.SetActive(true);

    }
    public void Restart() 
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
