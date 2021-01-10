using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame.System
{
    public class RootBase : MonoBehaviour
    {
        public virtual void Initialize()
        {
            Debug.Log( this.gameObject.scene.name + ":Initialize");
        }
    }
}
