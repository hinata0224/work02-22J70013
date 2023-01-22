using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private static CompositeDisposable disposables = new();

    private void Start()
    {
        GetComponent<Button>().OnClickAsObservable()
            .Subscribe(_ => SceneMovement(sceneName))
            .AddTo(disposables);
    }
    public static void SceneMovement(string _name)
    {
        disposables.Dispose();
        SceneManager.LoadSceneAsync(_name);
    }
}
