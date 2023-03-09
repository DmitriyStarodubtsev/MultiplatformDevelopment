using UnityEngine;
using System.Collections;
public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();              
        Cursor.lockState = CursorLockMode.Locked; // Скрываем указатель мыши в центре экрана
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Реакция на нажатие клавишы мыши 
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); //расчёт середины экрана 
            Ray ray = _camera.ScreenPointToRay(point); // Создание в этой точке луча методом ScreenPointToRay
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SphereIndicator(hit.point)); // Запуск Сопрограммы в ответ на попадание
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos) // Сопрограммы пользуются функциями IEnumerator
    {
        GameObject shpere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        shpere.transform.position = pos;
        yield return new WaitForSeconds(1);

        Destroy(shpere); // Удаляем GameObject(shpere) и очищаем память
    }
    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX,posY, size, size), "*");// Команда GUI.Label отображает на экране символ
    }
}