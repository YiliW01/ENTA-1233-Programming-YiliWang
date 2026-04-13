using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;

public class HealthBar : MonoBehaviour
{
    private CinemachineCamera mainCamera;

    [SerializeField] private Image _healthFillImage;

    [SerializeField] private Health _enemyHealth;

    private void Start()
    {
        _enemyHealth.OnHealthChanged += RefreshHealthBar;
        if (_enemyHealth != null) _enemyHealth.OnDied += DisableBar;
        RefreshHealthBar(_enemyHealth);
    }

    private void Update()
    {
        mainCamera = CameraManager.Instance._activeCamera;
        AlignCamera();
    }
    private void AlignCamera()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

    private void RefreshHealthBar(Health health)
    {
        if (_healthFillImage == null) return;
        _healthFillImage.fillAmount = health != null ? health.NormalizedHealth : 0f;
    }

    private void DisableBar()
    {
        Destroy(gameObject);
    }
}
