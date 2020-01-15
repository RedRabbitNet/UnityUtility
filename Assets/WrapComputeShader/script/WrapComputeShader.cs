using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ComputeShader実装に必要な一連の処理をまとめたクラス
/// </summary>
public abstract class WrapComputeShader : MonoBehaviour
{
	[SerializeField] protected ComputeShader computeShader;
	protected uint[] threadGroupSize = new uint[3];

	protected Texture image_in;
	protected RenderTexture image_out;

	[SerializeField] protected Vector2Int inputSize;
	[SerializeField] protected Vector2Int outputSize;

	/// <summary>
	/// 注意：オーバーライドしないこと
	/// </summary>
	void Start()
	{
		computeShader.GetKernelThreadGroupSizes(0, out threadGroupSize[0], out threadGroupSize[1], out threadGroupSize[2]);

		Initialize();
	}

	/// <summary>
	/// 初期化関数
	/// Start()がオーバーライドできないためこちらに初期化処理を実装する
	/// </summary>
	protected virtual void Initialize() { }

	/// <summary>
	/// 実行関数
	/// この関数を呼び出すことで一連の処理をすべて行う
	/// </summary>
	/// <param name="setImage"></param>
	/// <returns></returns>
	public RenderTexture Execution(Texture setImage)
	{
		SetInputTexture(setImage);
		CreateOutputTexture();
		Dispatch();

		return image_out;
	}

	/// <summary>
	/// 実行用抽象関数
	/// SetFloat等の変数設定とComputeShader.Dispatch()を実装する必要がある
	/// </summary>
	protected abstract void Dispatch();

	private void CreateOutputTexture()
	{
		if (image_out != null)
			return;

		image_out = new RenderTexture(outputSize.x, outputSize.y, 0, RenderTextureFormat.ARGB32);
		image_out.enableRandomWrite = true;
		image_out.name = "shaderOutput";
		image_out.Create();
	}

	///入力画像の設定
	private void SetInputTexture(Texture setImage)
	{
		image_in = setImage;
	}

}