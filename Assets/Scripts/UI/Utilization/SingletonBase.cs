//线程安全的单例基类
public class SingletonBase<T> where T : class, new()
{
    private static T _instance;
    private static readonly object syslock = new object();

    protected SingletonBase()
    {

    }
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                        _instance = new T();
                }
            }
            return _instance;
        }
    }
}
