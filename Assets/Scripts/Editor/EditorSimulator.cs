using UnityEngine;
using UnityEditor;

public class MySimulator : EditorWindow 
{

    [MenuItem("Window/MySimulator")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        MySimulator window = (MySimulator)EditorWindow.GetWindow(typeof(MySimulator));
        window.Show();
    }

    private float moving_speed = 1.0f;
    private float rotating_speed = 10.0f;

    void OnGUI()
    {
        Simulator[] simulators = GameObject.FindObjectsOfType<Simulator>();
        GUILayout.Label("Found " + simulators.Length + " simulator object(s)", EditorStyles.boldLabel);
        moving_speed = EditorGUILayout.FloatField("moving speed", moving_speed);
        rotating_speed = EditorGUILayout.FloatField("rotating speed", rotating_speed);
        if (Application.isPlaying)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.RepeatButton("Forward")) 
                MoveForward(simulators);
            if (GUILayout.RepeatButton("Backward"))
                MoveBackward(simulators);
            if (GUILayout.RepeatButton("Left"))
                MoveLeft(simulators);
            if (GUILayout.RepeatButton("Right"))
                MoveRight(simulators);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.RepeatButton("Rotate Up"))
                RotateUp(simulators);
            if (GUILayout.RepeatButton("Rotate Down"))
                RotateDown(simulators);
            if (GUILayout.RepeatButton("Rotate Left"))
                RotateLeft(simulators);
            if (GUILayout.RepeatButton("Rotate Right"))
                RotateRight(simulators);
            GUILayout.EndHorizontal();

        }
    }


    void MoveForward(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateMoveForward(moving_speed);
    }

    void MoveBackward(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateMoveBackward(moving_speed);
    }

    void MoveLeft(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateMoveLeft(moving_speed);
    }

    void MoveRight(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateMoveRight(moving_speed);
    }

    void RotateUp(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateRotateUp(rotating_speed);
    }

    void RotateDown(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateRotateDown(rotating_speed);
    }

    void RotateLeft(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateRotateLeft(rotating_speed);
    }

    void RotateRight(Simulator[] simulators_)
    {
        foreach (Simulator s in simulators_) s.SimulateRotateRight(rotating_speed);
    }

}