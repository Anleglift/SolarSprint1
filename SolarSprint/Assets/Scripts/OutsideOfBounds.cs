using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideOfBounds : MonoBehaviour
{
    public GameObject Player;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Text.SetActive(true);
            Invoke("RestartLevel", 5f);
        }
    }
    private void RestartLevel()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}

