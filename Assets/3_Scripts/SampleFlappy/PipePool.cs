using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;
    public float SpawnTime = 1f;
    public MovePipe PipePrefab;
    public List<MovePipe> ListPipe;
    public void OnEnable()
    {
        InvokeRepeating("SpawnPipe", 1, SpawnTime);
    }
    public void OnDisable()
    {
        CancelInvoke();

        for (int i = 0; i < ListPipe.Count; i++)
        {
                Destroy(ListPipe[i].gameObject);
        }
        ListPipe.Clear();
    }
    public void Awake()
    {
        if (Instance)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    public void SpawnPipe()
    {
        if (GameProperties.IsAlive)
        {
            MovePipe pipe = GetPipe();
            pipe.transform.SetSiblingIndex(PipePrefab.transform.GetSiblingIndex());
            pipe.ResetPipe();
        }
        else
        {
            CancelInvoke();
        }
    }

    public MovePipe GetPipe()
    {
        for (int i = 0; i < ListPipe.Count; i++)
        {
            if (!ListPipe[i].gameObject.activeSelf)
            {
                return ListPipe[i];
            }
        }

        MovePipe obj = CreatePipe();
        ListPipe.Add(obj);
        return obj;
    }

    public MovePipe CreatePipe()
    {
        MovePipe obj = Instantiate<MovePipe>(PipePrefab);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(PipePrefab.transform.parent);
        obj.transform.localScale = Vector3.one;

        return obj;
    }
}
