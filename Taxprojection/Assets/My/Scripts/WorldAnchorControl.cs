using UnityEngine;
using System.Collections;
using UnityEngine.XR.WSA.Persistence;
using System;
using UnityEngine.XR.WSA;
using Academy;

public class WorldAnchorControl : MonoBehaviour
{

    //public GameObject ObjectAnchorStore;
    public string objectAnchorStoreName;

    WorldAnchorStore anchorStore;

    void Start()
    {
        //获取WorldAnchorStore 对象
        WorldAnchorStore.GetAsync(AnchorStoreReady);
    }

    private void AnchorStoreReady(WorldAnchorStore store)
    {
        anchorStore = store;
        string[] ids = anchorStore.GetAllIds();
        //遍历之前保存的空间锚，载入指定id场景对象信息
        for (int index = 0; index < ids.Length; index++)
        {
            if (ids[index] == objectAnchorStoreName)
            {
                WorldAnchor wa = anchorStore.Load(ids[index], gameObject);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    //给定目标世界锚点
    public void WorldAnchorOn()
    {
        if (anchorStore == null)
        {
            return;
        }

        //当再次点击全息对象时，保存空间锚信息
        WorldAnchor attachingAnchor = gameObject.AddComponent<WorldAnchor>();
        if (attachingAnchor.isLocated)
        {
            bool saved = anchorStore.Save(objectAnchorStoreName, attachingAnchor);
        }
        else
        {
            //有时空间锚能够立刻被定位到。这时候，给对象添加空间锚后，空间锚组件的isLocated属性
            //值将会被设为true，这时OnTrackingChanged事件将不会被触发。因此，在添加空间锚组件
            //后，推荐立刻使用初始的isLocated状态去调用OnTrackingChanged事件
            attachingAnchor.OnTrackingChanged += AttachingAnchor_OnTrackingChanged;
        }

    }

    //销毁目标世界锚点
    public void WorldAnchorOff()
    {
        //当全息对象已附加空间锚组件后，它不能被移动。如果你需要移动全息对象的话，那么你必须这样做：
        //1.立刻销毁空间锚组件
        //2.移动全息对象
        //3.添加一个新的空间锚到全息对象上
        WorldAnchor anchor = gameObject.GetComponent<WorldAnchor>();
        if (anchor != null)
        {
            DestroyImmediate(anchor);
        }

        string[] ids = anchorStore.GetAllIds();
        for (int index = 0; index < ids.Length; index++)
        {
            if (ids[index] == objectAnchorStoreName)
            {
                bool deleted = anchorStore.Delete(ids[index]);
                break;
            }
        }
    }

    private void AttachingAnchor_OnTrackingChanged(WorldAnchor self, bool located)
    {
        if (located)
        {
            bool saved = anchorStore.Save(objectAnchorStoreName, self);
            self.OnTrackingChanged -= AttachingAnchor_OnTrackingChanged;
        }
    }
}
