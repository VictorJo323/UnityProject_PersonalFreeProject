using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncountBattle : MonoBehaviour
{
    public float encounterRate = 0.15f;
    private Vector2 lastPosition;
    private Coroutine battleCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("들어감");
            lastPosition = collision.transform.position;
            if (battleCoroutine == null)
            {
                StartCoroutine(BattleCoroutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("나감");
            StopCoroutine(BattleCoroutine());
            battleCoroutine = null;
        }
    }

    private IEnumerator BattleCoroutine()
    {
        while(true)
        {
            if(IsBattleOn())
            { 
                yield break; 
            }
            float time = Random.Range(1f, 2f);
            yield return new WaitForSeconds(time);
        }
    }
    private bool IsBattleOn()
    {
        if(Random.value <= encounterRate)
        {
            GameManager.Instance.SavePosition(lastPosition);
            SceneManager.LoadScene("BattleScene");
            return true;
        }
        return false;
    }

    public void ReturnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
