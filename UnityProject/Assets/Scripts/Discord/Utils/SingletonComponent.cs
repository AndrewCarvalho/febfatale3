using UnityEngine;
using System.Collections;

namespace Discord
{

    public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T m_instance;
        private static object m_lock = new object();

        private static bool m_shuttingDown = false;

        public static T Instance
        {
            get
            {
                if ( m_shuttingDown )
                {
                    Debug.Log( "Accessing singleton while destroying!" );
                    return null;
                }

                lock ( m_lock )
                {
                    if ( null == m_instance )
                    {
                        m_instance = FindObjectOfType<T>();
                        if ( null == m_instance )
                        {
                            Debug.Log( "Creating new instance of type " + typeof( T ).ToString() );
                            GameObject singleton = new GameObject();
                            m_instance = singleton.AddComponent<T>();
                            singleton.name = typeof( T ).ToString();
                        }
                    }
                    return m_instance;
                }
            }
        }

        public void OnDestroy()
        {
//            m_shuttingDown = true;
        }
    }

}
