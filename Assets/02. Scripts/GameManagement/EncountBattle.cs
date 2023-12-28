using System;
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
            if (battleCoroutine != null)
            {
                StopCoroutine(battleCoroutine);
                battleCoroutine = null;
            }
        }
    }

    private IEnumerator BattleCoroutine()
    {
        while(true)
        {
            float time = UnityEngine.Random.Range(3f, 6f);
            yield return new WaitForSeconds(time);
            UpdatePositionInfo();

            if (IsBattleOn())
            {
                yield break;
            }
        }
    }

    private void UpdatePositionInfo()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player!=null)
        {
            lastPosition = player.transform.position;
        }
    }

    private bool IsBattleOn()
    {
        if(UnityEngine.Random.value <= encounterRate)
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
