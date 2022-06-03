using UnityEngine;
using Cinemachine;
public class RoundCameraPos : CinemachineExtension
{
    [SerializeField] private float _ppu = 32;
    protected override void PostPipelineStageCallback(
    CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage,
    ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos.x),
            Round(pos.y), pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }
    private float Round(float x)
    {
        return Mathf.Round(x * _ppu) / _ppu;
    }
}