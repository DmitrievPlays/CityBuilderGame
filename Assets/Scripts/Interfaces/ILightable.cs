using UnityEngine;

public interface ILightable
{
    bool GetLightStatus();

    void SetLightStatus(bool lightStatus);
}
