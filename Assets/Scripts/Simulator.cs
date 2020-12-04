using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{

    public GameObject SessionOrigin;
    public GameObject Camera;
    public GameObject WorldPrefab;

    private GameObject world;

#if UNITY_EDITOR
    
    private void OnEnable()
    {
        world = Instantiate(WorldPrefab, SessionOrigin.transform.position, SessionOrigin.transform.rotation);
        
		world.transform.SetParent(SessionOrigin.transform, true);
        world.transform.localPosition = new Vector3(0, 0, 1);
        world.transform.localRotation = Quaternion.Euler(-30, 0, 0);
		
        Camera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
    }

    private void OnDisable()
    {
        if (Application.isEditor)
        {
            GameObject.Destroy(world);
        }
    }

    public void SimulateMoveForward(float speed_)
    {
        Camera.transform.Translate(Vector3.forward * Time.deltaTime * speed_);
    }

    public void SimulateMoveBackward(float speed_)
    {
        Camera.transform.Translate(Vector3.back * Time.deltaTime * speed_);
    }

    public void SimulateMoveLeft(float speed_)
    {
        Camera.transform.Translate(Vector3.left * Time.deltaTime * speed_);
    }

    public void SimulateMoveRight(float speed_)
    {
        Camera.transform.Translate(Vector3.right * Time.deltaTime * speed_);
    }

    public void SimulateRotateUp(float speed_)
    {
        Camera.transform.RotateAround(world.transform.position, Vector3.left, Time.deltaTime * speed_);
    }

    public void SimulateRotateDown(float speed_)
    {
        Camera.transform.RotateAround(world.transform.position, Vector3.right, Time.deltaTime * speed_);
    }

    public void SimulateRotateLeft(float speed_)
    {
        Camera.transform.RotateAround(world.transform.position, Vector3.up, Time.deltaTime * speed_);
    }

    public void SimulateRotateRight(float speed_)
    {
        Camera.transform.RotateAround(world.transform.position, Vector3.down, Time.deltaTime * speed_);
    }


#endif

}
