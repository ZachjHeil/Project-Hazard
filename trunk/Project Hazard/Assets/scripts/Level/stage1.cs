using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class stage1 : MonoBehaviour
{
    public GameObject levelColliders;
    public GameObject levelInteract;
    public GameObject levelDress;
    public GameObject levelDetonator;
    public GameObject levelExplosive;
    public GameObject levelElevator;
    public GameObject ballee;
    public GameObject cam;
    public NavMeshSurface surface;
    public GameObject hudUI;
    public GameObject gameOverUI;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate (levelColliders, transform.position, transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        surface.BuildNavMesh();
        GameObject.Instantiate (levelInteract, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelElevator, new Vector3(-56.5f, 2.34f, 0f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelDetonator, new Vector3(-60f, 26f, 0f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelExplosive, new Vector3(-13f, 10f, 20f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelDress, transform.position, transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (ballee, new Vector3(0f, 3f, -60f), transform.rotation * Quaternion.Euler (0f, 45f, 0f)); 
        GameObject.Instantiate (cam, transform.position, transform.rotation);
        GameObject.Instantiate (hudUI, transform.position, transform.rotation);
        GameObject.Instantiate (gameOverUI, transform.position, transform.rotation);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(2));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
