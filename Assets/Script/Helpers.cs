using UnityEngine;

public class Helpers
{
    public static GameObject CreateGameObjectFromPrefab(GameObject p_objectToCreate, GameObject p_parentObject, Vector3 p_offset, bool p_isActive = true)
    {
        GameObject newObject = Object.Instantiate(p_objectToCreate);
        newObject.name = p_objectToCreate.name;
        newObject.transform.SetParent(p_parentObject.transform, false);
        newObject.transform.position =
            new Vector3(
                newObject.transform.position.x + p_offset.x,
                newObject.transform.position.y + p_offset.y,
                newObject.transform.position.z + p_offset.z);
        newObject.SetActive(p_isActive);
        return newObject;
    }
}
