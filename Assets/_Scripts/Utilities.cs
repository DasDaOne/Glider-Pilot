using UnityEngine;

namespace Utilities
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;
    
        public static T Instance {
            get
            {
                if (instance)
                    return instance;
            
                instance = FindObjectOfType<T>();
            
                if(instance)
                    return instance;
            
                Debug.LogError($"Cannot find singleton of type {typeof(T)}!");
                return null;
            }
        }
    }
}
