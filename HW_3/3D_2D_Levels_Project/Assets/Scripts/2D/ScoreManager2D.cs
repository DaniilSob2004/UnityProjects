using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager2D : MonoBehaviour
{
    [SerializeField] private Player2D player;
    [SerializeField] private int nextSceneIndex;

    private List<Dirt2D> dirts;

    private void Start()
    {
        dirts = new List<Dirt2D>(FindObjectsOfType<Dirt2D>());
    }

    private void OnEnable()
    {
        player.OnDirtPickUp += CheckDirt;
    }

    private void OnDisable()
    {
        player.OnDirtPickUp -= CheckDirt;
    }

    private void CheckDirt()
    {
        var activeDirts = dirts.FindAll(dirt => dirt.gameObject.activeSelf);

        if (activeDirts.Count == 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            print("Dirt!");
        }
    }
}
