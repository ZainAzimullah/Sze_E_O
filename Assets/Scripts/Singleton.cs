using UnityEngine;
using System.Collections;

/// <summary>
///  This is a Singleton abstract class, we can't make an object of this class or attached to any game object. its just for the any class that want to be singleton. 
/// it help to make singleton design pattern  very quickly and no need to copy and paste the singleton design pattern code. 
/// just inherit any class from this class, the class will be come singleton.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{


    #region | [Fields ] |

    private static T instance = null;

    #endregion

    #region | [  Properties     ] |

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    GameObject singletonGB = new GameObject();
                    instance = singletonGB.AddComponent<T>();
                    singletonGB.name = typeof(T).ToString();
                }
            }
            return instance;
        }
    }


    #endregion

    #region | Method [ Call backs] |

    public virtual void OnApplicationQuit()
    {
        instance = null;
    }

    #endregion

    #region | Methods [ Private ] |


    #endregion

    #region | Methods [ Public ] |


    #endregion

    #region| Methods [Protected] |
    protected void PassObject(Object gameObject)
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    #endregion

}

