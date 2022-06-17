using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Tags")] [SerializeField] private string createdTag;

    private void Awake()
    {
        var obj = GameObject.FindWithTag(createdTag);
        var gm = gameObject;
        
        if (obj is null)
        {
            gm.tag = createdTag;
            DontDestroyOnLoad(gm);
        }
        else
            Destroy(gm);
    }
}
