using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClosingTime : MonoBehaviour
{
    [SerializeField] float minTilClose = 2f;
    [SerializeField] CanvasGroup menu;
    [SerializeField] GameObject player;
    TextMeshProUGUI clock;
    float secTilClose;

    [SerializeField] float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<TextMeshProUGUI>();
        secTilClose = minTilClose * 60;
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.Floor(secTilClose / 60);
        float seconds = Mathf.Floor(secTilClose % 60);

        secTilClose -= Time.deltaTime;
        if (secTilClose < 0)
        {
            GameOver();
        }
        else
        {
            clock.SetText("{0:0}:{1:00} UNTIL CLOSING", minutes, seconds);
        }
    }

    void GameOver()
    {
        player.GetComponent<PlayerMovement>().runSpeed = 0f;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            menu.alpha = Mathf.Lerp(0, 1, counter / duration);
            yield return null;
        }
        yield return null;
    }

    public void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
