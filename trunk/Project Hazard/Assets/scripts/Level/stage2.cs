using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class stage2 : MonoBehaviour
{
    public GameObject levelColliders;
    public GameObject levelInteract;
    public GameObject levelCharger;
    public GameObject levelElevator;
    public GameObject ballee;
    public GameObject cam;
    public NavMeshSurface surface;
    public GameObject hudUI;
    public GameObject gameOverUI;
    public Animator transition;

    public bool canExit;
    public int chargedPads = 0;
    public bool playercharging = false;

    void Start()
    {
        GameObject.Instantiate (levelColliders, transform.position, transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        surface.BuildNavMesh();
        GameObject.Instantiate (levelInteract, new Vector3(0.0f, 3.0f, 0.0f), transform.rotation * Quaternion.Euler (0f, 0f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(-14f, 5.4f, -39f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(-9.5f, 5.4f, 29f), transform.rotation * Quaternion.Euler (0f, 135f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(0f, 30.4f, 56f), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
        GameObject.Instantiate (levelElevator, new Vector3(0f, 18.34f, -57.75f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (ballee, new Vector3(-58.0f, 40.0f, 8.0f), transform.rotation * Quaternion.Euler (0f, 45f, 0f)); 
        GameObject.Instantiate (cam, transform.position, transform.rotation);
        GameObject.Instantiate (hudUI, transform.position, transform.rotation);
        GameObject.Instantiate (gameOverUI, transform.position, transform.rotation);

        canExit = false;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
