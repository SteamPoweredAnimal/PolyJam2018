Shader "hidden/preview"
{
	Properties
	{
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_522A15F1_Tex("Texture", 2D) = "white" {}
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
			{
			    Out = A * B;
			}
			void Unity_Multiply_float(float A, float B, out float Out)
			{
			    Out = A * B;
			}
			void Unity_Sine_float(float In, out float Out)
			{
			    Out = sin(In);
			}
			void Unity_Add_float(float A, float B, out float Out)
			{
			    Out = A + B;
			}
			void Unity_Power_float(float A, float B, out float Out)
			{
			    Out = pow(A, B);
			}
			void Unity_Cosine_float(float In, out float Out)
			{
			    Out = cos(In);
			}
			void Unity_Clamp_float(float In, float Min, float Max, out float Out)
			{
			    Out = clamp(In, Min, Max);
			}
			void Unity_Lerp_float(float4 A, float4 B, float4 T, out float4 Out)
			{
			    Out = lerp(A, B, T);
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
				half4 uv0;
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_CC214D38;
			float4 Color_E0DB4C3B;
			float4 Color_66A2BAED;
			UNITY_DECLARE_TEX2D(_SampleTexture2D_522A15F1_Tex);
			float4 _SampleTexture2D_522A15F1_UV;
			float4 _Multiply_EF228037_B;
			float _Multiply_FD05A340_B;
			float _Add_767D71F7_B;
			float _Power_9BB21226_B;
			float _Multiply_8DD4714C_B;
			float _Add_C485FED0_B;
			float _Multiply_465726C7_B;
			float _Multiply_6924DB3A_B;
			float _Clamp_D94F8869_Min;
			float _Clamp_D94F8869_Max;
			float4 _Multiply_14091557_B;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				half4 uv0 = IN.uv0;
				float4 _SampleTexture2D_522A15F1_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_522A15F1_Tex,uv0.xy);
				float _SampleTexture2D_522A15F1_R = _SampleTexture2D_522A15F1_RGBA.r;
				float _SampleTexture2D_522A15F1_G = _SampleTexture2D_522A15F1_RGBA.g;
				float _SampleTexture2D_522A15F1_B = _SampleTexture2D_522A15F1_RGBA.b;
				float _SampleTexture2D_522A15F1_A = _SampleTexture2D_522A15F1_RGBA.a;
				if (Float_CC214D38 == 0) { surface.PreviewOutput = half4(_SampleTexture2D_522A15F1_RGBA.x, _SampleTexture2D_522A15F1_RGBA.y, _SampleTexture2D_522A15F1_RGBA.z, 1.0); return surface; }
				float4 _Multiply_EF228037_Out;
				Unity_Multiply_float(Color_66A2BAED, _Multiply_EF228037_B, _Multiply_EF228037_Out);
				if (Float_CC214D38 == 1) { surface.PreviewOutput = half4(_Multiply_EF228037_Out.x, _Multiply_EF228037_Out.y, _Multiply_EF228037_Out.z, 1.0); return surface; }
				float4 _Multiply_EA310F84_Out;
				Unity_Multiply_float((_SampleTexture2D_522A15F1_B.xxxx), _Multiply_EF228037_Out, _Multiply_EA310F84_Out);
				if (Float_CC214D38 == 2) { surface.PreviewOutput = half4(_Multiply_EA310F84_Out.x, _Multiply_EA310F84_Out.y, _Multiply_EA310F84_Out.z, 1.0); return surface; }
				float4 _Multiply_3DD5A703_Out;
				Unity_Multiply_float((_SampleTexture2D_522A15F1_R.xxxx), Color_E0DB4C3B, _Multiply_3DD5A703_Out);
				if (Float_CC214D38 == 3) { surface.PreviewOutput = half4(_Multiply_3DD5A703_Out.x, _Multiply_3DD5A703_Out.y, _Multiply_3DD5A703_Out.z, 1.0); return surface; }
				float _Multiply_FD05A340_Out;
				Unity_Multiply_float(_Time.y, _Multiply_FD05A340_B, _Multiply_FD05A340_Out);
				if (Float_CC214D38 == 4) { surface.PreviewOutput = half4(_Multiply_FD05A340_Out, _Multiply_FD05A340_Out, _Multiply_FD05A340_Out, 1.0); return surface; }
				float _Sine_8DFBD739_Out;
				Unity_Sine_float(_Multiply_FD05A340_Out, _Sine_8DFBD739_Out);
				if (Float_CC214D38 == 5) { surface.PreviewOutput = half4(_Sine_8DFBD739_Out, _Sine_8DFBD739_Out, _Sine_8DFBD739_Out, 1.0); return surface; }
				float _Add_767D71F7_Out;
				Unity_Add_float(_Sine_8DFBD739_Out, _Add_767D71F7_B, _Add_767D71F7_Out);
				if (Float_CC214D38 == 6) { surface.PreviewOutput = half4(_Add_767D71F7_Out, _Add_767D71F7_Out, _Add_767D71F7_Out, 1.0); return surface; }
				float _Power_9BB21226_Out;
				Unity_Power_float(_Add_767D71F7_Out, _Power_9BB21226_B, _Power_9BB21226_Out);
				if (Float_CC214D38 == 7) { surface.PreviewOutput = half4(_Power_9BB21226_Out, _Power_9BB21226_Out, _Power_9BB21226_Out, 1.0); return surface; }
				float _Multiply_8DD4714C_Out;
				Unity_Multiply_float(_Power_9BB21226_Out, _Multiply_8DD4714C_B, _Multiply_8DD4714C_Out);
				if (Float_CC214D38 == 8) { surface.PreviewOutput = half4(_Multiply_8DD4714C_Out, _Multiply_8DD4714C_Out, _Multiply_8DD4714C_Out, 1.0); return surface; }
				float _Add_C485FED0_Out;
				Unity_Add_float(_Multiply_8DD4714C_Out, _Add_C485FED0_B, _Add_C485FED0_Out);
				if (Float_CC214D38 == 9) { surface.PreviewOutput = half4(_Add_C485FED0_Out, _Add_C485FED0_Out, _Add_C485FED0_Out, 1.0); return surface; }
				float _Multiply_465726C7_Out;
				Unity_Multiply_float(_Time.y, _Multiply_465726C7_B, _Multiply_465726C7_Out);
				if (Float_CC214D38 == 10) { surface.PreviewOutput = half4(_Multiply_465726C7_Out, _Multiply_465726C7_Out, _Multiply_465726C7_Out, 1.0); return surface; }
				float _Cosine_BA0CA376_Out;
				Unity_Cosine_float(_Multiply_465726C7_Out, _Cosine_BA0CA376_Out);
				if (Float_CC214D38 == 11) { surface.PreviewOutput = half4(_Cosine_BA0CA376_Out, _Cosine_BA0CA376_Out, _Cosine_BA0CA376_Out, 1.0); return surface; }
				float _Multiply_6924DB3A_Out;
				Unity_Multiply_float(_Cosine_BA0CA376_Out, _Multiply_6924DB3A_B, _Multiply_6924DB3A_Out);
				if (Float_CC214D38 == 12) { surface.PreviewOutput = half4(_Multiply_6924DB3A_Out, _Multiply_6924DB3A_Out, _Multiply_6924DB3A_Out, 1.0); return surface; }
				float _Add_F3B41850_Out;
				Unity_Add_float(_Add_C485FED0_Out, _Multiply_6924DB3A_Out, _Add_F3B41850_Out);
				if (Float_CC214D38 == 13) { surface.PreviewOutput = half4(_Add_F3B41850_Out, _Add_F3B41850_Out, _Add_F3B41850_Out, 1.0); return surface; }
				float _Clamp_D94F8869_Out;
				Unity_Clamp_float(_Add_F3B41850_Out, _Clamp_D94F8869_Min, _Clamp_D94F8869_Max, _Clamp_D94F8869_Out);
				if (Float_CC214D38 == 14) { surface.PreviewOutput = half4(_Clamp_D94F8869_Out, _Clamp_D94F8869_Out, _Clamp_D94F8869_Out, 1.0); return surface; }
				float4 _Lerp_B49E4547_Out;
				Unity_Lerp_float(_Multiply_EA310F84_Out, _Multiply_3DD5A703_Out, (_Clamp_D94F8869_Out.xxxx), _Lerp_B49E4547_Out);
				if (Float_CC214D38 == 15) { surface.PreviewOutput = half4(_Lerp_B49E4547_Out.x, _Lerp_B49E4547_Out.y, _Lerp_B49E4547_Out.z, 1.0); return surface; }
				float4 _Multiply_E10EC811_Out;
				Unity_Multiply_float(_Lerp_B49E4547_Out, (_SampleTexture2D_522A15F1_A.xxxx), _Multiply_E10EC811_Out);
				if (Float_CC214D38 == 16) { surface.PreviewOutput = half4(_Multiply_E10EC811_Out.x, _Multiply_E10EC811_Out.y, _Multiply_E10EC811_Out.z, 1.0); return surface; }
				float4 _Multiply_14091557_Out;
				Unity_Multiply_float(_Multiply_E10EC811_Out, _Multiply_14091557_B, _Multiply_14091557_Out);
				if (Float_CC214D38 == 17) { surface.PreviewOutput = half4(_Multiply_14091557_Out.x, _Multiply_14091557_Out.y, _Multiply_14091557_Out.z, 1.0); return surface; }
				return surface;
			}
	ENDCG
	SubShader
	{
	    Tags { "RenderType"="Opaque" }
	    LOD 100
	    Pass
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"
	        struct GraphVertexOutput
	        {
	            float4 position : POSITION;
	            half4 uv0 : TEXCOORD;
	        };
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            o.uv0 = v.texcoord0;
	            return o;
	        }
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            float4 uv0  = IN.uv0;
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            surfaceInput.uv0 = uv0;
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	        }
	        ENDCG
	    }
	}
}
