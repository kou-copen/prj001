using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MyGame.System;

namespace MyGame.Game
{
    public class Title : RootBase
    {
        [SerializeField]
        private Button Game1ButtonObj = null;

        [SerializeField]
        private string Game1SceneName = string.Empty;

        public override void Initialize()
        {
            base.Initialize();

            Game1ButtonObj.onClick.AddListener(OnClickGame1Button);
        }

        /// <summary>
        /// Game1ボタンクリック時
        /// </summary>
        private void OnClickGame1Button()
        {
            SceneManagerEx.Instance.LoadSceneAsync("Game");
        }
    }

}