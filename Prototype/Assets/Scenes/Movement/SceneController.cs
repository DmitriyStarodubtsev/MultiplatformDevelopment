using System.Numerics;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;//Сериализованная переменная для связи  с объектом-шаблоном
    private GameObject _enemy;//Закрытая перемменная для слежения за экземпляром врага в сцене 
    
    void Start()
    {
        
    }

    void Update()
    {
        if(_enemy == null){//Порождает нового врага, только если в сцене отсутствуют враги 
            _enemy = Instantiate(enemyPrefab) as GameObject;//Метод, копирующий объект-шаблон
            _enemy.transform.position = new UnityEngine.Vector3(0,1,0);

            float angle = Random.Range(0,360);
            _enemy.transform.Rotate(0,angle,0);
        }
    }
}
