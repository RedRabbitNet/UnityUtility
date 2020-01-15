using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrapComputeShaderSample : MonoBehaviour
{
	[SerializeField] private Camera camera;						//カメラ
	private RenderTexture cameraOutputTexture;					//カメラ出力用テクスチャ
	[SerializeField] private RawImage canvasTexture;			//出力用キャンバス
	[SerializeField] private WrapComputeShader shaderSample;	//シェーダの実行手順をまとめたもの
	
	void Start () {
		//カメラ用のRenderTextureを作成
		cameraOutputTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
		cameraOutputTexture.enableRandomWrite = true;
		cameraOutputTexture.name = "cameraOutputTexture";
		cameraOutputTexture.Create();

		//カメラのレンダリング先をRenderTextureに変更
		camera.targetTexture = cameraOutputTexture;
	}
	
	// Update is called once per frame
	void Update () {
		canvasTexture.texture = shaderSample.Execution(cameraOutputTexture);
	}
}
