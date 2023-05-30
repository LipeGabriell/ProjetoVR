using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    Scene loading;
    Scene level;
    //define quantos segundos vai ficar na telazinha inicial
    [SerializeField] float seconds;

    private void Start()
    {
        Invoke(nameof(sceneChange), 10f);
    }

    void sceneChange()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: 1);

    }
}