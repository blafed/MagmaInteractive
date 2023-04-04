using UnityEngine;

public class CameraClampArea : MonoBehaviour
{
    [SerializeField] Rect clampArea = Helper.RectFromCenter(Vector2.zero, new Vector2(100, 100));
    public Rect clampAreaWorld => new Rect(transform.position, transform.localScale);
    private void LateUpdate()
    {
        var obj = CameraControl.instance;
        var targetPosition = obj.center;

        var camera = Camera.main;
        camera.orthographicSize = Mathf.Min(camera.orthographicSize, clampArea.height / 2);
        var size = camera.orthographicSize;
        var aspect = camera.aspect;

        var width = size * 2 * aspect;
        var height = size * 2;

        var halfWidth = width / 2;
        var halfHeight = height / 2;

        var left = targetPosition.x - halfWidth;
        var right = targetPosition.x + halfWidth;
        var top = targetPosition.y + halfHeight;
        var bottom = targetPosition.y - halfHeight;

        if (left < clampAreaWorld.xMin)
            targetPosition.x = clampAreaWorld.xMin + halfWidth;
        if (right > clampAreaWorld.xMax)
            targetPosition.x = clampAreaWorld.xMax - halfWidth;
        if (top > clampAreaWorld.yMax)
            targetPosition.y = clampAreaWorld.yMax - halfHeight;
        if (bottom < clampAreaWorld.yMin)
            targetPosition.y = clampAreaWorld.yMin + halfHeight;
        // targetPosition.x = Mathf.Clamp(targetPosition.x, clampArea.xMin, clampAreaWorld.xMax);
        // targetPosition.y = Mathf.Clamp(targetPosition.y, clampArea.yMin, clampArea.yMax);
        obj.clamperTransform.transform.position = targetPosition.ToVector3();
        // obj.camera.transform.position = targetPosition.ToVector3(obj.camera.transform.position.z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(clampAreaWorld.center, clampAreaWorld.size);
    }

}