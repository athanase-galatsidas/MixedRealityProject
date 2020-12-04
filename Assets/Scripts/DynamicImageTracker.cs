using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class DynamicImageTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _worlds;

    ARTrackedImageManager m_image_tracker;
    Dictionary<int, GameObject> m_spawned_worlds = new Dictionary<int, GameObject>();

    private void Awake()
    {
        m_image_tracker = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        m_image_tracker.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        m_image_tracker.trackedImagesChanged -= OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage i in args.added)
        {
            for (int j = 0; j < _worlds.Length; j++)
            {
                if (i.referenceImage.name == _worlds[j].name)
                {
                    m_spawned_worlds.Add(i.GetInstanceID(), Instantiate(_worlds[j], i.transform.position, Quaternion.identity));
                }
            }

            /*if (i.referenceImage.name == "TestObj")
            {
                m_spawned_worlds.Add(i.GetInstanceID(), Instantiate(world1, i.transform.position, i.transform.rotation));
            }
            else if (i.referenceImage.name == "TestObj2")
            {
                m_spawned_worlds.Add(i.GetInstanceID(), Instantiate(world2, i.transform.position, i.transform.rotation));
            }*/
        }

        foreach (ARTrackedImage i in args.updated)
        {
            int id = i.GetInstanceID();
            if (m_spawned_worlds.ContainsKey(id))
            {
                m_spawned_worlds[id].transform.position = i.transform.position;
                m_spawned_worlds[id].transform.rotation = i.transform.rotation;
            }
        }

        foreach (ARTrackedImage i in args.removed)
        {
            int id = i.GetInstanceID();
            if (m_spawned_worlds.ContainsKey(id))
            {
                Object.Destroy(m_spawned_worlds[id]);
                m_spawned_worlds.Remove(id);
            }
        }
    }
}