using UnityEngine;

/* Author: Jake Moore
 * The only purpose of this script is to hold a composite map, and be able to get the composite map.
 */
public class compositeMap : MonoBehaviour
{
    public Texture2D map;

    public Texture2D getCompositeMap() {
        return map;
    }
}
