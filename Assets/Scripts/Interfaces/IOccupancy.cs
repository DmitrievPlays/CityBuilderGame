using UnityEngine;

public interface IOccupancy
{
    int GetMaxOccupancy();

    int GetCurrentOccupancy();

    bool Leave(int amount);

    bool Enter(int amount);
}
