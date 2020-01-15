using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShader : WrapComputeShader
{
	protected override void Dispatch()
	{
		computeShader.SetTexture(0, "image_in", image_in);
		computeShader.SetTexture(0, "image_out", image_out);

		computeShader.Dispatch(0, outputSize.x/ (int)threadGroupSize[0], outputSize.y/ (int)threadGroupSize[1], 1);
	}
}
