﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame.System
{
    public class Boot : MonoBehaviour
    {
        const string SceneNameBoot = "Boot";
        const string SceneNameTitle = "Title";

        static private string m_StartSceneName = string.Empty;

        /// <summary>
        /// システム起動時の処理
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void SystemBoot()
        {
            // 編集中のシーンがBootの場合はTitleから始まる様にシーン名称を設定する
            // 開発中は編集中のシーンをロードする。その場合Bootシーンが無いのでロードする。
            m_StartSceneName = SceneManager.GetActiveScene().name;
            if( m_StartSceneName == SceneNameBoot )
            {
                // Bootシーンの次に遷移するシーン名称を決める
                m_StartSceneName = SceneNameTitle;
            }
            else
            {
                // Bootシーンが無ければロードする
                SceneManager.LoadScene(SceneNameBoot);
            }
            Debug.Log("m_StartSceneName = " + m_StartSceneName);
        }

        private void Awake()
        {
            // シーンマネージャーの初期設定
            SceneManagerEx.Instance.Initialize();

            // 初期画面シーン(もしくは開発中のシーン)を読み込む
            if (m_StartSceneName != SceneNameBoot)
            {
                SceneManagerEx.Instance.LoadSceneAsync(m_StartSceneName);
            }
        }
    }
}
