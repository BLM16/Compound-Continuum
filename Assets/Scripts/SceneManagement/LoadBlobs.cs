using UnityEngine;

public class LoadBlobs : MonoBehaviour
{
    /// <summary>
    /// The prefab for the blobs.
    /// </summary>
    public GameObject blobPrefab;

    /// <summary>
    /// The initial number of blobs to load into the scene.
    /// </summary>
    public int initialBlobCount;

	private void Awake()
	{
        var sceneMetadata = GetComponent<SceneMetadata>();

        for (int i = 0; i < initialBlobCount; i++)
        {
            var randX = Random.Range(-sceneMetadata.width / 2, sceneMetadata.width / 2 + 1);
            var randY = Random.Range(-sceneMetadata.height / 2, sceneMetadata.height / 2 + 1);

            var blob = Instantiate(blobPrefab);
            blob.transform.position = new Vector3(randX, randY, 0);
        }
	}
}
