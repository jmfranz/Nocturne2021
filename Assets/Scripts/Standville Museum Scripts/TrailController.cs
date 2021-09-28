using UnityEngine;

//attaches to the object with the "Trail Renderer" component 
public class TrailController : MonoBehaviour
{
    [SerializeField]
    [Range (0f, 1f)]
    float speed = 0.3f;

    [SerializeField]
    bool _usingParticleSystem;

    [SerializeField]
    Vector3 _startPos = new Vector3();

    [SerializeField]
    Vector3 _endPos = new Vector3();

    bool _moveTrail = false;
    TrailRenderer _trailRenderer;
    float _fraction = 0;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailRenderer.enabled = false;

        _startPos = new Vector3(0f, 0f, 0f);
        _endPos = new Vector3(0f, 0f, 0f);
        _moveTrail = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveTrail)
        {
            _trailRenderer.enabled = true;
            if(_fraction < 1)
            {
                _fraction += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(_startPos, _endPos, _fraction);
            }
            else
            {
                _fraction = 0;
                _moveTrail = false;
                _trailRenderer.enabled = false;
            }
        }
    }

    // Call this to move 
    public void UpdateTrailPosition(Vector3 startTrail, Vector3 endTrail)
    {
        _startPos = startTrail;
        _endPos = endTrail;
        _moveTrail = true;
    }
}
