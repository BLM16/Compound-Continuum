using UnityEngine;

public class Blob : MonoBehaviour
{
    /// <summary>
    /// The maximum velocity the blob can start at in either direction.
    /// </summary>
    public float maxInitialVelocity = 10;

    /// <summary>
    /// The number of bonds the blob can form.
    /// </summary>
	public int bondingCapacity;

    /// <summary>
    /// The relative attraction the blob has towards other blobs.
    /// Similar to electronegativity.
    /// </summary>
    public int relativeAttraction;

    /// <summary>
    /// The relative repulsion the blob has towards other blobs.
    /// Similar to ionization energy.
    /// </summary>
    public int relativeRepulsion;

    /// <summary>
    /// The velocity of the blob.
    /// </summary>
    private Vector2 velocity;

	/// <summary>
	/// The metadata for the current scene.
	/// </summary>
	private SceneMetadata sceneMetadata;

    void Start()
    {
        velocity = new Vector2(Random.Range(-maxInitialVelocity, maxInitialVelocity),
							   Random.Range(-maxInitialVelocity, maxInitialVelocity));

		sceneMetadata = GameObject.Find("SceneManager").GetComponent<SceneMetadata>();
	}

    void Update()
	{
		// Update the position of the blob
		transform.Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);
		ConstrainPositionToScene(sceneMetadata.width, sceneMetadata.height);
	}

	/// <summary>
	/// Constrains the position of the blob to the scene.
	/// This causes the blob to bounce off the scene boundaries.
	/// </summary>
	/// <param name="sceneWidth">The width of the current scene</param>
	/// <param name="sceneHeight">The height of the current scene</param>
	private void ConstrainPositionToScene(int sceneWidth, int sceneHeight)
	{
		if (transform.position.x < -sceneWidth / 2)
		{
			transform.position = new Vector3(-sceneWidth / 2, transform.position.y, transform.position.z);
			velocity.x = -velocity.x;
		}
		else if (transform.position.x > sceneWidth / 2)
		{
			transform.position = new Vector3(sceneWidth / 2, transform.position.y, transform.position.z);
			velocity.x = -velocity.x;
		}
		if (transform.position.y < -sceneHeight / 2)
		{
			transform.position = new Vector3(transform.position.x, -sceneHeight / 2, transform.position.z);
			velocity.y = -velocity.y;
		}
		else if (transform.position.y > sceneHeight / 2)
		{
			transform.position = new Vector3(transform.position.x, sceneHeight / 2, transform.position.z);
			velocity.y = -velocity.y;
		}
	}
}
