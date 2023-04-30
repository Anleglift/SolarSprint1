using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Player;
    public AudioClip Boom;
    public AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.clip = Boom;

        Explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            AudioSource.Play();
            Explosion.SetActive(true);
            Explosion.transform.position = Player.transform.position;
            Player.SetActive(false);
            Invoke("ReloadScene", 1.5f);
        }
    }
    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
