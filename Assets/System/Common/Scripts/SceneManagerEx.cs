using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame.System
{
    public class SceneManagerEx : SingletonMonoBehaviour<SceneManagerEx>
    {
        public void Initialize()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }

        /// <summary>
        /// シーンの非同期読み込み
        /// </summary>
        /// <param name="inSceneName"></param>
        public void LoadSceneAsync(string inSceneName)
        {
            StartCoroutine(LoadSceneCoroutine(inSceneName));
        }

        /// <summary>
        /// シーンの非同期読み込み実行部。
        /// </summary>
        /// <param name="inSceneName"></param>
        /// <returns></returns>
        private IEnumerator LoadSceneCoroutine(string inSceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(inSceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        /// <summary>
        /// シーンロード後の処理
        /// </summary>
        /// <param name="nextScene"></param>
        /// <param name="mode"></param>
        private void SceneLoaded( Scene nextScene, LoadSceneMode mode)
        {
            Debug.Log("NextScene:" + nextScene.name);

            // 各シーンの初期化処理を呼び出す
            GameObject[] SceneRootObjArray = GameObject.FindGameObjectsWithTag("SceneRoot");
            for ( int i = 0; i < SceneRootObjArray.Length; i++ )
            {
                SceneRootObjArray[i].GetComponent<RootBase>().Initialize();
            }
        }

    }
}