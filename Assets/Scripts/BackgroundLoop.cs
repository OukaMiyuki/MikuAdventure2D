using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {
    [SerializeField] private GameObject[] levels;

    private Camera mainCamera;
    private Vector2 screenBounds;
    private Vector3 lastScreenPosition;
    
    void Start() {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels) {
            loadChildObjects(obj);
        }    
        lastScreenPosition = transform.position;
    }


    void Update() {
        
    }

    void loadChildObjects(GameObject obj){
        float spriteObjectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int numberOfChild = (int)Mathf.Ceil(screenBounds.x * 2 / spriteObjectWidth)+1;
        float randY = Random.Range(-1f, 1f);
        float randX = Random.Range(-1f, 1f);
        GameObject spriteClone = Instantiate(obj) as GameObject;
        for(int i=0; i<=numberOfChild; i++){
            GameObject c = Instantiate(spriteClone) as GameObject;
            c.transform.SetParent(obj.transform);
            if(obj.tag == "RandObject"){
                c.transform.position = new Vector3((spriteObjectWidth * i)+randX, obj.transform.position.y+randY, obj.transform.position.z);
                c.name = obj.name + "_child_" + i;
            } else {
                c.transform.position = new Vector3(spriteObjectWidth * i, obj.transform.position.y, obj.transform.position.z);
                c.name = obj.name + i;
            }
        }
        Destroy(spriteClone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

     void FixedUpdate() {
        foreach(GameObject obj in levels){
            repositionChildObjects(obj);
            float parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z));
            float diff = transform.position.x - lastScreenPosition.x;
            obj.transform.Translate(Vector3.right * diff * parallaxSpeed);
        }
        lastScreenPosition = transform.position;
    }

    void repositionChildObjects(GameObject obj){
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1){
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length -1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth){
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            } else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth){
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
}
