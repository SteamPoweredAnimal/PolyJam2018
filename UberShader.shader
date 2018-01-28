Shader "hidden/preview"
{
	Properties
	{
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_Lerp_float(float4 A, float4 B, float4 T, out float4 Out)
			{
			    Out = lerp(A, B, T);
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
			void Unity_Divide_float(float A, float B, out float Out)
			{
			    Out = A / B;
			}
			void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
			{
			    Out = A * B;
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_1502402;
			float4 Color_E0DB4C3B;
			float4 Color_66A2BAED;
			float4 _Lerp_B49E4547_T;
			float _Multiply_FD05A340_B;
			float _Add_F619C33A_B;
			float _Add_767D71F7_B;
			float _Divide_D7A895AB_B;
			float _Multiply_8DD4714C_B;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				float4 _Lerp_B49E4547_Out;
				Unity_Lerp_float(Color_66A2BAED, Color_E0DB4C3B, _Lerp_B49E4547_T, _Lerp_B49E4547_Out);
				if (Float_1502402 == 0) { surface.PreviewOutput = half4(_Lerp_B49E4547_Out.x, _Lerp_B49E4547_Out.y, _Lerp_B49E4547_Out.z, 1.0); return surface; }
				float _Multiply_FD05A340_Out;
				Unity_Multiply_float(_Time.y, _Multiply_FD05A340_B, _Multiply_FD05A340_Out);
				if (Float_1502402 == 1) { surface.PreviewOutput = half4(_Multiply_FD05A340_Out, _Multiply_FD05A340_Out, _Multiply_FD05A340_Out, 1.0); return surface; }
				float _Sine_8DFBD739_Out;
				Unity_Sine_float(_Multiply_FD05A340_Out, _Sine_8DFBD739_Out);
				if (Float_1502402 == 2) { surface.PreviewOutput = half4(_Sine_8DFBD739_Out, _Sine_8DFBD739_Out, _Sine_8DFBD739_Out, 1.0); return surface; }
				float _Add_F619C33A_Out;
				Unity_Add_float(_Sine_8DFBD739_Out, _Add_F619C33A_B, _Add_F619C33A_Out);
				if (Float_1502402 == 3) { surface.PreviewOutput = half4(_Add_F619C33A_Out, _Add_F619C33A_Out, _Add_F619C33A_Out, 1.0); return surface; }
				float _Add_767D71F7_Out;
				Unity_Add_float(_Sine_8DFBD739_Out, _Add_767D71F7_B, _Add_767D71F7_Out);
				if (Float_1502402 == 4) { surface.PreviewOutput = half4(_Add_767D71F7_Out, _Add_767D71F7_Out, _Add_767D71F7_Out, 1.0); return surface; }
				float _Divide_D7A895AB_Out;
				Unity_Divide_float(_Add_767D71F7_Out, _Divide_D7A895AB_B, _Divide_D7A895AB_Out);
				if (Float_1502402 == 5) { surface.PreviewOutput = half4(_Divide_D7A895AB_Out, _Divide_D7A895AB_Out, _Divide_D7A895AB_Out, 1.0); return surface; }
				float _Multiply_8DD4714C_Out;
				Unity_Multiply_float(_Add_F619C33A_Out, _Multiply_8DD4714C_B, _Multiply_8DD4714C_Out);
				if (Float_1502402 == 6) { surface.PreviewOutput = half4(_Multiply_8DD4714C_Out, _Multiply_8DD4714C_Out, _Multiply_8DD4714C_Out, 1.0); return surface; }
				float4 _Multiply_85322B94_Out;
				Unity_Multiply_float((_Multiply_8DD4714C_Out.xxxx), _Lerp_B49E4547_Out, _Multiply_85322B94_Out);
				if (Float_1502402 == 7) { surface.PreviewOutput = half4(_Multiply_85322B94_Out.x, _Multiply_85322B94_Out.y, _Multiply_85322B94_Out.z, 1.0); return surface; }
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
	            
	        };
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            
	            return o;
	        }
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	        }
	        ENDCG
	    }
	}
}
